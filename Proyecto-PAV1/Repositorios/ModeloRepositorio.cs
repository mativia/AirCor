using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_pav1_grupo10.Repositorios
{
    public class ModeloRepositorio
    {
        public DataTable GetModelos()
        {
            DataTable tablaResultado = new DataTable();
            string sql = "SELECT * FROM MODELO";
            tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            return tablaResultado;
        }
    }
}
