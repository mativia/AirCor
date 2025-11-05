using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_pav1_grupo10.Entidades
{
    public class Aeropuerto
    {
        public string CodigoAeropuerto { get; set; }
        public string Nombre { get; set; }
        public string Calle { get; set; }
        public string NroCalle { get; set; }
        public string Telefono { get; set; }
        public Ciudad ObjCiudad { get; set; }
    }
}
