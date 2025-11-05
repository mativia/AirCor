using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using tp_pav1_grupo10.Repositorios;

namespace tp_pav1_grupo10.Servicios
{
    public class ReporteServicios
    {
        private readonly ReportesRepositorio reporteRepositorio;

        public ReporteServicios()
        { 
            reporteRepositorio = new ReportesRepositorio();
        }

        public DataTable GetListadoVuelos()
        { 
          return reporteRepositorio.GetListadoVuelo();
        }

        public DataTable GetDestinosPorClase(int TipoClase, DateTime fechaDesde, DateTime fechaHasta)
        {
            return reporteRepositorio.GetDestinosPorClases(TipoClase, fechaDesde, fechaHasta);
        }

        public DataTable GetDestinos(DateTime fechaDesde, DateTime fechaHasta)
        {
            return reporteRepositorio.GetDestinos(fechaDesde, fechaHasta);
        }


    }
}
