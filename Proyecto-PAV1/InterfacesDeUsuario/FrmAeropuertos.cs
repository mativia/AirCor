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

namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    public partial class FrmAeropuertos : Form
    {
        private readonly AeropuertoServicios aeropuertoServicios;
        private readonly CiudadServicios ciudadServicios;
        private string idAeropuerto;

        public FrmAeropuertos()
        {
            InitializeComponent();
            aeropuertoServicios = new AeropuertoServicios();
            ciudadServicios = new CiudadServicios();
            idAeropuerto = "";
            txtNombreAeropuerto.Focus();
        }
        private void LimpiarCampos()
        {
            txtNombreAeropuerto.Clear();
            txtCodigo.Clear();
            txtCalle.Clear();
            txtNroCalle.Clear();
            txtTelefono.Clear();
            cmbCiudad.SelectedValue = -1;
            txtCodigo.Enabled = true;
            lblCodigo.Enabled = true;
        }

        private void CargarGrilla()
        {
            DataTable tablaAeropuerto = aeropuertoServicios.GetAeropuerto();
            dgvAeropuerto.DataSource = tablaAeropuerto;
            dgvAeropuerto.Columns["Activo"].Visible = false;

            for (int i = 0; i < dgvAeropuerto.RowCount; i++)
            {
                dgvAeropuerto.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }

        }

        private void CargarComboCiudad()
        {
            DataTable tablaPaises = new DataTable();
            tablaPaises = ciudadServicios.GetCiudades();
            cmbCiudad.DataSource = tablaPaises;
            cmbCiudad.DisplayMember = "NombreCiudad";
            cmbCiudad.ValueMember = "CodigoCiudad";
            cmbCiudad.SelectedIndex = -1;
        }

        private void InsertarAeropuerto(Aeropuerto aeropuerto, string codigoCiudad)
        {
            string mensaje = aeropuertoServicios.InsertAeropuerto(aeropuerto, codigoCiudad);
            if (mensaje == "")
            {
                MessageBox.Show("El Aeropuerto se agrego con éxito", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                this.idAeropuerto = "";
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateAeropuerto(Aeropuerto aeropuerto, string codCiudad)
        {
            DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere modificar el aeropuerto?", "Modificar aeropuerto", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultadoDialogo.ToString() == "OK")
            {
                string mensaje = aeropuertoServicios.UpdateAeropuerto(aeropuerto, codCiudad);
                if (mensaje == "")
                {
                    MessageBox.Show("El aeropuerto ha sido actualizado", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    this.idAeropuerto = "";
                    lblIdAeropuerto.Text = idAeropuerto;
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            idAeropuerto = "";
            lblIdAeropuerto.Text = idAeropuerto;
            dgvAeropuerto.ClearSelection();
            // modificaciones para hacer blanca la imagen por defecto
            for (int i = 0; i < dgvAeropuerto.RowCount; i++)
            {
                dgvAeropuerto.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }
            txtNombreAeropuerto.Focus();
        }

        private void FrmAeropuertos_Load(object sender, EventArgs e)
        {
            CargarComboCiudad();
            CargarGrilla();
            dgvAeropuerto.ClearSelection();
            // nombre de columnas
            dgvAeropuerto.Columns["CodigoAeropuerto"].HeaderText = "Codigo Aeropuerto";
            dgvAeropuerto.Columns["Nombre"].HeaderText = "Nombre";
            dgvAeropuerto.Columns["Calle"].HeaderText = "Calle";
            dgvAeropuerto.Columns["NroCalle"].HeaderText = "Numero Calle";
            dgvAeropuerto.Columns["Telefono"].HeaderText = "Numero Telefono";
            dgvAeropuerto.Columns["CodigoCiudad"].HeaderText = "Codigo Ciudad";
            dgvAeropuerto.Columns["NombreCiudad"].HeaderText = "Nombre Ciudad";
            
            lblIdAeropuerto.Text = this.idAeropuerto.ToString();

            // Hacer que las columnas no se puedan ordenar
            for (int i = 0; i < dgvAeropuerto.ColumnCount; i++)
            {
                dgvAeropuerto.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void dgvAeropuerto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (idAeropuerto != "")
            {
                // COLOCO EL CHECK ANTERIOR EN BLANCO, TENGO EL ID DEL PAIS QUE ESTABA SELECCIONADO ANTES
                // PERO NECESITO SU UBICACIÓN EN LA GRILLA
                for (int i = 0; i < dgvAeropuerto.RowCount; i++)
                {
                    string valor = dgvAeropuerto.Rows[i].Cells["CodigoAeropuerto"].Value.ToString();
                    if (valor == idAeropuerto)
                    {
                        dgvAeropuerto.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
                    }
                }
            }

            if (dgvAeropuerto.Columns[e.ColumnIndex].Name == "ColumnImg")
            {
                int indice = e.RowIndex; // obtengo el indice de la fila seleccionada
                if (indice >= 0)
                {
                    // desactivar txtbox y lbl codigociudad
                    lblCodigo.Enabled = false;
                    txtCodigo.Enabled = false;

                    // cambiar los textbox y combos
                    txtNombreAeropuerto.Text = dgvAeropuerto.Rows[indice].Cells["Nombre"].Value.ToString();
                    txtCodigo.Text = dgvAeropuerto.Rows[indice].Cells["CodigoAeropuerto"].Value.ToString();
                    txtCalle.Text = dgvAeropuerto.Rows[indice].Cells["Calle"].Value.ToString();
                    txtNroCalle.Text = dgvAeropuerto.Rows[indice].Cells["NroCalle"].Value.ToString();
                    txtTelefono.Text = dgvAeropuerto.Rows[indice].Cells["Telefono"].Value.ToString();

                    cmbCiudad.SelectedValue = dgvAeropuerto.Rows[indice].Cells["CodigoCiudad"].Value;

                    this.idAeropuerto = dgvAeropuerto.Rows[indice].Cells["CodigoAeropuerto"].Value.ToString().Trim();
                    lblIdAeropuerto.Text = idAeropuerto.ToString();

                    dgvAeropuerto.Rows[indice].Cells["ColumnImg"].Value = Properties.Resources.check_gris_20x20;

                }
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            Aeropuerto aeropuerto = new Aeropuerto()
            {
                CodigoAeropuerto = txtCodigo.Text.Trim(),
                Nombre = txtNombreAeropuerto.Text.Trim(),
                Calle = txtCalle.Text.Trim(),
                NroCalle = txtNroCalle.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
            };
            string codigoCiudad = Convert.ToString(cmbCiudad.SelectedValue);
            if (idAeropuerto == "")
            {
                InsertarAeropuerto(aeropuerto, codigoCiudad);
            }
            else
            {
                UpdateAeropuerto(aeropuerto, codigoCiudad);
            }
            txtNombreAeropuerto.Focus();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (idAeropuerto != "")
            {
                DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere eliminar el aeropuerto?", "Eliminar aeropuerto", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultadoDialogo.ToString() == "OK")
                {
                    string mensaje = aeropuertoServicios.DeleteAeropuerto(idAeropuerto);
                    if (mensaje == "")
                    {
                        MessageBox.Show("El aeropuerto ha sido eliminado", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                        this.idAeropuerto = "";
                        lblIdAeropuerto.Text = idAeropuerto;
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un aeropuerto primero", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtNombreAeropuerto.Focus();
        }
    }
}
