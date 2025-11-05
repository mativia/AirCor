using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.Repositorios;

namespace tp_pav1_grupo10.Servicios
{
    public class PermisoServicios
    {
        private readonly PermisoRepositorio permisoRepositorio;
        public PermisoServicios()
        {
            permisoRepositorio = new PermisoRepositorio();
        }
        public List<Permiso> GetListaPermisos(int idPerfil)
        {
            return permisoRepositorio.GetListaPermisos(idPerfil);
        }
    }
}
