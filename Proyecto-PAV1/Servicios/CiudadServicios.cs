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
    public class CiudadServicios
    {
        private readonly CiudadRepositorio ciudadRepositorio;
        public CiudadServicios()
        {
            ciudadRepositorio = new CiudadRepositorio();
        }

        public string ValidarCiudades(Ciudad ciudad, int idProvincia)
        {
            string mensaje = "";
            if (ciudad.CodigoCiudad == "")
            {
                mensaje += "Es necesario el codigo de la ciudad\n";
            }
            if (ciudad.CodigoCiudad.Length > 3)
            {
                mensaje += "El codigo de la ciudad debe tener como maximo 3 caracteres\n";
            }
            if (ciudad.Nombre == "")
            {
                mensaje += "Es necesario el nombre de la ciudad\n";
            }
            if (idProvincia < 1)
            {
                mensaje += "Es necesario seleccionar una provincia\n";
            }
            return mensaje;
        }

        public DataTable GetCiudades()
        {
            return ciudadRepositorio.GetCiudades();
        }

        public string InsertCiudades(Ciudad ciudad, int idProvincia)
        {
            string mensaje = "";
            mensaje = ValidarCiudades(ciudad, idProvincia);
            if (mensaje == "")
            {
                int filasAfectadas = ciudadRepositorio.InsertCiudades(ciudad, idProvincia);
                if (filasAfectadas == 0)
                {
                    mensaje = "Ha ocurrido un error en el almacenamiento de datos";
                }

            }
            return mensaje;
        }

        public string UpdateCiudades(string idCiudadAnterior, Ciudad ciudad, int idProvincia)
        {
            string mensaje = "";
            mensaje = ValidarCiudades(ciudad, idProvincia);
            if (mensaje == "")
            {
                int filasAfectadas = ciudadRepositorio.UpdateCiudades(idCiudadAnterior, ciudad, idProvincia);
                if (filasAfectadas == 0)
                {
                    mensaje = "Ha ocurrido un error en el almacenamiento de datos";
                }
            }
            return mensaje;
        }

        public string DeleteCiudades(string idCiudad)
        {
            string mensaje = "";
            int filasAfectadas = ciudadRepositorio.DeleteCiudades(idCiudad);
            if (filasAfectadas == 0)
            {
                mensaje = "Ha ocurrido un error en el almacenamiento de datos";
            }
            return mensaje;
        }

        public List<Ciudad> GetCiudadesProvinciaPais()
        {
            return ciudadRepositorio.GetCiudadesProvinciaPais();
        }
    }
}
