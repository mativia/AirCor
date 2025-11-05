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
    public class AeropuertoServicios
    {
        private readonly AeropuertoRepositorio aeropuertoRepositorio;
        public AeropuertoServicios()
        {
            aeropuertoRepositorio = new AeropuertoRepositorio();
        }

        public string ValidarAeropuertos(Aeropuerto aeropuerto, string codigoCiudad)
        {
            string mensaje = "";
            if (aeropuerto.Nombre == "")
            {
                mensaje += "Es necesario el nombre del aeropuerto\n";
            }
            if (aeropuerto.CodigoAeropuerto.Length > 3)
            {
                mensaje += "El codigo del aeropuerto debe tener como maximo 3 caracteres\n";
            }
            if (aeropuerto.CodigoAeropuerto == "")
            {
                mensaje += "Es necesario el codigo del aeropuerto\n";
            }
            if (aeropuerto.Calle == "")
            {
                mensaje += "Es necesario el nombre de la calle\n";
            }
            if (aeropuerto.NroCalle == "")
            {
                mensaje += "Es necesario el numero de la calle\n";
            }
            if (aeropuerto.Telefono == "")
            {
                mensaje += "Es necesario el numero de telefono\n";
            }
            if (codigoCiudad == "")
            {
                mensaje += "Es necesario seleccionar una ciudad\n";
            }
            return mensaje;
        }
        public DataTable GetAeropuerto()
        {
            return aeropuertoRepositorio.GetAeropuerto();
        }

        public string InsertAeropuerto(Aeropuerto aeropuerto, string codigoCiudad)
        {
            string mensaje = "";
            mensaje = ValidarAeropuertos(aeropuerto, codigoCiudad);
            if (mensaje == "")
            {
                int filasAfectadas = aeropuertoRepositorio.InsertAeropuerto(aeropuerto, codigoCiudad);
                if (filasAfectadas == 0)
                {
                    mensaje = "Ha ocurrido un error en el almacenamiento de datos";
                }

            }
            return mensaje;
        }
        public string DeleteAeropuerto(string codigoAeropuerto)
        {
            string mensaje = "";
            int filasAfectadas = aeropuertoRepositorio.DeleteAeropuerto(codigoAeropuerto);
            if (filasAfectadas == 0)
            {
                mensaje = "Ha ocurrido un error en el almacenamiento de datos";
            }
            return mensaje;
        }
        public string UpdateAeropuerto(Aeropuerto aeropuerto, string codCiudad)
        {
            string mensaje = "";
            mensaje = ValidarAeropuertos(aeropuerto, codCiudad);
            if (mensaje == "")
            {
                int filasAfectadas = aeropuertoRepositorio.UpdateAeropuerto(aeropuerto, codCiudad);
                if (filasAfectadas == 0)
                {
                    mensaje = "Ha ocurrido un error en el almacenamiento de datos";
                }
            }
            return mensaje;
        }

        public List<Aeropuerto> GetAeropuertosDeCiudad(string ciudad)
        {
            return aeropuertoRepositorio.GetAeropuertosDeCiudad(ciudad);
        }
    }
}
