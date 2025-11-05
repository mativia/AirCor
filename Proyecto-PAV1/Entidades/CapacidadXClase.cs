using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_pav1_grupo10.Entidades
{
    public class CapacidadXClase
    {
        public int IdCapacidadXClase { get; set; }
        public int NumeroFilas { get; set; }
        public int NumeroAsientosXFila { get; set; }
        public TipoClase ObjTipoClase { get; set; }
    }
}
