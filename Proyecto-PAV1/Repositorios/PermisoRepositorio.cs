using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;

namespace tp_pav1_grupo10.Repositorios
{
    public class PermisoRepositorio
    {
        public List<Permiso> GetListaPermisos(int idPerfil)
        {
            var lista = new List<Permiso>();
            var sql = $"SELECT PER.IdPermiso, PER.NombreMenuHabilitado " +
                $"FROM PERMISOS_X_PERFIL PP " +
                $"JOIN PERMISO PER ON PP.IdPermiso = PER.IdPermiso " +
                $"WHERE PP.IdPerfil = {idPerfil}";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            foreach (DataRow fila in tablaResultado.Rows)
            {
                var permiso = MapearPermiso(fila);
                lista.Add(permiso);
            }
            return lista;
        }

        private Permiso MapearPermiso(DataRow fila)
        {
            var permiso = new Permiso();
            permiso.IdPermiso = Convert.ToInt32(fila["IdPermiso"]);
            permiso.NombreMenuHabilitado = fila["NombreMenuHabilitado"].ToString();

            return permiso;
        }
    }
}
