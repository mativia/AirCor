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
using tp_pav1_grupo10.Servicios;

namespace tp_pav1_grupo10.InterfacesDeUsuario.Reportes.EstadisticoDestinoPorClase
{
    public partial class FrmDestinoPorClase : Form
    {
        private readonly ReporteServicios reporteServicios;

        public FrmDestinoPorClase()
        {
            InitializeComponent();
            reporteServicios = new ReporteServicios();
        }

        private void FrmDestinoPorClase_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            dtpFechaDesde.Value = Convert.ToDateTime("1/1/2022");
            dtpFechaHasta.Value = Convert.ToDateTime("1/1/2022");
            dtpFechaDesde.Enabled = false;
            dtpFechaHasta.Enabled = false;
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void CargarReporte()
        {
            reportViewer1.LocalReport.DataSources.Clear();
            DataTable tabla = new DataTable();
            DataTable tabla2 = new DataTable();
            DataTable tabla3 = new DataTable();
            DataTable destinos = new DataTable();

            DateTime fechaDesde;
            DateTime fechaHasta;

            if (chkHabilitarFecha.Checked == true)
            {
                fechaDesde = dtpFechaDesde.Value;
                fechaHasta = dtpFechaHasta.Value;
            }
            else
            {
                fechaDesde = Convert.ToDateTime("1/1/2022");
                fechaHasta = fechaDesde.AddYears(100);
            }
            tabla = reporteServicios.GetDestinosPorClase(1, fechaDesde, fechaHasta);
            tabla2 = reporteServicios.GetDestinosPorClase(2, fechaDesde, fechaHasta);
            tabla3 = reporteServicios.GetDestinosPorClase(3, fechaDesde, fechaHasta);
            destinos = reporteServicios.GetDestinos(fechaDesde, fechaHasta);


            ReportDataSource ds = new ReportDataSource("Clase1DS", tabla);
            ReportDataSource ds2 = new ReportDataSource("Clase2DS", tabla2);
            ReportDataSource ds3 = new ReportDataSource("Clase3DS", tabla3);
            ReportDataSource dsDestinos = new ReportDataSource("DestinosGeneral", destinos);

            
            reportViewer1.LocalReport.DataSources.Add(ds);
            reportViewer1.LocalReport.DataSources.Add(ds2);
            reportViewer1.LocalReport.DataSources.Add(ds3);
            reportViewer1.LocalReport.DataSources.Add(dsDestinos);
            reportViewer1.RefreshReport();
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                MessageBox.Show("La fecha hasta debe ser mayor a la fecha desde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFechaDesde.Value = Convert.ToDateTime("1/1/2022");
                dtpFechaHasta.Value = Convert.ToDateTime("1/1/2022");
            }
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                MessageBox.Show("La fecha hasta debe ser mayor a la fecha desde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFechaDesde.Value = Convert.ToDateTime("1/1/2022");
                dtpFechaHasta.Value = Convert.ToDateTime("1/1/2022");
            }
        }

        private void chkHabilitarFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHabilitarFecha.Checked)
            {
                dtpFechaDesde.Enabled = true;
                dtpFechaHasta.Enabled = true;
            }
            else
            {
                dtpFechaDesde.Enabled = false;
                dtpFechaHasta.Enabled = false;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarReporte();
        }
    }
}
