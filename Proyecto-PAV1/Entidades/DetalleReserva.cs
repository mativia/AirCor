using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_pav1_grupo10.Entidades
{
    public class DetalleReserva
    {
        public Pasajero ObjPasajero { get; set; }
        public float Importe { get; set; }
        public Asiento ObjAsiento { get; set; }
        public bool EsTitular { get; set; }
    }
}
