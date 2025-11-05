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
    public partial class FrmCiudad : Form
    {
        private readonly CiudadServicios ciudadServicios;
        private readonly PaisServicios paisServicios;
        private readonly ProvinciaServicios provinciaServicios;
        private string codCiudad;
        public FrmCiudad()
        {
            InitializeComponent();
            ciudadServicios = new CiudadServicios();
            paisServicios = new PaisServicios();
            provinciaServicios = new ProvinciaServicios();
            codCiudad = "";
        }

        private void FrmCiudad_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            dgvCiudades.ClearSelection();
            // nombre de columnas
            dgvCiudades.Columns["CodigoCiudad"].HeaderText = "Codigo Ciudad";
            dgvCiudades.Columns["NombreCiudad"].HeaderText = "Nombre Ciudad";
            dgvCiudades.Columns["NombreProvincia"].HeaderText = "Nombre Provincia";
            dgvCiudades.Columns["NombrePais"].HeaderText = "Nombre Pais";

            //ocultar idpais e idprovincia
            dgvCiudades.Columns["IdPais"].Visible = false;
            dgvCiudades.Columns["IdProvincia"].Visible = false;
            CargarPaises();
            lblIdCiudad.Text = this.codCiudad.ToString();

            // Hacer que las columnas no se puedan ordenar
            for (int i = 0; i < dgvCiudades.ColumnCount; i++)
            {
                dgvCiudades.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void LimpiarCampos()
        {
            txtCodigoCiudad.Clear();
            txtNombre.Clear();
            cmbPais.SelectedValue = -1;
            cmbProvincia.SelectedValue = -1;
            lblProvincia.Enabled = false;
            cmbProvincia.Enabled = false;
            lblCodigoCiudad.Enabled = true;
            txtCodigoCiudad.Enabled = true;
        }

        private void CargarGrilla()
        {
            DataTable tablaCiudad = ciudadServicios.GetCiudades();
            dgvCiudades.DataSource = tablaCiudad;

            for (int i = 0; i < dgvCiudades.RowCount; i++)
            {
                dgvCiudades.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }
        }

        private void CargarPaises()
        {
            List<Pais> listaPaises = paisServicios.GetPaises();
            cmbPais.DataSource = listaPaises;
            cmbPais.DisplayMember = "Nombre";
            cmbPais.ValueMember = "IdPais";
            cmbPais.SelectedValue = -1;
        }

        private void CargarProvincias()
        {
            int idPais = Convert.ToInt32(cmbPais.SelectedValue);
            DataTable tablaProvincias = provinciaServicios.GetProvinciasDelPais(idPais);
            cmbProvincia.DataSource = tablaProvincias;
            cmbProvincia.DisplayMember = "Nombre";
            cmbProvincia.ValueMember = "IdProvincia";
            cmbProvincia.SelectedValue = -1;
        }

        private void InsertarCiudad(Ciudad ciudad, int idProvincia)
        {
            string mensaje = ciudadServicios.InsertCiudades(ciudad, idProvincia);
            if (mensaje == "")
            {
                MessageBox.Show("La ciudad se agrego con éxito", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                this.codCiudad = "";
                lblIdCiudad.Text = codCiudad;
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCiudad(Ciudad ciudad, int idProvincia)
        {
            DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere modificar la ciudad?", "Modificar ciudad", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultadoDialogo.ToString() == "OK")
            {
                string mensaje = ciudadServicios.UpdateCiudades(codCiudad, ciudad, idProvincia);
                if (mensaje == "")
                {
                    MessageBox.Show("La ciudad ha sido actualizada", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    this.codCiudad = "";
                    lblIdCiudad.Text = codCiudad;
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // rellenar el combo de provincias filtrando las provincias del pais seleccionado
        private void cmbPais_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbPais.SelectedValue) != -1)
            {
                lblProvincia.Enabled = true;
                cmbProvincia.Enabled = true;
                CargarProvincias();
            }
        }

        // Insert y update de ciudades
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Ciudad ciudad = new Ciudad()
            {
                CodigoCiudad = txtCodigoCiudad.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
            };
            int idProvincia = Convert.ToInt32(cmbProvincia.SelectedValue);

            if (codCiudad == "")
            {
                InsertarCiudad(ciudad, idProvincia);
            }
            else
            {
                UpdateCiudad(ciudad, idProvincia);
            }
            

        }

        // limpiar las selecciones del usuario
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            codCiudad = "";
            lblIdCiudad.Text = codCiudad;
            dgvCiudades.ClearSelection();
            // modificaciones para hacer blanca la imagen por defecto
            for (int i = 0; i < dgvCiudades.RowCount; i++)
            {
                dgvCiudades.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }
            

        }

        // SELECCION DE CIUDADES EN LA GRILLA
        private void dgvCiudades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (codCiudad != "")
            {
                for (int i = 0; i < dgvCiudades.RowCount; i++)
                {
                    string valor = dgvCiudades.Rows[i].Cells["CodigoCiudad"].Value.ToString();
                    if (valor == codCiudad)
                    {
                        dgvCiudades.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
                    }
                }
            }

            int indice = e.RowIndex; // obtengo el indice de la fila seleccionada
            if (indice >= 0)
            {
                // activar combo provincias
                lblProvincia.Enabled = true;
                cmbProvincia.Enabled = true;

                // desactivar txtbox y lbl codigociudad
                lblCodigoCiudad.Enabled = false;
                txtCodigoCiudad.Enabled = false;

                // cargar los textbox y combos
                txtNombre.Text = dgvCiudades.Rows[indice].Cells["NombreCiudad"].Value.ToString();
                txtCodigoCiudad.Text = dgvCiudades.Rows[indice].Cells["CodigoCiudad"].Value.ToString();
                cmbPais.SelectedValue = dgvCiudades.Rows[indice].Cells["IdPais"].Value;

                // primero cargamos el combo con las provincias del pais, y luego cargamos la provincia seleccionada
                CargarProvincias();
                cmbProvincia.SelectedValue = dgvCiudades.Rows[indice].Cells["IdProvincia"].Value;

                this.codCiudad = dgvCiudades.Rows[indice].Cells["CodigoCiudad"].Value.ToString().Trim();
                lblIdCiudad.Text = codCiudad.ToString();

                dgvCiudades.Rows[indice].Cells["ColumnImg"].Value = Properties.Resources.check_gris_20x20;
            }
        }

        // eliminado de ciudades
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (codCiudad != "")
            {
                DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere eliminar la ciudad?", "Eliminar ciudad", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultadoDialogo.ToString() == "OK")
                {
                    string mensaje = ciudadServicios.DeleteCiudades(codCiudad);
                    if (mensaje == "")
                    {
                        MessageBox.Show("La ciudad ha sido eliminada", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                        this.codCiudad = "";
                        lblIdCiudad.Text = codCiudad;
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
                MessageBox.Show("Debe seleccionar una ciudad primero", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
