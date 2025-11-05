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
    public class PaisServicios
    {
        private readonly PaisRepositorio paisRepositorio;

        public PaisServicios()
        {
            paisRepositorio = new PaisRepositorio();
        }

        public List<Pais> GetPaises()
        {
            return paisRepositorio.GetPaises();
        }

        public string InsertPaises(Pais pais)
        {
            string mensaje = "";
            mensaje  = ValidarPais(pais);
            if (mensaje == "")
            {
                int filasAfectadas = paisRepositorio.InsertPaises(pais);
                if(filasAfectadas == 0)
                {
                    mensaje = "Ha ocurrido un error en el almacenamiento de datos";
                }
            }

            return mensaje;
        }

        public string DeletePaises(Pais pais)
        {
            string mensaje = "";
            int filasAfectadas = paisRepositorio.DeletePaises(pais); 
            if (filasAfectadas == 0)
            {
                mensaje = "Ha ocurrido un error en el almacenamiento de datos";
            }

            return mensaje;
        }

        private string ValidarPais(Pais pais)
        {
            string mensaje = "";
            if (pais.Nombre == "")
            {
                mensaje += "Es necesario el nombre del Pais";
            }
            return mensaje;
        }
        
        public string UpdatePaises(Pais pais)
        {
            string mensaje = "";
            int filasAfectadas = paisRepositorio.UpdatePaises(pais);
            if (filasAfectadas == 0)
            {
                mensaje = "Ha ocurrido un error en el almacenamiento de datos";
            }

            return mensaje;
        }
    }
}
