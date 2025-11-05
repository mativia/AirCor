using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_pav1_grupo10.Entidades
{
    public class Asiento
    {
        public int Numero { get; set; }
        public char Letra { get; set; }
        public bool Estado { get; set; }
        public TipoClase TipoClase { get; set; }
    }
}
