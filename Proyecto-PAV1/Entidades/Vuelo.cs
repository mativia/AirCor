using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_pav1_grupo10.Entidades
{
    public class Vuelo
    {
        public int IdVuelo { get; set; }
        public DateTime FechaPartida { get; set; }
        public List<CambioEstadoVuelo> ListaCambiosEstado { get; set; }

    }
}
