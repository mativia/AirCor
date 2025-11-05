using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.InterfacesDeUsuario;
using tp_pav1_grupo10.Repositorios;

namespace tp_pav1_grupo10.Servicios
{
    public class UsuarioServicios
    {
        private readonly UsuarioRepositorio usuarioRepositorio;
        public static Usuario UsuarioLogueado = new Usuario();
        public UsuarioServicios()
        {
            usuarioRepositorio = new UsuarioRepositorio();
        }

        public string ValidarUsuario(Usuario usuario, string confConstraseña)
        {
            string mensaje = "";
            if (usuario.Nombre == "")
            {
                mensaje += "Es necesario el nombre del usuario\n";
            }
            if (usuario.Contraseña == "")
            {
                mensaje += "Es necesario la contraseña del usuario\n";
            }

            if (confConstraseña == "")
            {
                mensaje += "Es necesario que confirme la contraseña del usuario\n";
            }
            else if (usuario.Contraseña != confConstraseña)
            {
                mensaje += "Las contraseñas no coinciden\n";
            }

            if (usuario.ObjPerfil.IdPerfil < 1)
            {
                mensaje += "Es necesario seleccionar un perfil\n";
            }
            return mensaje;
        }

        public DataTable GetUsuarios()
        {
            return usuarioRepositorio.GetUsuarios();
        }

        public string InsertUsuarios(Usuario usuario, string confContraseña)
        {
            string mensaje = "";
            mensaje = ValidarUsuario(usuario, confContraseña);
            if (mensaje == "")
            {
                int filasAfectadas = usuarioRepositorio.InsertUsuarios(usuario);
                if (filasAfectadas == 0)
                {
                    mensaje = "Ha ocurrido un error en el almacenamiento de datos";
                }
            }
            return mensaje;
        }

        public string UpdateUsuarios(Usuario usuario, string confConfirmacion)
        {
            string mensaje = "";
            mensaje = ValidarUsuario(usuario, confConfirmacion);
            if (mensaje == "")
            {
                int filasAfectadas = usuarioRepositorio.UpdateUsuarios(usuario);
                if (filasAfectadas == 0)
                {
                    mensaje = "Ha ocurrido un error en el almacenamiento de datos";
                }
            }
            return mensaje; 
        }

        public string DeleteUsuarios(int idUsuario)
        {
            string mensaje = "";
            int filasAfectadas = usuarioRepositorio.DeleteUsuarios(idUsuario);
            if (filasAfectadas == 0)
            {
                mensaje = "Ha ocurrido un error en el almacenamiento de datos";
            }
            return mensaje;
        }

        public Usuario Login(Usuario usuarioIngresado)
        {
            Usuario usuario = usuarioRepositorio.LoginBD(usuarioIngresado);
            UsuarioLogueado = usuario;
            return usuario;
        }
    }
}
