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
using tp_pav1_grupo10.InterfacesDeUsuario.Reportes.EstadisticoDestinoPorClase;
using tp_pav1_grupo10.InterfacesDeUsuario.Reportes.ListadoVuelos;
using tp_pav1_grupo10.Servicios;

namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    public partial class MenuPrincipal : Form
    {
        private Login frmLogin;
        private readonly PermisoServicios permisoServicios;
        public MenuPrincipal(Login login)
        {
            frmLogin = login;
            permisoServicios = new PermisoServicios();
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            HabilitarMenus();
            lblUsuLogueado.Text = $"Usuario: {UsuarioServicios.UsuarioLogueado.Nombre}";
            lblPerfil.Text = $"Perfil: {UsuarioServicios.UsuarioLogueado.ObjPerfil.Nombre}";
            imiInformeDetalladoVuelo.Visible = false;
            imiConsultarEstados.Visible = false;
            imiConsultarReserva.Visible = false;

        }

        private void HabilitarMenus()
        {
            int idPerfil = UsuarioServicios.UsuarioLogueado.ObjPerfil.IdPerfil;
            List <Permiso> listaPermisos = permisoServicios.GetListaPermisos(idPerfil);
            foreach (var permiso in listaPermisos)
            {
                switch (permiso.NombreMenuHabilitado)
                {
                    case "Seguridad":
                        imiSeguridad.Enabled = true;
                        break;
                    case "Reportes":
                        imiReportes.Enabled = true;
                        break;
                    case "PlanificarVuelos":
                        imiVuelos.Enabled = true;
                        imiPlanificarVuelos.Enabled = true;
                        break;
                    case "EstadoVuelos":
                        imiVuelos.Enabled = true;
                        imiConsultarEstados.Enabled = true;
                        break;
                    case "Registros":
                        imiRegistros.Enabled = true;
                        break;
                    case "Reservas":
                        imiReservas.Enabled = true;
                        break;
                    default:
                        break;
                }
            }

        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void imiReportes_Click(object sender, EventArgs e)
        {

        }

        private void imiVuelos_Click(object sender, EventArgs e)
        {

        }

        private void imiPlanificarVuelos_Click(object sender, EventArgs e)
        {
            FrmDefinicionVuelo ventana = new FrmDefinicionVuelo();
            ventana.ShowDialog();
        }

        private void imiConsultarEstados_Click(object sender, EventArgs e)
        {

        }

        private void imiPerfiles_Click(object sender, EventArgs e)
        {

        }

        private void imiSeguridad_Click(object sender, EventArgs e)
        {

        }

        private void imiRegistros_Click(object sender, EventArgs e)
        {

        }

        private void imiPaises_Click(object sender, EventArgs e)
        {
            FrmPais ventana = new FrmPais();
            ventana.ShowDialog();
        }

        private void imiCiudades_Click(object sender, EventArgs e)
        {
            FrmCiudad ventana = new FrmCiudad();
            ventana.ShowDialog();
        }

        private void imiProvincias_Click(object sender, EventArgs e)
        {
            FrmProvincia ventana = new FrmProvincia();
            ventana.ShowDialog();
        }

        private void imiAeropuertos_Click(object sender, EventArgs e)
        {
            FrmAeropuertos ventana = new FrmAeropuertos();
            ventana.ShowDialog();
        }

        private void imiAviones_Click(object sender, EventArgs e)
        {
            FrmAvion ventana = new FrmAvion();
            ventana.ShowDialog();
        }

        private void imiEmpleados_Click(object sender, EventArgs e)
        {
            FrmEmpleados ventana = new FrmEmpleados();
            ventana.ShowDialog();
           
        }

        private void imiUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void imiReservas_Click(object sender, EventArgs e)
        {

        }

        private void imiRegistrarReserva_Click(object sender, EventArgs e)
        {
            GestorReserva gestorReserva = new GestorReserva();
            gestorReserva.SeleccionDeVuelo();
        }

        private void imiConsultarReserva_Click(object sender, EventArgs e)
        {

        }

        private void imiEstadisticaPasajes_Click(object sender, EventArgs e)
        {
            FrmDestinoPorClase ventana = new FrmDestinoPorClase();
            ventana.ShowDialog();

        }

        private void imiInformeVuelos_Click(object sender, EventArgs e)
        {
            FrmInformeVuelos ventana = new FrmInformeVuelos();
            ventana.ShowDialog();
        }

        private void imiInformeDetalladoVuelo_Click(object sender, EventArgs e)
        {

        }

        private void iconMenuItem3_Click(object sender, EventArgs e)
        {
            frmLogin.Show();
            frmLogin.LimpiarCampos();
            this.Dispose();

        }

        private void iconMenuItem2_Click(object sender, EventArgs e)
        {
            FrmUsuarios ventana = new FrmUsuarios();
            ventana.ShowDialog();
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmLogin.Close();
        }

        private void imiPasajeros_Click(object sender, EventArgs e)
        {
            FrmPasajeros ventana = new FrmPasajeros();
            ventana.ShowDialog();
        }

        private void iconMenuItem1_Click_1(object sender, EventArgs e)
        {
            FrmPerfiles ventana = new FrmPerfiles();
            ventana.ShowDialog();
        }
    }
}
