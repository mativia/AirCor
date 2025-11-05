using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tp_pav1_grupo10.Repositorios;
using tp_pav1_grupo10.Entidades;
using System.Data;

namespace tp_pav1_grupo10.Servicios
{
    public class ProvinciaServicios
    {
        private readonly ProvinciaRepositorio provinciaRepositorio;
        public ProvinciaServicios()
        {
            provinciaRepositorio = new ProvinciaRepositorio();
        }
        
        public DataTable GetProvincias()
        {
            return provinciaRepositorio.GetProvincias();
        }

        public DataTable GetProvinciasDelPais(int idPais)
        {
            return provinciaRepositorio.GetProvinciasDelPais(idPais);
        }

        public string InsertProvincias(Provincia provincia,int idPais)
        {
            string mensaje = "";
            mensaje = ValidarProvincia(provincia, idPais);
            if (mensaje == "")
            {
                int filasAfectadas = provinciaRepositorio.InsertProvincias(provincia, idPais);
                if (filasAfectadas == 0)
                {
                    mensaje = "Ha ocurrido un error en la base de datos";
                }
            }
            return mensaje;
        }

        private string ValidarProvincia(Provincia provincia,int idPais)
        {
            string mensaje = "";
            if(provincia.Nombre == "")
            {
                mensaje += "Es necesario el nombre de la provincia\n";                
            }
            if (idPais== 0)
            {
                mensaje += "Es necesario seleccionar un pais\n";
            }
            return mensaje;
        }
        //Baja de provincia 
        public string DeleteProvincias(int idProvincia)
        {
            string mensaje = "";
            int filasAfectadas = provinciaRepositorio.DeleteProvincias(idProvincia);
            if (filasAfectadas == 0)
            {
                mensaje = "Ha ocurrido un error en el almacenamiento de datos";
            }

            return mensaje;
        }
        //Modificacion de provincia
        public string UpdateProvincias(Provincia provincia, int idPais)
        {
            string mensaje = "";
            int filasAfectadas = provinciaRepositorio.UpdateProvincias(provincia, idPais);
            if (filasAfectadas == 0)
            {
                mensaje = "Ha ocurrido un error en el almacenamiento de datos";
            }

            return mensaje;
        }
    }
}
