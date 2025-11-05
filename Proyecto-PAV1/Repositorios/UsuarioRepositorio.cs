using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;

namespace tp_pav1_grupo10.Repositorios
{
    public class UsuarioRepositorio
    {
        public DataTable GetUsuarios()
        {
            DataTable tablaResultado = new DataTable();
            string sql = $"SELECT U.IdUsuario, U.Nombre AS 'NombreUsuario', P.Nombre as 'NombrePerfil', P.IdPerfil " +
                $"FROM USUARIO U " +
                $"JOIN PERFIL P ON P.IdPerfil = U.IdPerfil " +
                $"WHERE U.Activo = 1";
            tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            return tablaResultado;
        }

        public int InsertUsuarios(Usuario usuario)
        {
            string sql = $"INSERT INTO USUARIO VALUES ('{usuario.Nombre}', '{usuario.Contraseña}', {usuario.ObjPerfil.IdPerfil}, 1)";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }

        public int UpdateUsuarios(Usuario usuario)
        {
            string sql = $"UPDATE USUARIO " +
                $"SET Nombre = '{usuario.Nombre}', Contraseña = '{usuario.Contraseña}', IdPerfil = {usuario.ObjPerfil.IdPerfil} " +
                $"WHERE IdUsuario = {usuario.IdUsuario}";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }

        public int DeleteUsuarios(int idUsuario)
        {
            string sql = $"UPDATE USUARIO SET ACTIVO = 0 WHERE IdUsuario = {idUsuario}";
            int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
            return filasAfectadas;
        }

        public Usuario LoginBD(Usuario usuarioIngresado)
        {
            Usuario usuarioResultado = null;
            string sql = $"SELECT U.*, P.Nombre as 'NombrePerfil' FROM USUARIO U JOIN PERFIL P ON U.IdPerfil = P.IdPerfil WHERE U.Nombre = '{usuarioIngresado.Nombre}' AND U.Contraseña = '{usuarioIngresado.Contraseña}'";
            DataTable tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);

            if (tablaResultado.Rows.Count == 1)
            {
                DataRow row = tablaResultado.Rows[0];
                usuarioResultado = new Usuario();
                usuarioResultado.Nombre = row["Nombre"].ToString();
                usuarioResultado.IdUsuario = Convert.ToInt32(row["IdUsuario"]);
                Perfil perfil = new Perfil() { IdPerfil = Convert.ToInt32(row["IdPerfil"]), Nombre = row["NombrePerfil"].ToString() };
                usuarioResultado.ObjPerfil = perfil;
            }

            return usuarioResultado;
        }


    }
}
