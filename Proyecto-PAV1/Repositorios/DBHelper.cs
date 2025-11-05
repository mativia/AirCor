using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Linq;

namespace tp_pav1_grupo10.Repositorios
{
    public class DBHelper
    {
        private string string_conexion;
        private static DBHelper instance = new DBHelper();

        //declaro variable que almacerá un objeto <cmd> del tipo <SqlConnection>
        private SqlConnection _conexion;

        //declaro variable que almacerá un objeto <cmd> del tipo <SqlCommand>
        private SqlCommand _cmd;

        private DBHelper()
        {
            // Intentar leer la cadena de conexión desde el App.config manualmente
            try
            {
                string configPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                if (!string.IsNullOrEmpty(configPath) && File.Exists(configPath))
                {
                    var doc = XDocument.Load(configPath);
                    // Buscar el primer connectionString que contenga 'PAV' en su nombre, si existe
                    var addEl = doc.Descendants("add")
                                   .FirstOrDefault(x => (string)x.Attribute("name") != null && ((string)x.Attribute("name")).ToUpper().Contains("PAV"));
                    if (addEl == null)
                    {
                        // Fallback: tomar el primer elemento add dentro de connectionStrings
                        addEl = doc.Descendants("connectionStrings").Descendants("add").FirstOrDefault();
                    }
                    if (addEl != null)
                    {
                        var connFromConfig = (string)addEl.Attribute("connectionString");
                        if (!string.IsNullOrEmpty(connFromConfig))
                        {
                            string_conexion = connFromConfig;
                            return;
                        }
                    }
                }
            }
            catch
            {
                // Ignorar si no existe o hay problemas leyendo la configuración
            }

            // Valor por defecto: instancia SQLEXPRESS en la máquina local
            string nombrePc = Environment.MachineName;
            string_conexion = $"Data Source={nombrePc}\\SQLEXPRESS;Initial Catalog=PAV_3K2_2022_10;Integrated Security=True;MultipleActiveResultSets=True";
            //string_conexion = "Data Source=200.69.137.167,11333;Initial Catalog=PAV_3K2_2022_10;User ID=PAV_3K2_2022_10;Password=PAV_3K2_2022_10";
        }

        public static DBHelper GetDBHelper()
        {
            if (instance == null)
                instance = new DBHelper();
            return instance;
        }

        /// Resumen:
        ///     Se utiliza para sentencias SQL del tipo “Select”. Recibe por valor una sentencia sql como string
        /// Devuelve:
        ///      un objeto de tipo DataTable con el resultado de la consulta
        public DataTable ConsultaSQL(string strSql)
        {
            try
            {
                SqlConnection cnn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                DataTable tabla = new DataTable();
                cnn.ConnectionString = string_conexion;
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                tabla.Load(cmd.ExecuteReader());
                this.CloseConnection(cnn);
                return tabla;
            }
            catch (Exception ex)
            {
                // Re-lanzar con detalle de la excepción original para facilitar diagnóstico
                throw new ApplicationException("Ocurrió un problema desconocido con el almacenamiento de datos. " + ex.Message, ex);
            }

        }

        /// Resumen:
        ///     Se utiliza para sentencias SQL del tipo “Insert/Update/Delete”. Recibe por valor una sentencia sql como string
        /// Devuelve:
        ///      un valor entero con el número de filas afectadas por la sentencia ejecutada
        public int EjecutarSQL(string strSql)
        {
            try
            {
                int afectadas = 0;
                SqlConnection cnn = new SqlConnection();
                SqlCommand cmd = new SqlCommand();
                cnn.ConnectionString = string_conexion;
                cnn.Open();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql;
                afectadas = cmd.ExecuteNonQuery();
                this.CloseConnection(cnn);
                return afectadas;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrió un problema al ejecutar la operación en la base de datos. " + ex.Message, ex);
            }
        }


        private void CloseConnection(SqlConnection cnn)
        {
            if (cnn != null && cnn.State == ConnectionState.Open)
            {
                cnn.Close();
                cnn.Dispose();
            }
        }

        public void CloseConnection()
        {
            if (_conexion != null && _conexion.State == ConnectionState.Open)
            {
                //cierra la conexión con la base de datos
                _conexion.Close();
            }
        }

        public void Conectar()
        {
            _conexion = new SqlConnection();
            _cmd = new SqlCommand();
            //asigan al objeto <conexion> la cadena de conexion
            _conexion.ConnectionString = string_conexion;
            //agrega la conexion (se crea el pipe entre la aplicación y la base de datos)
            _conexion.Open();
            //se comunica al objeto <cmd> sobre que conexion debe trabajar
            _cmd.Connection = _conexion;
            //se establece el tipo de comando que va ha ejecutar
            _cmd.CommandType = CommandType.Text;
        }

        public SqlTransaction IniciarTransaccion()
        {
            Conectar();
            var transaccion = _conexion.BeginTransaction();
            _cmd.Transaction = transaccion;
            return transaccion;
        }

        public int EjecutarTransaccionSQL(string strSql)
        {
            var id = 0;
            _cmd.CommandText = strSql;

            if (_cmd.ExecuteNonQuery() > 0)
            {
                string consultaGetId = "Select @@Identity";
                _cmd.CommandText = consultaGetId;
                var idDevuelto = _cmd.ExecuteScalar();
                //id = int.Parse(idDevuelto?.ToString());
                //id = int.Parse(null);
                if (idDevuelto != null)
                    id = Convert.ToInt32(idDevuelto.ToString());
            }
            return id;
        }

        public void EjecutarTransaccionSQLNoIdentity(string strSql)
        {
            _cmd.CommandText = strSql;
            _cmd.ExecuteNonQuery();
        }


        public void EjecutarUpdateTransaccionSQL(string strSql)
        {
            _cmd.CommandText = strSql;
            _cmd.ExecuteNonQuery();
        }

        public DataTable ConsultaDuranteTransaccion(string comando)
        {

            _cmd.CommandText = comando;
            //instancia un objeto <tabla> del tipo DataTable
            DataTable tabla = new DataTable();

            tabla.Load(_cmd.ExecuteReader());

            //devuelve el valor calculado a través de la función
            return tabla;
        }
    }
}
