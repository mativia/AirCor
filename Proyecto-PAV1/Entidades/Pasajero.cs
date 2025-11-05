using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_pav1_grupo10.Entidades
{
    public class Pasajero
    {
        public string NroDocumento  { get; set; }
        public TipoDocumento ObjTipoDocumento { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        // public bool EsTitular { get; set; }
        public string TelefonoCelular { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Sexo ObjSexo { get; set; }
        public Pais ObjPais { get; set; }
    }
}
