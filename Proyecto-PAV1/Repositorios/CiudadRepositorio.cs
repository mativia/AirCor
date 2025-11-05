using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;

namespace tp_pav1_grupo10.Repositorios
{
    public class CiudadRepositorio
    {
        public DataTable GetCiudades()
        {
            DataTable tablaResultado = new DataTable();
            string sql = "SELECT PP.IdPais, P.IdProvincia, C.CodigoCiudad, C.Nombre AS 'NombreCiudad', P.Nombre AS 'NombreProvincia', PP.Nombre AS 'NombrePais' " +
                "FROM CIUDAD C  " +
                "JOIN PROVINCIA P ON P.IdProvincia = C.IdProvincia " +
                "JOIN PAIS PP ON PP.IdPais = P.IdPais " +
                "WHERE C.Activo = 1";
            tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            return tablaResultado;
        }

        public List<Ciudad> GetCiudadesProvinciaPais()
        {
            string sql = "SELECT C.CodigoCiudad, C.nombre AS 'Ciudad', P.nombre AS 'Provincia', Pp.Nombre AS 'Pais' FROM CIUDAD C JOIN PROVINCIA P ON C.IdProvincia = P.IdProvincia JOIN PAIS PP ON PP.IdPais = P.IdPais WHERE C.Activo = 1";
            DataTable tabla = DBHelper.GetDBHelper().ConsultaSQL(sql);

            List<Ciudad> listadoCiudades = new List<Ciudad>();

            foreach (DataRow fila in tabla.Rows)
            {
                string nom = fila["Ciudad"].ToString() + ", " + fila["Provincia"].ToString() + ", " + fila["Pais"].ToString();

                Ciudad c = new Ciudad()
                {
                    CodigoCiudad = fila["CodigoCiudad"].ToString(),
                    Nombre = nom
                };
                listadoCiudades.Add(c);
            }

            return listadoCiudades;
        }

        public int InsertCiudades(Ciudad ciudad, int idProvincia)
        {
            string sql = $"INSERT INTO Ciudad VALUES ('{ciudad.CodigoCiudad}', {idProvincia}, '{ciudad.Nombre}', 1)";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }

        public int UpdateCiudades(string idCiudadAnterior, Ciudad ciudad, int idProvincia)
        {
            string sql = $"UPDATE CIUDAD " +
                $"SET CodigoCiudad = '{ciudad.CodigoCiudad}', IdProvincia = {idProvincia}, Nombre = '{ciudad.Nombre}'" +
                $"WHERE CodigoCiudad = '{idCiudadAnterior}'";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }

        public int DeleteCiudades(string idCiudad)
        {
            string sql = $"UPDATE CIUDAD SET Activo = 0 WHERE CodigoCiudad = '{idCiudad}'";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }
    }
}
