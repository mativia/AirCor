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
    public partial class FrmAvion : Form
    {
        private readonly AvionServicios avionServicio;
        private readonly ModeloServicios modeloServicios;
        private string matriculaSeleccionada;

        public FrmAvion()
        {
            InitializeComponent();
            avionServicio = new AvionServicios();
            modeloServicios = new ModeloServicios();
            matriculaSeleccionada = "";
        }

        private void LimpiarCampos()
        {
            txtMatricula.Clear();
            cmbModelo.SelectedIndex = -1;
            txtSalidasEmergencia.Clear();
            txtLongitud.Clear();
            txtAlcanceVuelo.Clear();
            txtFilasPC.Clear();
            txtAsientosPC.Clear();
            txtFilasCB.Clear();
            txtAsientosCB.Clear();
            txtFilasCT.Clear();
            txtAsientosCT.Clear();
            txtMatricula.Focus();
            txtMatricula.Enabled = true;
        }

        private void CargarGrilla()
        {
            DataTable tablaAviones = avionServicio.GetAviones();
            dgvAviones.DataSource = tablaAviones;
            dgvAviones.Columns["IdModelo"].Visible = false;
            dgvAviones.Columns["Nombre"].HeaderText = "Modelo";
            dgvAviones.Columns["Nombre"].DisplayIndex = 2;
            dgvAviones.Columns["CantidadSalidasEmergencia"].HeaderText = "Cantidad Salidas Emergencia";
            dgvAviones.Columns["longitud"].HeaderText = "Longitud";
            dgvAviones.Columns["alcanceVuelo"].HeaderText = "Alcance de Vuelo";
            dgvAviones.Columns["filasPC"].HeaderText = "Filas Primera Clase";
            dgvAviones.Columns["asientosPC"].HeaderText = "Asientos Primera Clase";
            dgvAviones.Columns["filasCB"].HeaderText = "Filas Clase Business";
            dgvAviones.Columns["asientosCB"].HeaderText = "Asientos Clase Business";
            dgvAviones.Columns["filasCT"].HeaderText = "Filas Clase Turista";
            dgvAviones.Columns["asientosCT"].HeaderText = "Asientos Clase Turista";

            txtFilasCT.Text = "0";
            txtFilasCB.Text = "0";
            txtFilasPC.Text = "0";
            txtAsientosCB.Text = "0";
            txtAsientosCT.Text = "0";
            txtAsientosPC.Text = "0";

            for (int i = 0; i < dgvAviones.RowCount; i++)
            {
                dgvAviones.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }
        }

        private void CargarComboModelos()
        {
            DataTable tablaModelos = modeloServicios.GetModelos();
            cmbModelo.DataSource = tablaModelos;
            cmbModelo.ValueMember = "IdModelo";
            cmbModelo.DisplayMember = "Nombre";
            cmbModelo.SelectedIndex = -1;
        }

        private void FrmAvion_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            CargarComboModelos();
            dgvAviones.ClearSelection();

            // Hacer que las columnas no se puedan ordenar
            for (int i = 0; i < dgvAviones.ColumnCount; i++)
            {
                dgvAviones.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Avion avion = new Avion()
            {
                Matricula = txtMatricula.Text,
                ObjModelo = new Modelo() { IdModelo = Convert.ToInt32(cmbModelo.SelectedValue) },
                CantidadSalidasEmergencias = txtSalidasEmergencia.Text,
                Longitud = txtLongitud.Text,
                AlcanceVuelo = txtAlcanceVuelo.Text,
                FilasPC = Convert.ToInt32(txtFilasPC.Text),
                AsientosPC = Convert.ToInt32(txtAsientosPC.Text),
                FilasCB = Convert.ToInt32(txtFilasCB.Text), 
                AsientosCB = Convert.ToInt32(txtAsientosCB.Text),
                FilasCT = Convert.ToInt32(txtFilasCT.Text),
                AsientosCT = Convert.ToInt32(txtAsientosCT.Text),
            };


            if (matriculaSeleccionada == "")
            {
                InsertAviones(avion);
            }
            else
            {
                UpdateAviones(avion);
            }
        }

        private void InsertAviones(Avion avion)
        {
            string mensaje = avionServicio.InsertAviones(avion);
            if (mensaje == "")
            {
                MessageBox.Show("El avion se agrego con éxito", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                this.matriculaSeleccionada = "";
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            this.matriculaSeleccionada = "";
            dgvAviones.ClearSelection();
            

            for (int i = 0; i < dgvAviones.RowCount; i++)
            {
                dgvAviones.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }
        }

        private void dgvAviones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMatricula.Enabled = false;

            if (this.matriculaSeleccionada != "")
            {
                for (int i = 0; i < dgvAviones.RowCount; i++)
                {
                    string valor = dgvAviones.Rows[i].Cells["Matricula"].Value.ToString();
                    if (valor == matriculaSeleccionada)
                    {
                        dgvAviones.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
                    }
                }
            }

            if (dgvAviones.Columns[e.ColumnIndex].Name == "ColumnImg")
            {
                int indice = e.RowIndex;
                if (indice >= 0)
                {
                    txtMatricula.Text = dgvAviones.Rows[indice].Cells["Matricula"].Value.ToString();
                    int idModelo = Convert.ToInt32(dgvAviones.Rows[indice].Cells["IdModelo"].Value);
                    cmbModelo.SelectedValue = idModelo;
                    txtSalidasEmergencia.Text = dgvAviones.Rows[indice].Cells["CantidadSalidasEmergencia"].Value.ToString();
                    txtLongitud.Text = dgvAviones.Rows[indice].Cells["longitud"].Value.ToString();
                    txtAlcanceVuelo.Text = dgvAviones.Rows[indice].Cells["alcanceVuelo"].Value.ToString();
                    txtFilasPC.Text = dgvAviones.Rows[indice].Cells["FilasPC"].Value.ToString();
                    txtAsientosPC.Text = dgvAviones.Rows[indice].Cells["AsientosPC"].Value.ToString();
                    txtFilasCB.Text = dgvAviones.Rows[indice].Cells["FilasCB"].Value.ToString();
                    txtAsientosCB.Text = dgvAviones.Rows[indice].Cells["AsientosCB"].Value.ToString();
                    txtFilasCT.Text = dgvAviones.Rows[indice].Cells["FilasCT"].Value.ToString();
                    txtAsientosCT.Text = dgvAviones.Rows[indice].Cells["AsientosCT"].Value.ToString();

                    this.matriculaSeleccionada = dgvAviones.Rows[indice].Cells["Matricula"].Value.ToString();
                    dgvAviones.Rows[indice].Cells["ColumnImg"].Value = Properties.Resources.check_gris_20x20;

                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (matriculaSeleccionada != "")
            {
                DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere eliminar el avion?", "Eliminar avion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultadoDialogo.ToString() == "OK")
                {
                    string mensaje = avionServicio.DeleteAviones(matriculaSeleccionada);
                    if (mensaje == "")
                    {
                        MessageBox.Show("El avion ha sido eliminado", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                        this.matriculaSeleccionada = "";
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
                MessageBox.Show("Debe seleccionar un avion primero", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateAviones(Avion avion)
        {
            DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere modificar el avion?", "Modificar avion", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultadoDialogo.ToString() == "OK")
            {
                string mensaje = avionServicio.UpdateAviones(avion);
                if (mensaje == "")
                {
                    MessageBox.Show("El avion ha sido actualizado", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    this.matriculaSeleccionada = "";
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
