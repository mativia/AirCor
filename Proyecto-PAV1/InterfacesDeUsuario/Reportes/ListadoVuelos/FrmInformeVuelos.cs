using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp_pav1_grupo10.Repositorios;
using tp_pav1_grupo10.Servicios;

namespace tp_pav1_grupo10.InterfacesDeUsuario.Reportes.ListadoVuelos
{
    public partial class FrmInformeVuelos : Form
    {
        private readonly ReporteServicios reporteServicios;
        public FrmInformeVuelos()
        {
            InitializeComponent();
            reporteServicios = new ReporteServicios();
        }

        private void FrmInformeVuelos_Load(object sender, EventArgs e)
        {

            this.rwListadoVuelos.RefreshReport();
        }

        private void rwListadoVuelos_Load(object sender, EventArgs e)
        {
            DataTable tabla = new DataTable();
            tabla = reporteServicios.GetListadoVuelos();
            ReportDataSource ds = new ReportDataSource("DataSet1", tabla);

            DateTime hoy = DateTime.Today;
            var parametros = new List<ReportParameter>() {
                new ReportParameter("FechaActual", hoy.ToString("dd/MM/yyyy")),
            };

            rwListadoVuelos.LocalReport.SetParameters(parametros);
            rwListadoVuelos.LocalReport.DataSources.Clear();
            rwListadoVuelos.LocalReport.DataSources.Add(ds);
            rwListadoVuelos.LocalReport.Refresh();
        }
    }
}
