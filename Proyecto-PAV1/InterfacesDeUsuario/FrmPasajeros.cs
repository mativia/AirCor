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
    public partial class FrmPasajeros : Form
    {
        private readonly PaisServicios paisServicios;
        private readonly PasajeroServicios pasajeroServicios;
        private readonly TipoDocumentoServicios tipoDocumentoServicios;
        private string documento = "";
        private int idTipoDocumento = 0;

        public FrmPasajeros()
        {
            InitializeComponent();
            paisServicios = new PaisServicios();
            pasajeroServicios = new PasajeroServicios();
            tipoDocumentoServicios = new TipoDocumentoServicios();
        }

        private void FrmPasajeros_Load(object sender, EventArgs e)
        {
            dtpFechaNacimiento.MaxDate = DateTime.Today;
            CargarComboNacionalidades();
            CargarComboTipoDocumento();
            CargarGrilla();

            // Hacer que las columnas no se puedan ordenar
            for (int i = 0; i < dgvPasajeros.ColumnCount; i++)
            {
                dgvPasajeros.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void CargarComboNacionalidades()
        {
            List<Pais> paises = paisServicios.GetPaises();
            cmbNacionalidad.DataSource = paises;
            cmbNacionalidad.DisplayMember = "Nombre";
            cmbNacionalidad.ValueMember = "IdPais";
            cmbNacionalidad.SelectedValue = -1;
        }

        private void CargarComboTipoDocumento()
        {
            List<TipoDocumento> tipoDocumentos = tipoDocumentoServicios.GetTipoDocumentos();
            cmbTipoDocumento.DataSource = tipoDocumentos;
            cmbTipoDocumento.DisplayMember = "Nombre";
            cmbTipoDocumento.ValueMember = "IdTipoDocumento";
            cmbTipoDocumento.SelectedValue = -1;
        }

        private void CargarGrilla()
        {
            try
            {
                var listaPasajeros = new List<Pasajero>();
                listaPasajeros = pasajeroServicios.GetPasajeros();
                dgvPasajeros.Rows.Clear();

                foreach (var p in listaPasajeros)
                {
                    var fila = new string[]
                    {
                    null, // esta es la columna de la imagen
                    p.ObjTipoDocumento.IdTipoDocumento.ToString(),
                    p.ObjTipoDocumento.Nombre,
                    p.NroDocumento,
                    p.Nombre,
                    p.Apellido,
                    p.FechaNacimiento.ToString("dd/MM/yyyy"),
                    p.TelefonoCelular,
                    p.Email,
                    p.ObjPais.IdPais.ToString(),
                    p.ObjPais.Nombre,
                    p.ObjSexo.IdSexo.ToString(),
                    p.ObjSexo.Nombre,
                    };
                    dgvPasajeros.Rows.Add(fila);
                }

                // Limpiar la imagen en la columna de imagenes
                for (int i = 0; i < dgvPasajeros.RowCount; i++)
                {
                    dgvPasajeros.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void dgvPasajeros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (documento != "")
            {
                // COLOCO EL CHECK ANTERIOR EN BLANCO
                for (int i = 0; i < dgvPasajeros.RowCount; i++)
                {
                    string valor = dgvPasajeros.Rows[i].Cells["NumeroDocumento"].Value.ToString();
                    int valor2 = Convert.ToInt32(dgvPasajeros.Rows[i].Cells["IdTipoDocumento"].Value);
                    if (valor == documento && valor2 == idTipoDocumento)
                    {
                        dgvPasajeros.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
                    }
                }
            }

            int indice = e.RowIndex; // obtengo el indice de la fila seleccionada
            if (indice >= 0)
            {
                txtNroDocumento.Text = dgvPasajeros.Rows[indice].Cells["NumeroDocumento"].Value.ToString();
                cmbTipoDocumento.SelectedValue = Convert.ToInt32(dgvPasajeros.Rows[indice].Cells["IdTipoDocumento"].Value);
                txtNombre.Text = dgvPasajeros.Rows[indice].Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvPasajeros.Rows[indice].Cells["Apellido"].Value.ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(dgvPasajeros.Rows[indice].Cells["FechaNacimiento"].Value);
                txtTelefono.Text = dgvPasajeros.Rows[indice].Cells["TelefonoCelular"].Value.ToString();
                txtMail.Text = dgvPasajeros.Rows[indice].Cells["Mail"].Value.ToString();
                cmbNacionalidad.SelectedValue = Convert.ToInt32(dgvPasajeros.Rows[indice].Cells["IdNacionalidad"].Value);
                
                int idSexo = Convert.ToInt32(dgvPasajeros.Rows[indice].Cells["IdSexo"].Value);
                rdMasculino.Checked = false;
                rdFemenino.Checked = false;
                rdOtro.Checked = false;
                if (idSexo == 1)
                    rdMasculino.Checked = true;
                else if (idSexo == 2)
                    rdFemenino.Checked = true;
                else
                    rdOtro.Checked = true;

                cmbTipoDocumento.Enabled = false;
                txtNroDocumento.Enabled = false;

                this.documento = dgvPasajeros.Rows[indice].Cells["NumeroDocumento"].Value.ToString();
                this.idTipoDocumento = Convert.ToInt32(dgvPasajeros.Rows[indice].Cells["IdTipoDocumento"].Value);
                dgvPasajeros.Rows[indice].Cells["ColumnImg"].Value = Properties.Resources.check_gris_20x20;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            dgvPasajeros.ClearSelection();

            // modificaciones para hacer blanca la imagen por defecto
            for (int i = 0; i < dgvPasajeros.RowCount; i++)
            {
                dgvPasajeros.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }
        }

        private void LimpiarCampos()
        {
            txtNroDocumento.Clear();
            cmbTipoDocumento.SelectedValue = -1;
            txtNombre.Clear();
            txtApellido.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            txtTelefono.Clear();
            txtMail.Clear();
            cmbNacionalidad.SelectedValue = -1;
            
            cmbTipoDocumento.Enabled = true;
            txtNroDocumento.Enabled = true;

            rdMasculino.Checked = false;
            rdFemenino.Checked = false;
            rdOtro.Checked = false;

            this.documento = "";
            this.idTipoDocumento = 0;
        }

        private void dgvPasajeros_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvPasajeros.SelectedRows[0].Cells["ColumnImg"].Value = Properties.Resources.check_gris_20x20;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idSexo = 0;
            if (rdMasculino.Checked)
            {
                idSexo = 1;
            }
            if (rdFemenino.Checked)
            {
                idSexo = 2;
            }
            if (rdOtro.Checked)
            {
                idSexo = 3;
            }

            var p = new Pasajero()
            {
                Apellido = txtApellido.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                ObjTipoDocumento = new TipoDocumento
                {
                    IdTipoDocumento = Convert.ToInt32(cmbTipoDocumento.SelectedValue) == -1 ? 0 : Convert.ToInt32(cmbTipoDocumento.SelectedValue),
                },
                NroDocumento = txtNroDocumento.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value,
                TelefonoCelular = txtTelefono.Text.Trim(),
                Email = txtMail.Text.Trim(),
                ObjSexo = new Sexo
                {
                    IdSexo = idSexo,
                },
                ObjPais = new Pais
                {
                    IdPais = Convert.ToInt32(cmbNacionalidad.SelectedValue) == -1 ? 0 : Convert.ToInt32(cmbNacionalidad.SelectedValue),
                }
            };

            if (documento == "")
            {
                InsertarPasajero(p);
            }
            else
            {
                UpdatePasajero(p);
            }
        }
        private void InsertarPasajero(Pasajero p)
        {
            try
            {
                string mensaje = pasajeroServicios.InsertPasajero(p);
                if (mensaje == "")
                {
                    MessageBox.Show("El pasajero se agrego con éxito", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePasajero(Pasajero p)
        {
            try
            {
                DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere modificar los datos del pasajero?", "Modificar pasajero", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultadoDialogo.ToString() == "OK")
                {
                    string mensaje = pasajeroServicios.UpdatePasajero(p);
                    if (mensaje == "")
                    {
                        MessageBox.Show("El pasajero ha sido actualizado", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (documento != "")
                {
                    DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere eliminar el pasajero?", "Eliminar pasajero", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (resultadoDialogo.ToString() == "OK")
                    {
                        Pasajero p = new Pasajero()
                        {
                            NroDocumento = documento,
                            ObjTipoDocumento = new TipoDocumento
                            {
                                IdTipoDocumento = idTipoDocumento
                            },
                        };

                        string mensaje = pasajeroServicios.DeletePasajero(p);
                        if (mensaje == "")
                        {
                            MessageBox.Show("El pasajero ha sido eliminado", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Debe seleccionar un pasajero primero", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
