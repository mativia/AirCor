using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.Repositorios;

namespace tp_pav1_grupo10.Servicios
{
    public class PasajeroServicios
    {
        private readonly PasajeroRepositorio pasajeroRepositorio;

        public PasajeroServicios()
        {
            pasajeroRepositorio = new PasajeroRepositorio();
        }

        public List<Pasajero> GetPasajeros()
        {
            return pasajeroRepositorio.GetPasajeros();
        }

        public List<Pasajero> GetPasajeros(PasajeroFiltro pf)
        {
            return pasajeroRepositorio.GetPasajeros(pf);
        }

        public string InsertPasajero(Pasajero p)
        {
            string mensaje = "";
            mensaje = ValidarPasajero(p);
            if (mensaje == "")
            {
                int filasAfectadas = pasajeroRepositorio.InsertPasajero(p);
                if (filasAfectadas == 0)
                {
                    mensaje = "Ha ocurrido un error en el almacenamiento de datos";
                }
            }

            return mensaje;
        }

        private string ValidarPasajero(Pasajero p)
        {
            string mensaje = "";
            if (p.Nombre == "" || p.Nombre.Length > 100)
            {
                mensaje += "Debe asignar un nombre (menor a 100 caracteres)\n";
            }
            if (p.Apellido == "" || p.Apellido.Length > 100)
            {
                mensaje += "Debe asignar un apellido (menor a 100 caracteres)\n";
            }
            if (p.NroDocumento == "")
            {
                mensaje += "Debe ingresar un numero de documento\n";
            }
            if (p.ObjTipoDocumento.IdTipoDocumento == 0)
            {
                mensaje += "Debe seleccionar un tipo documento\n";
            }
            if (p.ObjPais.IdPais == 0)
            {
                mensaje += "Debe seleccionar una nacionalidad\n";
            }
            if (p.ObjSexo.IdSexo == 0)
            {
                mensaje += "Debe seleccionar un sexo\n";
            }
            //bool algo = Int64.TryParse(p.TelefonoCelular, out _);
            if (p.TelefonoCelular != "" && !(Int64.TryParse(p.TelefonoCelular, out _)))
            {
                mensaje += "El telefono celular debe ser de tipo numerico";
            }

            return mensaje;
        }

        public string UpdatePasajero(Pasajero p)
        {
            string mensaje = "";
            mensaje = ValidarPasajero(p);
            if (mensaje == "")
            {
                int filasAfectadas = pasajeroRepositorio.UpdatePasajero(p);
                if (filasAfectadas == 0)
                {
                    mensaje = "Ha ocurrido un error en el almacenamiento de datos";
                }
            }

            return mensaje;
        }

        public string DeletePasajero(Pasajero p)
        {
            string mensaje = "";
            int filasAfectadas = pasajeroRepositorio.DeletePasajero(p);
            if (filasAfectadas == 0)
            {
                mensaje = "Ha ocurrido un error en el almacenamiento de datos";
            }

            return mensaje;
        }
    }
}
