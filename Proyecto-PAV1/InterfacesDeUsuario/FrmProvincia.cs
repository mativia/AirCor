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
using tp_pav1_grupo10.Entidades;

namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    public partial class FrmProvincia : Form
    {
        private readonly PaisServicios paisServicio;
        private readonly ProvinciaServicios provinciaServicios;
        private int idProvincia;
        public FrmProvincia()
        {
            InitializeComponent();
            paisServicio = new PaisServicios();
            provinciaServicios = new ProvinciaServicios();
            idProvincia = 0;
        }

        private void FrmProvincia_Load(object sender, EventArgs e)
        {
            CargarComboPaises();
            CargarGrilla();
            dgvProvincias.Columns["NombreProvincia"].HeaderText = "Nombre Provincia";
            dgvProvincias.Columns["NombrePais"].HeaderText = "Nombre Pais";

            // Hacer que las columnas no se puedan ordenar
            for (int i = 0; i < dgvProvincias.ColumnCount; i++)
            {
                dgvProvincias.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void CargarComboPaises()
        {
            List<Pais> listaPaises = paisServicio.GetPaises();
            cmbPais.DataSource = listaPaises;
            cmbPais.DisplayMember = "Nombre";
            cmbPais.ValueMember = "IdPais";
            cmbPais.SelectedIndex = -1;
        }

        private void CargarGrilla()
        {
            DataTable tablaProvincia = provinciaServicios.GetProvincias();
            dgvProvincias.DataSource = tablaProvincia;
            dgvProvincias.Columns["IdProvincia"].Visible = false;
            dgvProvincias.Columns["IdPais"].Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Provincia provincia = new Provincia()
            {
                Nombre = txtNombre.Text.ToString().Trim(),
                IdProvincia = this.idProvincia
            };
            int idPais = Convert.ToInt32(cmbPais.SelectedValue);

            if (idProvincia == 0)
            {
                InsertarProvincia(provincia, idPais);
            }
            else
            {
                UpdateProvincia(provincia, idPais);
            }
        }

        void InsertarProvincia(Provincia provincia, int idPais)
        {
            string mensaje = provinciaServicios.InsertProvincias(provincia, idPais);
            if (mensaje == "")
            { 
                MessageBox.Show("La provincia se agrego con éxito", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Funcion a utilizar en la Baja , Modificacion y Limpieza
        private void LimpiarCampos()
        {
            txtNombre.Clear();
            cmbPais.SelectedValue = -1;
            this.idProvincia = 0;
        }

 
        //Eliminar provincia
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idProvincia != 0)
            {
                DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere eliminar la provincia?", "Eliminar provincia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultadoDialogo.ToString() == "OK")
                {
                    string mensaje = provinciaServicios.DeleteProvincias(idProvincia);
                    if (mensaje == "")
                    {
                        MessageBox.Show("La provincia ha sido eliminada", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
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
                MessageBox.Show("Debe seleccionar una provincia primero", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Limpiar campos de provincia
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            dgvProvincias.ClearSelection();
            // modificaciones para hacer blanca la imagen por defecto
            for (int i = 0; i < dgvProvincias.RowCount; i++)
            {
                dgvProvincias.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }
        }

        //Modificacion de provincia
        private void UpdateProvincia(Provincia provincia, int idPais)
        {
            DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere modificar la provincia?", "Modificar provincia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultadoDialogo.ToString() == "OK")
            {
                string mensaje = provinciaServicios.UpdateProvincias(provincia, idPais);
                if (mensaje == "")
                {
                    MessageBox.Show("La Provincia ha sido actualizado", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    this.idProvincia = 0;
                    lbldProvincia.Text = idProvincia.ToString();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Seleccion de Pais para la provincia
        private void dgvProvincias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (idProvincia != 0)
            {
                // COLOCO EL CHECK ANTERIOR EN BLANCO, TENGO EL ID DE LA PROVINCIA QUE ESTABA SELECCIONADA ANTES
                // PERO NECESITO SU UBICACIÓN EN LA GRILLA
                for (int i = 0; i < dgvProvincias.RowCount; i++)
                {
                    int valor = Convert.ToInt32(dgvProvincias.Rows[i].Cells["IdProvincia"].Value);
                    if (valor == idProvincia)
                    {
                        dgvProvincias.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
                    }
                }
            }

            if (dgvProvincias.Columns[e.ColumnIndex].Name == "ColumnImg")
            {
                int indice = e.RowIndex; // obtengo el indice de la fila seleccionada
                if (indice >= 0)
                {
                    txtNombre.Text = dgvProvincias.Rows[indice].Cells["NombreProvincia"].Value.ToString();
                    this.idProvincia = Convert.ToInt32(dgvProvincias.Rows[indice].Cells["IdProvincia"].Value.ToString().Trim());
                    lbldProvincia.Text = idProvincia.ToString();

                    dgvProvincias.Rows[indice].Cells["ColumnImg"].Value = Properties.Resources.check_gris_20x20;

                    txtNombre.Text = dgvProvincias.Rows[indice].Cells["NombreProvincia"].Value.ToString(); // Cargar el combo pais para la provincia
                    cmbPais.SelectedValue = dgvProvincias.Rows[indice].Cells["IdPais"].Value;
                }
            }
        }
    }
}
