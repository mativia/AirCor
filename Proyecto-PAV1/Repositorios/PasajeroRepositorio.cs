using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.Utilities;

namespace tp_pav1_grupo10.Repositorios
{
    public class PasajeroRepositorio
    {
        public List<Pasajero> GetPasajeros()
        {
            try
            {
                var lista = new List<Pasajero>();
                var sql = $"SELECT P.*, S.Nombre AS 'Sexo', PP.Nombre AS 'Nacionalidad', T.Nombre AS 'TipoDocumento' " +
                    $"FROM Pasajero P " +
                    $"JOIN SEXO S ON S.IdSexo = P.IdSexo " +
                    $"JOIN PAIS PP ON PP.IdPais = P.IdPais " +
                    $"JOIN TIPO_DOCUMENTO T ON T.IdTipoDocumento = P.IdTipoDocumento " +
                    $"WHERE P.Activo = 1";
                var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
                foreach (DataRow fila in tablaResultado.Rows)
                {
                    var pasajero = MapearPasajero(fila);
                    lista.Add(pasajero);
                }
                return lista;
            }
            catch (Exception)
            {
                throw new ApplicationException("Hubo un error en el almacenamineto de datos\nComuniquese con el administrador del sistema");
            }
        }

        public List<Pasajero> GetPasajeros(PasajeroFiltro pf)
        {
            try
            {
                var lista = new List<Pasajero>();
                var sql = $"SELECT P.*, S.Nombre AS 'Sexo', PP.Nombre AS 'Nacionalidad', T.Nombre AS 'TipoDocumento' " +
                    $"FROM Pasajero P " +
                    $"JOIN SEXO S ON S.IdSexo = P.IdSexo " +
                    $"JOIN PAIS PP ON PP.IdPais = P.IdPais " +
                    $"JOIN TIPO_DOCUMENTO T ON T.IdTipoDocumento = P.IdTipoDocumento " +
                    $"WHERE P.Activo = 1 ";

                if (pf.Nombre != "")
                {
                    sql += $"AND P.Nombre = '{pf.Nombre}' ";
                }
                if (pf.Apellido != "")
                {
                    sql += $"AND P.Apellido = '{pf.Apellido}' ";
                }
                if (pf.NroDocumento != "")
                {
                    sql += $"AND P.NroDocumento = '{pf.NroDocumento}' ";
                }
                if (pf.IdTipoDocumento != 0)
                {
                    sql += $"AND P.IdTipoDocumento = {pf.IdTipoDocumento} ";
                }

                var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
                foreach (DataRow fila in tablaResultado.Rows)
                {
                    var pasajero = MapearPasajero(fila);
                    lista.Add(pasajero);
                }
                return lista;
            }
            catch (Exception)
            {
                throw new ApplicationException("Hubo un error en el almacenamineto de datos\nComuniquese con el administrador del sistema");
            }
        }

        private Pasajero MapearPasajero(DataRow fila)
        {
            var p = new Pasajero();
            p.NroDocumento = fila["NroDocumento"].ToString();
            p.ObjTipoDocumento = new TipoDocumento()
            {
                IdTipoDocumento = Convert.ToInt32(fila["IdTipoDocumento"]),
                Nombre = fila["TipoDocumento"].ToString()
            };
            p.Apellido = fila["Apellido"].ToString();
            p.Nombre = fila["Nombre"].ToString();
            p.FechaNacimiento = Convert.ToDateTime(fila["FechaNacimiento"].ToString());
            p.ObjSexo = new Sexo()
            {
                IdSexo = Convert.ToInt32(fila["IdSexo"]),
                Nombre = fila["Sexo"].ToString()
            };
            p.ObjPais = new Pais
            {
                IdPais = Convert.ToInt32(fila["IdPais"]),
                Nombre = fila["Nacionalidad"].ToString(),
            };
            p.TelefonoCelular = fila["TelefonoCelular"].ToString();
            p.Email = fila["Email"].ToString();

            return p;
        }

        public int InsertPasajero(Pasajero pasajero)
        {
            try
            {
                string sql = $"INSERT INTO Pasajero (Apellido, Nombre, FechaNacimiento, IdTipoDocumento, NroDocumento, IdSexo, IdPais, Activo, TelefonoCelular, Email) VALUES " +
                            $"('{pasajero.Apellido}', '{pasajero.Nombre}', '{pasajero.FechaNacimiento.ToString("yyyyMMdd HH:mm")}', {pasajero.ObjTipoDocumento.IdTipoDocumento}, '{pasajero.NroDocumento}', " +
                            $"{pasajero.ObjSexo.IdSexo}, {pasajero.ObjPais.IdPais}, 1, '{pasajero.TelefonoCelular.ToString()}', '{pasajero.Email.ToString()}')";
                int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
                return filasAfectadas;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                ErrorHandler.Log(ex, "PasajeroRepositorio.InsertPasajero");
                throw new ApplicationException("No se puede insertar un pasajero con un tipo y numero de documento repetido", ex);
            }
            catch (Exception ex)
            {
                ErrorHandler.Log(ex, "PasajeroRepositorio.InsertPasajero");
                throw new ApplicationException("Hubo un error en el almacenamiento de datos. Comuníquese con el administrador del sistema", ex);
            }

        }

        public int UpdatePasajero(Pasajero p)
        {
            try
            {
                string sql = $"UPDATE Pasajero SET Apellido = '{p.Apellido}', Nombre = '{p.Nombre}', FechaNacimiento = '{p.FechaNacimiento.ToString("yyyyMMdd HH:mm")}', IdSexo = {p.ObjSexo.IdSexo}," +
                            $" IdPais = {p.ObjPais.IdPais}, Activo = 1, TelefonoCelular = '{p.TelefonoCelular}', Email = '{p.Email}' WHERE NroDocumento = '{p.NroDocumento}'" +
                            $" AND IdTipoDocumento = {p.ObjTipoDocumento.IdTipoDocumento}";
                int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
                return filasAfectadas;
            }
            catch (Exception ex)
            {
                ErrorHandler.Log(ex, "PasajeroRepositorio.UpdatePasajero");
                throw new ApplicationException("Hubo un error en el almacenamiento de datos. Comuníquese con el administrador del sistema", ex);
            }
        }

        public int DeletePasajero(Pasajero p)
        {
            try
            {
                string sql = $"UPDATE Pasajero SET Activo = 0 WHERE NroDocumento = '{p.NroDocumento}' AND IdTipoDocumento = {p.ObjTipoDocumento.IdTipoDocumento}";
                int filasAfectadas = DBHelper.GetDBHelper().EjecutarSQL(sql);
                return filasAfectadas;
            }
            catch (Exception ex)
            {
                ErrorHandler.Log(ex, "PasajeroRepositorio.DeletePasajero");
                throw new ApplicationException("Hubo un error en el almacenamiento de datos. Comuníquese con el administrador del sistema", ex);
            }
        }
    }
}
