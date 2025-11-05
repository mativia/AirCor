using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.Repositorios;

namespace tp_pav1_grupo10.Servicios
{
    public class PerfilServicios
    {
        private readonly PerfilRepositorio perfilRepositorio;

        public PerfilServicios()
        {
            perfilRepositorio = new PerfilRepositorio();
        }

        public List<Perfil> GetPerfiles()
        {
            return perfilRepositorio.GetPerfiles();
        }

        public DataTable GetSoloPerfiles()
        {
            return perfilRepositorio.GetSoloPerfiles();
        }

        public string InsertPerfiles(Perfil perfil)
        {
            string mensaje = "";
            mensaje = ValidarPerfil(perfil);
            if (mensaje == "")
            {
                perfilRepositorio.InsertarPerfiles(perfil);
            }
            return mensaje;
        }

        private string ValidarPerfil(Perfil perfil)
        {
            string mensaje = "";
            if (perfil.Nombre == "")
            {
                mensaje += "Es necesario el nombre del Perfil\n";
            }
            if (Convert.ToInt32(perfil.ListaPermisos.Count()) == 0)
            {
                mensaje += "Es necesario agregar por lo menos un Permiso\n";
            }
            return mensaje;
        }

        public void DeletePerfiles(int idPerfil)
        {
            perfilRepositorio.DeletePerfiles(idPerfil);
        }

        public string UpdatePerfiles(Perfil perfil)
        {
            string mensaje = "";
            mensaje = ValidarPerfil(perfil);
            if (mensaje == "")
            {
                perfilRepositorio.UpdatePerfiles(perfil);
            }            
            return mensaje;
        }
    }
}
