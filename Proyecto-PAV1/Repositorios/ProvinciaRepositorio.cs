using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tp_pav1_grupo10.Entidades;

namespace tp_pav1_grupo10.Repositorios
{
    public class ProvinciaRepositorio
    {
        public DataTable GetProvincias()
        {
            DataTable tablaResultado = new DataTable();
            string sql = "SELECT PP.IdPais, P.IdProvincia, P.Nombre AS 'NombreProvincia', PP.nombre AS 'NombrePais' " +
                         "FROM PROVINCIA P JOIN PAIS PP ON P.IdPais = PP.IdPais " +
                         "WHERE P.Activo = 1";
            tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            return tablaResultado;
        }

        public DataTable GetProvinciasDelPais(int idPais)
        {
            DataTable tablaResultado = new DataTable();
            string sql = $"SELECT * FROM PROVINCIA P " +
                $"WHERE P.IdPais = {idPais} AND P.Activo = 1";
            tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            return tablaResultado;
        }

        public int InsertProvincias(Provincia provincia, int idPais)
        {
            string sql = $"INSERT INTO PROVINCIA VALUES ({idPais},'{provincia.Nombre}', 1)";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;  
        }
        
        public int DeleteProvincias(int idProvincia)
        {
            string sql = $"UPDATE Provincia SET Activo = 0 WHERE IdProvincia = {idProvincia}";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }

        public int UpdateProvincias(Provincia provincia, int idPais)
        {
            string sql = $"UPDATE Provincia SET Nombre = '{provincia.Nombre}', IdPais = {idPais} WHERE IdProvincia = {provincia.IdProvincia}";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }
    }   
}
