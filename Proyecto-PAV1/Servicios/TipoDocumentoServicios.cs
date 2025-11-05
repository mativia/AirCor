using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.Repositorios;

namespace tp_pav1_grupo10.Servicios
{
    public class TipoDocumentoServicios
    {
        private readonly TipoDocumentoRepositorio tipoDocumentoRepositorio;

        public TipoDocumentoServicios()
        {
            tipoDocumentoRepositorio = new TipoDocumentoRepositorio();
        }

        public List<TipoDocumento> GetTipoDocumentos()
        {
            return tipoDocumentoRepositorio.GetTipoDocumentos();
        }
    }
}
