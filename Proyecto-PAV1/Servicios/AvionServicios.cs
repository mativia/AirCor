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
    public class AvionServicios
    {
        private readonly AvionRepositorio avionRepositorio;

        public AvionServicios()
        {
            avionRepositorio = new AvionRepositorio();
        }

        public DataTable GetAviones()
        {
            return avionRepositorio.GetAviones();
        }

        public List<Avion> GetAvionesDisponibles()
        {
            return avionRepositorio.GetAvionesDisponibles();
        }

        public string InsertAviones(Avion avion)
        {
            string mensaje = "";
            mensaje = ValidarAvion(avion);
            if (mensaje == "")
            {
                int filasAfectadas = avionRepositorio.InsertAviones(avion);
                if (filasAfectadas == 0)
                {
                    mensaje = "Ha ocurrido un error en el almacenamiento de datos";
                }
            }

            return mensaje;
        }

        private string ValidarAvion(Avion avion)
        {
            string mensaje = "";
            if (avion.Matricula == "")
            {
                mensaje += "Es necesario la matricula del avion\n";
            }
            if (avion.Matricula.Length > 10)
            {
                mensaje += "La matricula no puede poseer más de 10 caracteres\n";
            }
            if (avion.CantidadSalidasEmergencias == "")
            {
                mensaje += "Es necesaria la cantidad de salidas de emergencia\n";
            }
            if (avion.Longitud == "")
            {
                mensaje += "Es necesaria la longitud\n";
            }
            if (avion.AlcanceVuelo == "")
            {
                mensaje += "Es necesaria el alcance de vuelo\n";
            }

            return mensaje;
        }

        public string DeleteAviones(string matricula)
        {
            string mensaje = "";
            int filasAfectadas = avionRepositorio.DeleteAviones(matricula);
            if (filasAfectadas == 0)
            {
                mensaje = "Ha ocurrido un error en el almacenamiento de datos";
            }

            return mensaje;
        }

        public string UpdateAviones(Avion avion)
        {
            string mensaje = "";
            int filasAfectadas = avionRepositorio.UpdateAviones(avion);
            if (filasAfectadas == 0)
            {
                mensaje = "Ha ocurrido un error en el almacenamiento de datos";
            }

            return mensaje;
        }
    }
}
