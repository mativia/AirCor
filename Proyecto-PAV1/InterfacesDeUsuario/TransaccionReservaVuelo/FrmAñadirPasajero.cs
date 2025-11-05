using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.Servicios;

namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    public partial class FrmAñadirPasajero : Form
    {
        private readonly PasajeroServicios pasajeroServicios;
        private readonly PaisServicios paisServicios;
        private readonly TipoDocumentoServicios tipoDocumentoServicios;
        private string NroDocumento;
        private FrmRegistrarReserva frmRegistrarReserva;

        public FrmAñadirPasajero(FrmRegistrarReserva frmRegistrar)
        {
            InitializeComponent();
            paisServicios = new PaisServicios();
            pasajeroServicios = new PasajeroServicios();
            tipoDocumentoServicios = new TipoDocumentoServicios();
            frmRegistrarReserva = frmRegistrar;
            NroDocumento = "";
        }

        private void FrmAñadirPasajero_Load(object sender, EventArgs e)
        {
            dtpFechaNacimiento.MaxDate = DateTime.Today;
            CargarGrilla();
            dgvPasajeros.ClearSelection();
            CargarComboNacionalidades();
            CargarComboTipoDocumento();
        }

        // Este data grid view esta programado sin la imagen
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
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

            // combo filtro tipo documento
            List<TipoDocumento> filtroTipoDocumentos = tipoDocumentoServicios.GetTipoDocumentos();
            cmbFiltroTipoDocumento.DataSource = filtroTipoDocumentos;
            cmbFiltroTipoDocumento.DisplayMember = "Nombre";
            cmbFiltroTipoDocumento.ValueMember = "IdTipoDocumento";
            cmbFiltroTipoDocumento.SelectedValue = -1;
        }

        private void LimpiarCampos()
        {
            dgvPasajeros.ClearSelection();

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

            this.NroDocumento = "";
            //this.idTipoDocumento = 0;
        }

        private void dgvPasajeros_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPasajeros.SelectedRows.Count > 0)
            {
                NroDocumento = dgvPasajeros.SelectedRows[0].Cells["NumeroDocumento"].Value.ToString();

                txtNombre.Text = dgvPasajeros.SelectedRows[0].Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvPasajeros.SelectedRows[0].Cells["Apellido"].Value.ToString();
                txtNroDocumento.Text = dgvPasajeros.SelectedRows[0].Cells["NumeroDocumento"].Value.ToString();
                txtMail.Text = dgvPasajeros.SelectedRows[0].Cells["Mail"].Value.ToString();
                txtTelefono.Text = dgvPasajeros.SelectedRows[0].Cells["TelefonoCelular"].Value.ToString();

                // Fecha de nacimiento
                dtpFechaNacimiento.Value = Convert.ToDateTime(dgvPasajeros.SelectedRows[0].Cells["FechaNacimiento"].Value.ToString());

                // Seleccion de sexo 
                int idSexo = Convert.ToInt32(dgvPasajeros.SelectedRows[0].Cells["IdSexo"].Value);
                rdMasculino.Checked = false;
                rdFemenino.Checked = false;
                rdOtro.Checked = false;
                if (idSexo == 1)
                    rdMasculino.Checked = true;
                else if (idSexo == 2)
                    rdFemenino.Checked = true;
                else
                    rdOtro.Checked = true;

                // Cargar combos
                cmbNacionalidad.SelectedValue = Convert.ToInt32(dgvPasajeros.SelectedRows[0].Cells["IdNacionalidad"].Value.ToString());
                cmbTipoDocumento.SelectedValue = Convert.ToInt32(dgvPasajeros.SelectedRows[0].Cells["IdTipoDocumento"].Value.ToString());

                // Deshabilitar los campos de tipo y numero de documento
                cmbTipoDocumento.Enabled = false;
                txtNroDocumento.Enabled = false;
            }
            else
            {
                LimpiarCampos();
            }
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();

        }

        private void btnAgregarPasajero_Click(object sender, EventArgs e)
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

            Pasajero nuevoPasajero = new Pasajero()
            {
                NroDocumento = txtNroDocumento.Text.Trim(),
                ObjTipoDocumento = new TipoDocumento()
                {
                    IdTipoDocumento = Convert.ToInt32(cmbTipoDocumento.SelectedValue) == -1 ? 0 : Convert.ToInt32(cmbTipoDocumento.SelectedValue),
                    Nombre = cmbTipoDocumento.Text.Trim()
                },
                Apellido = txtApellido.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                TelefonoCelular = txtTelefono.Text.Trim(),
                Email = txtMail.Text.Trim(),
                FechaNacimiento = Convert.ToDateTime(dtpFechaNacimiento.Value),
                ObjSexo = new Sexo() { IdSexo = idSexo },
                ObjPais = new Pais() { IdPais = Convert.ToInt32(cmbNacionalidad.SelectedValue) == -1 ? 0 : Convert.ToInt32(cmbNacionalidad.SelectedValue) }
            };

            bool agregado;
            if (NroDocumento == "")
            {
                DialogResult resultado = MessageBox.Show("¿Esta seguro que quiere añadir y guardar el pasajero cargado?", "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (resultado == DialogResult.OK)
                {
                    agregado = InsertarPasajero(nuevoPasajero);
                }
                else
                {
                    agregado = false;
                }
                    
            }
            else
            {
                agregado = UpdatePasajero(nuevoPasajero);
            }

            if (agregado)
            {
                bool res = this.frmRegistrarReserva.AñadirPasajero(nuevoPasajero);
                if (!res)
                {
                    MessageBox.Show("El pasajero seleccionado ya ha sido agregado a la reserva", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.Dispose();
                }
            }   
        }

        private bool InsertarPasajero(Pasajero p)
        {
            try
            {
                string mensaje = pasajeroServicios.InsertPasajero(p);
                if (mensaje == "")
                {
                    CargarGrilla();
                    LimpiarCampos();
                    return true;
                }
                else
                {
                    MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool UpdatePasajero(Pasajero p)
        {
            try
            {
                DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere modificar y agregar a la reserva al pasajero?", "Modificar pasajero", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultadoDialogo.ToString() == "OK")
                {
                    string mensaje = pasajeroServicios.UpdatePasajero(p);
                    if (mensaje == "")
                    {
                        //MessageBox.Show("El pasajero ha sido actualizado", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                        LimpiarCampos();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                var filtro = new PasajeroFiltro()
                {
                    Nombre = txtFiltroNombre.Text.ToString(),
                    Apellido = txtFiltroApellido.Text.ToString(),
                    NroDocumento = txtFiltroNroDocumento.Text.ToString(),
                };
                if (cmbFiltroTipoDocumento.SelectedIndex != -1)
                {
                    filtro.IdTipoDocumento = Convert.ToInt32(cmbFiltroTipoDocumento.SelectedValue);
                }
                else
                {
                    filtro.IdTipoDocumento = 0;
                }

                var listaPasajeros = pasajeroServicios.GetPasajeros(filtro);
                dgvPasajeros.Rows.Clear();

                foreach (var p in listaPasajeros)
                {
                    var fila = new string[]
                    {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtFiltroNombre.Clear();
            txtFiltroApellido.Clear();
            txtFiltroNroDocumento.Clear();
            cmbFiltroTipoDocumento.SelectedIndex = -1;
        }
    }
}
