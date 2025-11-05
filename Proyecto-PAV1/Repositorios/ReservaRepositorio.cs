using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;

namespace tp_pav1_grupo10.Repositorios
{
    public class ReservaRepositorio
    {
        public void InsertReserva(Reserva reserva, int idVuelo)
        {
            using (var tx = DBHelper.GetDBHelper().IniciarTransaccion())
            {
                try
                {
                    // Insertar la definicion de vuelo
                    string sql = $"INSERT INTO RESERVA DEFAULT VALUES";
                    int idReserva = DBHelper.GetDBHelper().EjecutarTransaccionSQL(sql);

                    // Insertar cada asiento y cada detalle
                    foreach (DetalleReserva d in reserva.ListaDetalles)
                    {
                        string sqlAsientos = $"INSERT INTO ASIENTO (Numero, Letra, Estado, IdVuelo, IdTipoClase) VALUES ({d.ObjAsiento.Numero}, '{d.ObjAsiento.Letra}', 1, {idVuelo}, {d.ObjAsiento.TipoClase.IdTipoClase})";
                        int idDevuelto = DBHelper.GetDBHelper().EjecutarTransaccionSQL(sqlAsientos);

                        int esTitular = d.EsTitular ? 1 : 0;
                        string sqlDetalle = $"INSERT INTO DETALLE_RESERVA (IdTipoDocumento, NroDocumento, EsTitular, IdAsiento, IdReserva, Importe) VALUES ({d.ObjPasajero.ObjTipoDocumento.IdTipoDocumento}, '{d.ObjPasajero.NroDocumento}', {esTitular}, {idDevuelto}, {idReserva}, {d.Importe})";
                        DBHelper.GetDBHelper().EjecutarTransaccionSQLNoIdentity(sqlDetalle);
                    }
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw new ApplicationException("No se pudo registrar la reserva debido a un problema en el almacenamiento de datos");
                }
                finally
                {
                    DBHelper.GetDBHelper().CloseConnection();
                }
            }
        }
        
    }
}
