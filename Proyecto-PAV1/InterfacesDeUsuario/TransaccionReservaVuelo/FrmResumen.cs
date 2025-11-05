using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.Servicios;

namespace tp_pav1_grupo10.InterfacesDeUsuario.TransaccionReservaVuelo
{
    public partial class FrmResumen : Form
    {
        private GestorReserva gestor;
        private DefinicionDeVuelo vueloSeleccionado;
        private List<DetalleReserva> listaDetalles;

        public FrmResumen(GestorReserva gestor, List<DetalleReserva> listaDetalles, DefinicionDeVuelo vueloSeleccionado)
        {
            this.gestor = gestor;
            this.vueloSeleccionado = vueloSeleccionado;
            this.listaDetalles = listaDetalles;
            InitializeComponent();
        }

        private void FrmResumen_Load(object sender, EventArgs e)
        {
            CargarGrillaDetalles();
            CargarDatosDeVuelo();
        }

        private void CargarGrillaDetalles()
        {
            float importeTotal = 0;
            foreach (var d in listaDetalles)
            {
                var fila = new string[]
                {
                    d.ObjPasajero.Nombre,
                    d.ObjPasajero.Apellido,
                    "" + d.ObjAsiento.Numero.ToString() + d.ObjAsiento.Letra,
                    d.ObjAsiento.Numero.ToString(),
                    d.ObjAsiento.Letra.ToString(),
                    d.ObjPasajero.ObjTipoDocumento.IdTipoDocumento.ToString(),
                    d.ObjPasajero.NroDocumento,
                    d.ObjAsiento.TipoClase.IdTipoClase.ToString(),
                    d.ObjAsiento.TipoClase.Nombre,
                    "$" + d.Importe.ToString("N2")
                };
                dgvDetalles.Rows.Add(fila);
                importeTotal += d.Importe;
            }
            lblMonto.Text = "$" + importeTotal.ToString("N2");
        }
        
        private void CargarDatosDeVuelo()
        {
            lblNroVuelo.Text += vueloSeleccionado.NroVuelo.ToString();
            lblCiudades.Text = vueloSeleccionado.ObjAeropuertoOrigen.ObjCiudad.Nombre + " - " + vueloSeleccionado.ObjAeropuertoDestino.ObjCiudad.Nombre;
            lblAeropuertos.Text = vueloSeleccionado.ObjAeropuertoOrigen.CodigoAeropuerto + " - " + vueloSeleccionado.ObjAeropuertoDestino.CodigoAeropuerto;
            lblFecha.Text += vueloSeleccionado.ListaVuelos[0].FechaPartida.ToString("dd/MM/yyyy");
            var duracion = vueloSeleccionado.HorarioLlegada - vueloSeleccionado.HorarioPartida;
            lblDuracion.Text += duracion.ToString(@"hh\:mm");
            lblEmbarque.Text += vueloSeleccionado.HorarioEmbarque.ToString("HH:mm");
            lblPartida.Text += vueloSeleccionado.HorarioPartida.ToString("HH:mm");
            lblLlegada.Text += vueloSeleccionado.HorarioLlegada.ToString("HH:mm");
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gestor.InsertReserva();
            MessageBox.Show("La reserva se registro con éxito!", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
            gestor.CerrarVentanas();
        }

        private void FrmResumen_FormClosing(object sender, FormClosingEventArgs e)
        {
            gestor.CancelarTransaccion();
        }
    }
}
