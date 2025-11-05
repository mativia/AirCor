using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;

namespace tp_pav1_grupo10.Repositorios
{
    public class TipoDocumentoRepositorio
    {
        public List<TipoDocumento> GetTipoDocumentos()
        {
            var lista = new List<TipoDocumento>();
            string sql = "SELECT * FROM TIPO_DOCUMENTO";
            DataTable tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);

            foreach (DataRow fila in tablaResultado.Rows)
            {
                var tipoDocumento = MapearTipoDocumento(fila);
                lista.Add(tipoDocumento);
            }
            return lista;
        }

        private TipoDocumento MapearTipoDocumento(DataRow fila)
        {
            TipoDocumento tipoDocumento = new TipoDocumento();
            tipoDocumento.IdTipoDocumento = Convert.ToInt32(fila["IdTipoDocumento"]);
            tipoDocumento.Nombre = fila["Nombre"].ToString();
            return tipoDocumento;
        }
    }
}
