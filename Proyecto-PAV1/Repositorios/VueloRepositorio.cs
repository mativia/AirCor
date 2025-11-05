using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp_pav1_grupo10.Entidades;
using System.Data;

namespace tp_pav1_grupo10.Repositorios
{

    public class VueloRepositorio
    {
        private readonly TarifaRepositorio tarifaRepositorio;

        public VueloRepositorio()
        {
            tarifaRepositorio = new TarifaRepositorio();
        }

        public List<DefinicionDeVuelo> GetListaDeVuelosDisponibles(string codAeropuertoOrigen, string codAeropuertoDestino, DateTime fechaPartida)
        {
            try
            {
                var lista = new List<DefinicionDeVuelo>();
                var sql = $"SELECT V.IdVuelo, V.NroVuelo, CO.Nombre AS 'CiudadOrigen', AO.CodigoAeropuerto AS 'CodAeropuertoOrigen', CD.Nombre AS 'CiudadDestino', AD.CodigoAeropuerto AS 'CodAeropuertoDestino', V.FechaPartida, CONVERT(varchar(5), D.HorarioPartida, 108) AS 'HorarioPartida', CONVERT(varchar(5), D.HorarioLlegada, 108) AS 'HorarioLlegada', CONVERT(varchar(5), D.HorarioEmbarque, 108) AS 'HorarioEmbarque', AO.Nombre AS 'NomAeropuertoOrigen', AD.Nombre AS 'NomAeropuertoDestino' FROM VUELO V JOIN DEFINICION_DE_VUELO D ON V.NroVuelo = D.NroVuelo JOIN CAMBIO_ESTADO_VUELO CV ON V.IdVuelo = CV.IdVuelo JOIN AEROPUERTO AO ON D.CodigoAeropuertoOrigen = AO.CodigoAeropuerto JOIN AEROPUERTO AD ON D.CodigoAeropuertoDestino = AD.CodigoAeropuerto JOIN CIUDAD CO ON AO.CodigoCiudad = CO.CodigoCiudad JOIN CIUDAD CD ON AD.CodigoCiudad = CD.CodigoCiudad WHERE CV.IdEstadoVuelo = 1 AND CV.FechaHoraHasta IS NULL AND (SELECT COUNT(*) FROM ASIENTO A WHERE A.Estado = 1 AND A.IdVuelo = V.IdVuelo) < (SELECT (A.FilasPC * A.AsientosPC + A.FilasCB * A.AsientosCB + A.FilasCT * A.FilasCT) FROM AVION A WHERE A.Matricula = D.MatriculaAvion)";
                if (codAeropuertoOrigen != "")
                {
                    sql += $" AND AO.CodigoAeropuerto = '{codAeropuertoOrigen}'";
                }
                if (codAeropuertoDestino != "")
                {
                    sql += $" AND AD.CodigoAeropuerto = '{codAeropuertoDestino}'";
                }
                if (fechaPartida.Date != DateTime.Today.AddDays(-1))
                {
                    sql += $" AND V.FechaPartida = '{fechaPartida.ToString("s")}'";
                }
                else
                {
                    sql += $" AND V.FechaPartida >= '{DateTime.Today.ToString("s")}'";
                }

                var tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
                foreach (DataRow fila in tablaResultado.Rows)
                {
                    var defVuelo = MapearVuelos(fila);
                    lista.Add(defVuelo);
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error al consultar vuelos: " + ex.Message, ex);
            }

        }

        private DefinicionDeVuelo MapearVuelos(DataRow fila)
        {
            var vuelo = new Vuelo();
            vuelo.IdVuelo = Convert.ToInt32(fila["IdVuelo"]);
            vuelo.FechaPartida = Convert.ToDateTime(fila["FechaPartida"]);

            var defVuelo = new DefinicionDeVuelo();
            defVuelo.NroVuelo = fila["NroVuelo"].ToString();
            defVuelo.HorarioEmbarque = Convert.ToDateTime(fila["HorarioEmbarque"].ToString());
            defVuelo.HorarioLlegada = Convert.ToDateTime(fila["HorarioLlegada"].ToString());
            defVuelo.HorarioPartida = Convert.ToDateTime(fila["HorarioPartida"].ToString());

            defVuelo.ListaVuelos = new List<Vuelo>();
            defVuelo.ListaVuelos.Add(vuelo);

            defVuelo.ObjAeropuertoOrigen = new Aeropuerto()
            {
                CodigoAeropuerto = fila["CodAeropuertoOrigen"].ToString(),
                Nombre = fila["NomAeropuertoOrigen"].ToString(),
                ObjCiudad = new Ciudad()
                {
                    Nombre = fila["CiudadOrigen"].ToString()

                }
            };
            defVuelo.ObjAeropuertoDestino = new Aeropuerto()
            {
                CodigoAeropuerto = fila["CodAeropuertoDestino"].ToString(),
                Nombre = fila["NomAeropuertoDestino"].ToString(),
                ObjCiudad = new Ciudad()
                {
                    Nombre = fila["CiudadDestino"].ToString()
                }
            };

            var listaTarifas = new List<Tarifa>();
            listaTarifas = tarifaRepositorio.GetTarifasDeVuelo(defVuelo.NroVuelo);
            defVuelo.ListaTarifas = listaTarifas;

            return defVuelo;
        }

    }
}
