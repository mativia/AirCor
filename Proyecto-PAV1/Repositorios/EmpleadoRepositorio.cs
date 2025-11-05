using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;

namespace tp_pav1_grupo10.Repositorios
{
    public class EmpleadoRepositorio
    {
        public DataTable GetEmpleados()
        {
            DataTable tablaResultado = new DataTable();
            string sql = "SELECT E.Legajo, E.Nombre AS 'NombreEmpleado', E.Apellido, U.IdUsuario, U.Nombre AS 'NombreUsuario' " +
                "FROM EMPLEADO E JOIN USUARIO U ON E.IdUsuario = U.IdUsuario " +
                "WHERE E.Activo = 1";
            tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            return tablaResultado;
        }

        public int InsertEmpleados(Empleado empleado)
        {
            string sql = $"INSERT INTO Empleado VALUES ({empleado.Legajo}, '{empleado.Nombre}', '{empleado.Apellido}', {empleado.ObjUsuario.IdUsuario}, 1)";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }

        public int DeleteEmpleados(int legajo)
        {
            string sql = $"UPDATE Empleado SET Activo = 0 WHERE Legajo = {legajo}";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }

        public int UpdateEmpleados(Empleado empleado)
        {
            string sql = $"UPDATE Empleado SET Legajo = {empleado.Legajo},Nombre = '{empleado.Nombre}', Apellido = '{empleado.Apellido}', IdUsuario = {empleado.ObjUsuario.IdUsuario} WHERE Legajo = {empleado.Legajo}";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }
    }
}
