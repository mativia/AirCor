using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_pav1_grupo10.Entidades
{
    public class Pais
    {
        public int IdPais { get; set; }
        public string Nombre { get; set; }
        public List<Provincia> ListaProvincias { get; set; }
        public bool Activo { get; set; }
    }
}
