using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.Utilities;

namespace tp_pav1_grupo10.Repositorios
{
    public class PerfilRepositorio
    {
        private readonly PermisoRepositorio permisoRepositorio;

        public PerfilRepositorio()
        {
            permisoRepositorio = new PermisoRepositorio();
        }

        public List<Perfil> GetPerfiles()
        {
            var lista = new List<Perfil>();
            var sql = $"SELECT * FROM PERFIL WHERE Activo = 1";
            var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            foreach (DataRow fila in tablaResultado.Rows)
            {
                var pe = MapearPerfil(fila);
                lista.Add(pe);
            }
            return lista;
        }

        private Perfil MapearPerfil(DataRow fila)
        {
            List<Permiso> permisosXPerfil = permisoRepositorio.GetListaPermisos(Convert.ToInt32(fila["IdPerfil"]));
            var perfil = new Perfil()
            {
                IdPerfil = Convert.ToInt32(fila["IdPerfil"]),
                Nombre = fila["Nombre"].ToString(),
                ListaPermisos = permisosXPerfil,
            };
            return perfil;
        }

        public DataTable GetSoloPerfiles()
        {
            DataTable tablaResultado = new DataTable();
            string sql = "SELECT * FROM PERFIL";
            tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            return tablaResultado;
        }

        public void InsertarPerfiles (Perfil perfil)
        {
            using (var tx = DBHelper.GetDBHelper().IniciarTransaccion())
            {
                try
                {
                    string sql = $"INSERT INTO PERFIL VALUES ('{perfil.Nombre}', 1)";
                    int idGenerado = DBHelper.GetDBHelper().EjecutarTransaccionSQL(sql);

                    foreach (Permiso p in perfil.ListaPermisos)
                    {
                        string sqlPermiso = $"INSERT INTO PERMISOS_X_PERFIL VALUES ({idGenerado}, {p.IdPermiso})";
                        DBHelper.GetDBHelper().EjecutarTransaccionSQLNoIdentity(sqlPermiso);
                    }

                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    ErrorHandler.Log(ex, "PerfilRepositorio.InsertarPerfiles");
                    throw new ApplicationException("No se pudo registrar el perfil. Comuníquese con el administrador del sistema", ex);
                }
                finally
                {
                    DBHelper.GetDBHelper().CloseConnection();
                }
            }
        }

        public void DeletePerfiles(int idPerfil)
        {
            using (var tx = DBHelper.GetDBHelper().IniciarTransaccion())
            {
                try
                {
                    string sql = $"UPDATE PERFIL SET Activo = 0 WHERE IdPerfil = {idPerfil}";
                    DBHelper.GetDBHelper().EjecutarTransaccionSQLNoIdentity(sql);

                    string sqlPermisoXPerfil = $"DELETE FROM PERMISOS_X_PERFIL WHERE IdPerfil = {idPerfil}";
                    DBHelper.GetDBHelper().EjecutarTransaccionSQLNoIdentity(sqlPermisoXPerfil);

                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    ErrorHandler.Log(ex, "PerfilRepositorio.DeletePerfiles");
                    throw new ApplicationException("No se pudo eliminar el perfil. Comuníquese con el administrador del sistema", ex);
                }
                finally
                {
                    DBHelper.GetDBHelper().CloseConnection();
                }
            }
        }

        public void UpdatePerfiles(Perfil perfil)
        {
            using (var tx = DBHelper.GetDBHelper().IniciarTransaccion())
            {
                try
                {
                    // Cambiar nombre de perfil
                    string sql = $"UPDATE PERFIL SET Nombre = '{perfil.Nombre}' WHERE IdPerfil = {perfil.IdPerfil}";
                    DBHelper.GetDBHelper().EjecutarTransaccionSQLNoIdentity(sql);

                    // Eliminar todos los permisos existentes de ese perfil
                    string sqlPermisoXPerfil = $"DELETE FROM PERMISOS_X_PERFIL WHERE IdPerfil = {perfil.IdPerfil}";
                    DBHelper.GetDBHelper().EjecutarTransaccionSQLNoIdentity(sqlPermisoXPerfil);

                    // Agregar los permisos seleccionados al perfil 
                    foreach (Permiso p in perfil.ListaPermisos)
                    {
                        string sqlPermiso = $"INSERT INTO PERMISOS_X_PERFIL VALUES ({perfil.IdPerfil}, {p.IdPermiso})";
                        DBHelper.GetDBHelper().EjecutarTransaccionSQLNoIdentity(sqlPermiso);
                    }

                    tx.Commit();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    ErrorHandler.Log(ex, "PerfilRepositorio.UpdatePerfiles");
                    throw new ApplicationException("No se pudo actualizar el perfil. Comuníquese con el administrador del sistema", ex);
                }
                finally
                {
                    DBHelper.GetDBHelper().CloseConnection();
                }
            }
        }
    }
}
