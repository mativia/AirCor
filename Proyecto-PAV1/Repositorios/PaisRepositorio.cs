using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tp_pav1_grupo10.Entidades;


namespace tp_pav1_grupo10.Repositorios
{
    public class PaisRepositorio
    {
        public List<Pais> GetPaises()
        {
            var lista = new List<Pais>();
            var sql = $"SELECT * FROM Pais WHERE Activo = 1";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            foreach (DataRow fila in tablaResultado.Rows)
            {
                var pais = MapearPais(fila);
                lista.Add(pais);
            }
            return lista;
        }

        private Pais MapearPais(DataRow fila)
        {
            var pais = new Pais();
            pais.IdPais = Convert.ToInt32(fila["IdPais"]);
            pais.Nombre = fila["Nombre"].ToString();
            pais.Activo = Convert.ToInt32(fila["Activo"]) == 1;

            return pais;
        }

        public int InsertPaises(Pais pais)
        {
            string sql = $"INSERT INTO Pais VALUES ('{pais.Nombre}', 1)";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }

        public int DeletePaises(Pais pais)
        {
            string sql = $"UPDATE Pais SET Activo = 0 WHERE IdPais = {pais.IdPais}";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }

        public int UpdatePaises(Pais pais)
        {
            string sql = $"UPDATE Pais SET Nombre = '{pais.Nombre}' WHERE IdPais = {pais.IdPais}";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }
    }
}
