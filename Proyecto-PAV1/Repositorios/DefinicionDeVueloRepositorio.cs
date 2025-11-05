using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.Servicios;
using static System.Net.WebRequestMethods;

namespace tp_pav1_grupo10.Repositorios
{
    public class DefinicionDeVueloRepositorio
    {
        private readonly TarifaRepositorio tarifaRepositorio;
        private readonly DiaSemanaRepositorio diaSemanaRepositorio;

        public DefinicionDeVueloRepositorio()
        {
            tarifaRepositorio = new TarifaRepositorio();
            diaSemanaRepositorio = new DiaSemanaRepositorio();
        }

        public List<DefinicionDeVuelo> GetDefinicionVuelo()
        {

            using (var tx = DBHelper.GetDBHelper().IniciarTransaccion())
            {
                try
                {
                    List<DefinicionDeVuelo> lista = new List<DefinicionDeVuelo>();
                    var sql = $"SELECT DV.*, CO.CodigoCiudad 'CodCiudadOrigen', CD.CodigoCiudad 'CodCiudadDestino' FROM DEFINICION_DE_VUELO DV JOIN AEROPUERTO AO ON AO.CodigoAeropuerto = DV.CodigoAeropuertoOrigen JOIN CIUDAD CO ON CO.CodigoCiudad = AO.CodigoCiudad JOIN AEROPUERTO AD ON AD.CodigoAeropuerto = DV.CodigoAeropuertoDestino JOIN CIUDAD CD ON CD.CodigoCiudad = AD.CodigoCiudad WHERE DV.ACTIVO = 1";
                    var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
                    foreach (DataRow fila in tablaResultado.Rows)
                    {
                        var defVuelo = MapearDefinicionDeVuelo(fila);
                        lista.Add(defVuelo);
                    }

                    tx.Commit();

                    return lista;

                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    throw new ApplicationException(
                        $"[DefinicionDeVueloRepositorio] Error al consultar las definiciones de vuelo.\n" +
                        $"Tipo: {ex.GetType().Name}\n" +
                        $"Mensaje: {ex.Message}\n" +
                        $"StackTrace: {ex.StackTrace}"
                    );
                }
                finally
                {
                    DBHelper.GetDBHelper().CloseConnection();
                }
            }
        }

        public DefinicionDeVuelo MapearDefinicionDeVuelo(DataRow fila)
        {
            var defVuelo = new DefinicionDeVuelo();
            defVuelo.NroVuelo = fila["NroVuelo"].ToString();
            defVuelo.Distancia = fila["Distancia"].ToString();
            defVuelo.HorarioEmbarque = Convert.ToDateTime(fila["HorarioEmbarque"].ToString());
            defVuelo.HorarioLlegada = Convert.ToDateTime(fila["HorarioLlegada"].ToString());
            defVuelo.HorarioPartida = Convert.ToDateTime(fila["HorarioPartida"].ToString());
            defVuelo.FechaCreacion = Convert.ToDateTime(fila["FechaCreacion"].ToString());
            defVuelo.ObjAeropuertoOrigen = new Aeropuerto()
            {
                CodigoAeropuerto = fila["CodigoAeropuertoOrigen"].ToString(),
                ObjCiudad = new Ciudad()
                {
                    CodigoCiudad = fila["CodCiudadOrigen"].ToString()
                }
            };
            defVuelo.ObjAeropuertoDestino = new Aeropuerto()
            {
                CodigoAeropuerto = fila["CodigoAeropuertoDestino"].ToString(),
                ObjCiudad = new Ciudad()
                {
                    CodigoCiudad = fila["CodCiudadDestino"].ToString()
                }
            };
            defVuelo.ObjAvion = new Avion()
            {
                Matricula = fila["MatriculaAvion"].ToString()
            };
            defVuelo.FechaVigenteDesde = Convert.ToDateTime(fila["FechaVigenteDesde"].ToString());
            defVuelo.FechaVigenteHasta = Convert.ToDateTime(fila["FechaVigenteHasta"].ToString());
            defVuelo.ListaTarifas = tarifaRepositorio.GetTarifasDeVuelo(defVuelo.NroVuelo);
            defVuelo.ListaDiasSemana = diaSemanaRepositorio.GetDiasSemanaDeVuelo(defVuelo.NroVuelo);

            return defVuelo;
        }

        public void InsertDefinicionVuelo(DefinicionDeVuelo defVuelo)
        {
            using (var tx = DBHelper.GetDBHelper().IniciarTransaccion())
            {
                try
                {
                    // Insertar la definicion de vuelo
                    string sql = $"INSERT INTO DEFINICION_DE_VUELO (NroVuelo, HorarioEmbarque, HorarioPartida, HorarioLlegada, Distancia, CodigoAeropuertoOrigen, CodigoAeropuertoDestino, MatriculaAvion, FechaVigenteDesde, FechaVigenteHasta, Activo) " +
                        $"VALUES ('{defVuelo.NroVuelo}', '{defVuelo.HorarioEmbarque.ToString("yyyyMMdd HH:mm")}', '{defVuelo.HorarioPartida.ToString("yyyyMMdd HH:mm")}', " +
                        $"'{defVuelo.HorarioLlegada.ToString("yyyyMMdd HH:mm")}', '{defVuelo.Distancia}', '{defVuelo.ObjAeropuertoOrigen.CodigoAeropuerto}', " +
                        $"'{defVuelo.ObjAeropuertoDestino.CodigoAeropuerto}', '{defVuelo.ObjAvion.Matricula}', '{defVuelo.FechaVigenteDesde.ToString("yyyyMMdd HH:mm")}', '{defVuelo.FechaVigenteHasta.ToString("yyyyMMdd HH:mm")}', 1)";
                    DBHelper.GetDBHelper().EjecutarTransaccionSQLNoIdentity(sql); 

                    // Insertar cada vuelo
                    foreach (Vuelo nuevoVuelo in defVuelo.ListaVuelos)
                    {
                        string sqlVuelos = $"INSERT INTO VUELO (FechaPartida, NroVuelo) VALUES ('{nuevoVuelo.FechaPartida.ToString("yyyyMMdd HH:mm")}', '{defVuelo.NroVuelo}')";
                        int idDevuelto = DBHelper.GetDBHelper().EjecutarTransaccionSQL(sqlVuelos);

                        string sqlCambioEstadoVuelo = $"INSERT INTO CAMBIO_ESTADO_VUELO (IdUsuario, IdEstadoVuelo, IdVuelo) VALUES ({UsuarioServicios.UsuarioLogueado.IdUsuario}, 1, {idDevuelto})";
                        DBHelper.GetDBHelper().EjecutarTransaccionSQLNoIdentity(sqlCambioEstadoVuelo);
                    }

                    // Insertar cada dia
                    foreach (DiaSemana dia in defVuelo.ListaDiasSemana)
                    {
                        string sqlDia = $"INSERT INTO DEFINICION_DE_VUELO_X_DIAS (NroVuelo, IdDiaSemana, Activo) VALUES ('{defVuelo.NroVuelo}', {dia.IdDiaSemana}, 1)";
                        DBHelper.GetDBHelper().EjecutarTransaccionSQLNoIdentity(sqlDia);
                    }

                    // Insertar tarifas
                    foreach (Tarifa tarifa in defVuelo.ListaTarifas)
                    { 
                        string sqlTarifa = $"INSERT INTO TARIFA (Importe, IdTipoClase, NroVuelo, Activo) VALUES ({tarifa.Importe.ToString().Replace(",", ".")}, {tarifa.ObjTipoClase.IdTipoClase}, '{defVuelo.NroVuelo}', 1)";
                        DBHelper.GetDBHelper().EjecutarTransaccionSQLNoIdentity(sqlTarifa);
                    }

                    tx.Commit();
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    tx.Rollback();
                    throw new ApplicationException("No se puede insertar una definicion de vuelo con un numero de vuelo ya utilizado");
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw new ApplicationException("No se pudo registrar la definicion de vuelo");
                }
                finally
                {
                    DBHelper.GetDBHelper().CloseConnection();
                }
            }
        }

        public void DeleteDefinicionDeVuelo(string nroVuelo)
        {
            using (var tx = DBHelper.GetDBHelper().IniciarTransaccion())
            {
                try
                {
                    // deshabilitado definicion de vuelo
                    string sql = $"UPDATE DEFINICION_DE_VUELO SET ACTIVO = 0 WHERE NroVuelo = '{nroVuelo}'";
                    DBHelper.GetDBHelper().EjecutarTransaccionSQLNoIdentity(sql);

                    // cambio de estado de vuelos
                    string sqlVuelos = $"SELECT * FROM VUELO WHERE NroVuelo = '{nroVuelo}'";
                    DataTable tablaIdVuelos = DBHelper.GetDBHelper().ConsultaDuranteTransaccion(sqlVuelos);

                    DateTime fechaActual = DateTime.Now;
                    foreach (DataRow fila in tablaIdVuelos.Rows)
                    {
                        string sqlEstado = $"UPDATE CAMBIO_ESTADO_VUELO SET IdEstadoVuelo = 2, FechaHoraHasta = '{fechaActual}' WHERE IdVuelo = {fila["IdVuelo"]}";
                        DBHelper.GetDBHelper().EjecutarTransaccionSQLNoIdentity(sqlEstado);
                    }

                    // deshabilitado de dias
                    string sqlDefVueloDias = $"UPDATE DEFINICION_DE_VUELO_X_DIAS SET Activo = 0 WHERE NroVuelo = '{nroVuelo}'";
                    DBHelper.GetDBHelper().EjecutarTransaccionSQLNoIdentity(sqlDefVueloDias);

                    string sqlTarifas = $"UPDATE TARIFA SET Activo = 0 WHERE NroVuelo = '{nroVuelo}'";
                    DBHelper.GetDBHelper().EjecutarTransaccionSQLNoIdentity(sqlTarifas);
                    tx.Commit();

                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw new ApplicationException("No se pudo eliminar la definicion de vuelo");
                }
                finally
                {
                    DBHelper.GetDBHelper().CloseConnection();
                }
            }
        }

        public void UpdateDefinicionVuelo(string nroVuelo, List<Tarifa> tarifas)
        {
            try
            {
                foreach (Tarifa tarifa in tarifas)
                {
                    string sql = $"UPDATE TARIFA SET Importe = {tarifa.Importe.ToString().Replace(",", ".")} WHERE IdTipoClase = {tarifa.ObjTipoClase.IdTipoClase} AND NroVuelo = '{nroVuelo}'";
                    DBHelper.GetDBHelper().EjecutarSQL(sql);
                }
            }
            catch (Exception)
            {
                throw new ApplicationException("No se pudo actualizar la definicion de vuelo");
            }
        }

        public List<DefinicionDeVuelo> GetDefinicionVuelo(DefinicionVueloFiltro filtro)
        {

            using (var tx = DBHelper.GetDBHelper().IniciarTransaccion())
            {
                try
                {
                    List<DefinicionDeVuelo> lista = new List<DefinicionDeVuelo>();
                    var sql = $"SELECT DV.*, CO.CodigoCiudad 'CodCiudadOrigen', CD.CodigoCiudad 'CodCiudadDestino' FROM DEFINICION_DE_VUELO DV JOIN AEROPUERTO AO ON AO.CodigoAeropuerto = DV.CodigoAeropuertoOrigen JOIN CIUDAD CO ON CO.CodigoCiudad = AO.CodigoCiudad JOIN AEROPUERTO AD ON AD.CodigoAeropuerto = DV.CodigoAeropuertoDestino JOIN CIUDAD CD ON CD.CodigoCiudad = AD.CodigoCiudad WHERE DV.ACTIVO = 1";
                    if (filtro.nroVuelo != "")
                    {
                        sql += $" AND DV.NroVuelo = '{filtro.nroVuelo}'";
                    }
                    if (filtro.codCiudadOrigen != "")
                    {
                        sql += $" AND CO.CodigoCiudad = '{filtro.codCiudadOrigen}'";
                    }
                    if (filtro.codCiudadDestino != "")
                    {
                        sql += $" AND CD.CodigoCiudad = '{filtro.codCiudadDestino}'";
                    }
                    if (filtro.matriculaAvion != "")
                    {
                        sql += $" AND DV.MatriculaAvion = '{filtro.matriculaAvion}'";
                    }
                    var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
                    foreach (DataRow fila in tablaResultado.Rows)
                    {
                        var defVuelo = MapearDefinicionDeVuelo(fila);
                        lista.Add(defVuelo);
                    }

                    tx.Commit();

                    return lista;

                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw new ApplicationException("No se pudo consultar las definicion de vuelo");
                }
                finally
                {
                    DBHelper.GetDBHelper().CloseConnection();
                }
            }
        }
    }
}
