using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using tp_pav1_grupo10.Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace tp_pav1_grupo10.Repositorios
{
    public class ReportesRepositorio
    {
        //Table para listado de vuelos
        public DataTable GetListadoVuelo()
        {
            DateTime diahoy = DateTime.Today;
            string sql = $"SELECT V.IdVuelo, V.NroVuelo, CO.Nombre AS 'CiudadOrigen',  CD.Nombre AS 'CiudadDestino', CONVERT(varchar(10), V.FechaPartida, 103) AS 'FechaPartida', CONVERT(varchar(5), D.HorarioPartida, 108) AS 'HorarioPartida', CONVERT(varchar(5), D.HorarioLlegada - D.HorarioPartida, 108) AS 'Duracion' " +
                "FROM VUELO V " +
                "JOIN DEFINICION_DE_VUELO D ON V.NroVuelo = D.NroVuelo " +
                "JOIN CAMBIO_ESTADO_VUELO CV ON V.IdVuelo = CV.IdVuelo " +
                "JOIN AEROPUERTO AO ON D.CodigoAeropuertoOrigen = AO.CodigoAeropuerto " +
                "JOIN AEROPUERTO AD ON D.CodigoAeropuertoDestino = AD.CodigoAeropuerto " +
                "JOIN CIUDAD CO ON AO.CodigoCiudad = CO.CodigoCiudad " +
                "JOIN CIUDAD CD ON AD.CodigoCiudad = CD.CodigoCiudad " +
                "WHERE CV.IdEstadoVuelo = 1 AND (SELECT COUNT(*) FROM ASIENTO A WHERE A.Estado = 1 AND A.IdVuelo = V.IdVuelo) < (SELECT (A.FilasPC * A.AsientosPC + A.FilasCB * A.AsientosCB + A.FilasCT * A.FilasCT) FROM AVION A WHERE A.Matricula = D.MatriculaAvion) " +
                $"AND V.FechaPartida >= '{diahoy.ToString("s")}' " +
                $"ORDER BY V.FechaPartida";

            DataTable tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);

            return tablaResultado;
        }

        public DataTable GetDestinosPorClases(int TipoClase, DateTime fechaDesde, DateTime fechaHasta)
        { 
            string sql = "SELECT C.CodigoCiudad, COUNT(*) AS 'PasajesVendidos' " +
                "FROM ASIENTO A " +
                "JOIN VUELO V ON A.IdVuelo = V.IdVuelo " +
                "JOIN DEFINICION_DE_VUELO D ON D.NroVuelo = V.NroVuelo " +
                "JOIN AEROPUERTO AD ON AD.CodigoAeropuerto = D.CodigoAeropuertoDestino " +
                "JOIN CIUDAD C ON AD.CodigoCiudad = C.CodigoCiudad " +
                $"WHERE A.IdTipoClase = '{TipoClase}' " +
                $"AND V.FechaPartida BETWEEN CONVERT(datetime, '{fechaDesde.ToString("dd/MM/yyyy")}', 103) AND CONVERT(datetime, '{fechaHasta.ToString("dd/MM/yyyy")}', 103) " +
                "GROUP BY C.CodigoCiudad";
            DataTable tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            return tablaResultado;
        }

        public DataTable GetDestinos(DateTime fechaDesde, DateTime fechaHasta)
        {
            string sql = "SELECT T.Nombre AS 'TipoClase', C.CodigoCiudad + ' ' + C.Nombre AS 'Destino', COUNT(*) AS 'PasajesVendidos' " +
                "FROM ASIENTO A " +
                "JOIN VUELO V ON A.IdVuelo = V.IdVuelo " +
                "JOIN TIPO_CLASE T ON A.IdTipoClase = T.IdTipoClase " +
                "JOIN DEFINICION_DE_VUELO D ON D.NroVuelo = V.NroVuelo " +
                "JOIN AEROPUERTO AD ON AD.CodigoAeropuerto = D.CodigoAeropuertoDestino " +
                "JOIN CIUDAD C ON AD.CodigoCiudad = C.CodigoCiudad " +
                $"WHERE V.FechaPartida BETWEEN CONVERT(datetime, '{fechaDesde.ToString("dd/MM/yyyy")}', 103) AND CONVERT(datetime, '{fechaHasta.ToString("dd/MM/yyyy")}', 103) " +
                "GROUP BY C.CodigoCiudad, C.Nombre, A.IdTipoClase, T.Nombre " +
                "ORDER BY TipoClase, PasajesVendidos desc";
            DataTable tablaResultado = DBHelper.GetDBHelper().ConsultaSQL(sql);
            return tablaResultado;
        }

    }
}
