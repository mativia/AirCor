using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;

namespace tp_pav1_grupo10.Repositorios
{
    internal class AeropuertoRepositorio
    {
        public DataTable GetAeropuerto()
        {
            DataTable tablaResultado = new DataTable();
            string sql = "SELECT A.*, C.Nombre AS 'NombreCiudad' FROM Aeropuerto A JOIN Ciudad C ON A.CodigoCiudad = C.CodigoCiudad WHERE A.Activo = 1";
            tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            return tablaResultado;
        }

        public List<Aeropuerto> GetAeropuertosDeCiudad(string ciudad)
        {
            string sql = $"SELECT A.CodigoAeropuerto, A.Nombre FROM AEROPUERTO A WHERE A.CodigoCiudad = '{ciudad}' AND A.Activo = 1";
            DataTable tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            List<Aeropuerto> listadoAeropuertos = new List<Aeropuerto>();

            foreach (DataRow fila in tablaResultado.Rows)
            {
                string nom = fila["CodigoAeropuerto"].ToString() + ", " + fila["Nombre"];
                Aeropuerto a = new Aeropuerto()
                {
                    CodigoAeropuerto = fila["CodigoAeropuerto"].ToString(),
                    Nombre = nom
                };
                listadoAeropuertos.Add(a);
            }

            return listadoAeropuertos;
        }

        public int InsertAeropuerto(Aeropuerto aeropuerto, string codigoCiudad)
        {
            string sql = $"INSERT INTO Aeropuerto VALUES ('{aeropuerto.CodigoAeropuerto}', '{aeropuerto.Nombre}', '{aeropuerto.Calle}', '{aeropuerto.NroCalle}', '{aeropuerto.Telefono}','{codigoCiudad}', 1)";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }

        public int DeleteAeropuerto(string codigoAeropuerto)
        {
            string sql = $"UPDATE AEROPUERTO SET Activo = 0 WHERE CodigoAeropuerto = '{codigoAeropuerto}'";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }

        public int UpdateAeropuerto(Aeropuerto aeropuerto, string codCiudad)
        {
            string sql = $"UPDATE AEROPUERTO " +
                $"SET CodigoAeropuerto = '{aeropuerto.CodigoAeropuerto}', Nombre = '{aeropuerto.Nombre}', Calle = '{aeropuerto.Calle}', NroCalle = '{aeropuerto.NroCalle}', Telefono = '{aeropuerto.Telefono}', CodigoCiudad = '{codCiudad}'" +
                $"WHERE CodigoAeropuerto = '{aeropuerto.CodigoAeropuerto}'";
            //*$"UPDATE AEROPUERTO SET CodigoAeropuerto = ('{aeropuerto.CodigoAeropuerto}', Nombre = '{aeropuerto.Nombre}', Calle = '{aeropuerto.Calle}', NroCalle = '{aeropuerto.NroCalle}', Telefono = '{aeropuerto.Telefono}',CodigoCiudad = '{codCiudad}' WHERE CodigoAeropuerto = '{aeropuerto.CodigoAeropuerto}'";*/
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }

    }
}
