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
    
    public class EmpleadoServicios
    {
        private EmpleadoRepositorio empleadoRepositorio;
        
        public EmpleadoServicios()
        {
            empleadoRepositorio = new EmpleadoRepositorio();
        }

        public DataTable GetEmpleados()
        {
            return empleadoRepositorio.GetEmpleados();
        }

        public string InsertEmpleados(Empleado empleado)
        {
            string mensaje = "";
            mensaje = ValidarEmpleado(empleado);
            if (mensaje == "")
            {
                int filasAfectadas = empleadoRepositorio.InsertEmpleados(empleado);
                if (filasAfectadas == 0)
                {
                    mensaje = "Ha ocurrido un error en el almacenamiento de datos";
                }
            }

            return mensaje;
        }

        public string DeleteEmpleados(int legajo)
        {
            string mensaje = "";
            int filasAfectadas = empleadoRepositorio.DeleteEmpleados(legajo);
            if (filasAfectadas == 0)
            {
                mensaje = "Ha ocurrido un error en el almacenamiento de datos";
            }

            return mensaje;
        }

        private string ValidarEmpleado(Empleado empleado)
        {
            string mensaje = "";
            if (empleado.Nombre == "")
            {
                mensaje += "Es necesario el nombre del empleado\n";
            }
            if (empleado.Apellido == "")
            {
                mensaje += "Es necesario el apellido del empleado\n";
            }
            if (empleado.Legajo < 1)
            {
                mensaje += "Es necesario el legajo del empleado\n";
            }
            if (empleado.ObjUsuario.IdUsuario < 1)
            {
                mensaje += "Es necesario seleccionar un usuario";
            }
            return mensaje;
        }

        public string UpdateEmpleados(Empleado empleado)
        {
            string mensaje = "";
            mensaje = ValidarEmpleado(empleado);
            if (mensaje == "")
            {
                int filasAfectadas = empleadoRepositorio.UpdateEmpleados(empleado);
                if (filasAfectadas == 0)
                {
                    mensaje = "Ha ocurrido un error en el almacenamiento de datos";
                }
            }
            return mensaje;
        }

    }
    
    

}
