using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.InterfacesDeUsuario;

namespace tp_pav1_grupo10.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public Perfil ObjPerfil { get; set; }
    }
}
