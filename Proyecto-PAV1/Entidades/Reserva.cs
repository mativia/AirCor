using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_pav1_grupo10.Entidades
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public DateTime FechaHoraCreacion { get; set; }
        public List<DetalleReserva> ListaDetalles { get; set; }
    }
}
