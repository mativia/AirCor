using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_pav1_grupo10.Entidades
{
    public class CambioEstadoVuelo
    {
        public int IdCambioEstadoVuelo { get; set; }
        public DateTime FechaHoraDesde { get; set; }
        public DateTime FechaHoraHasta { get; set; }
        public Usuario ObjUsuario { get; set; }
        public EstadoVuelo ObjEstado { get; set; }
    }
}
