using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_pav1_grupo10.Entidades
{
    public class Empleado
    {
        public long Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Usuario ObjUsuario { get; set; }
    }
}
