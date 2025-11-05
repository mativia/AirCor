using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.Servicios;

namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    public partial class FrmRegistrarReserva : Form
    {
        private GestorReserva gestorReserva;

        public FrmRegistrarReserva(GestorReserva gestor)
        {
            gestorReserva = gestor;
            InitializeComponent();
        }

        private void FrmRegistrarReserva_Load(object sender, EventArgs e)
        {

        }

        private void btnRegistrarPasajero_Click(object sender, EventArgs e)
        {
            var ventanaPasajeros = new FrmAñadirPasajero(this);
            ventanaPasajeros.Show();
        }

        public bool AñadirPasajero(Pasajero pasajero)
        {
            bool yaAgregado = false;
            foreach (DataGridViewRow row in dgvPasajeros.Rows)
            {
                if (Convert.ToInt32(row.Cells["IdTipoDocumento"].Value.ToString()) == pasajero.ObjTipoDocumento.IdTipoDocumento &&
                    row.Cells["NumeroDocumento"].Value.ToString() == pasajero.NroDocumento)
                {
                    yaAgregado = true;
                    break;
                }
            }

            if (yaAgregado)
            {
                return false;
            }
            else
            {
                var fila = new string[]
                {
                    null,
                    pasajero.ObjTipoDocumento.IdTipoDocumento.ToString(),
                    pasajero.ObjTipoDocumento.Nombre,
                    pasajero.NroDocumento,
                    pasajero.Nombre,
                    pasajero.Apellido,
                    pasajero.FechaNacimiento.ToString("dd/MM/yyyy"),
                    pasajero.TelefonoCelular,
                    pasajero.Email,
                    pasajero.ObjPais.IdPais.ToString(),
                    pasajero.ObjPais.Nombre,
                    pasajero.ObjSexo.IdSexo.ToString(),
                    pasajero.ObjSexo.Nombre,
                };
                dgvPasajeros.Rows.Add(fila);
                MessageBox.Show("El pasajero se agrego con éxito", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
        }


        private void btnEliminarPasajero_Click(object sender, EventArgs e)
        {
            if (dgvPasajeros.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("¿Esta seguro que quiere eliminar el pasajero seleccionado de la reserva?", "Informacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (resultado == DialogResult.OK)
                {
                    dgvPasajeros.Rows.Remove(dgvPasajeros.SelectedRows[0]);
                    MessageBox.Show("Pasajero eliminado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un pasajero primero", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvPasajeros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                if (e.RowIndex != -1)
                {
                    var columnIndex = 0;
                    if (e.ColumnIndex == columnIndex)
                    {
                        bool isChecked = dgvPasajeros.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected;
                        if (isChecked)
                        {
                            foreach (DataGridViewRow row in dgvPasajeros.Rows)
                            {
                                if (row.Index != e.RowIndex)
                                {
                                    row.Cells[columnIndex].Value = !isChecked;
                                }
                            }
                        }
                    }
                }

            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (dgvPasajeros.Rows.Count > 0)
            {
                if (SeSeleccionoUnTitular())
                {
                    List<DetalleReserva> lista = ObtenerPasajerosSeleccionados();
                    gestorReserva.listaPasajeros = lista;
                    this.Hide();
                    gestorReserva.SeleccionDeAsientos();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar a un titular que poseea mail\npara poder enviarle el comprobante de reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe añadir por lo menos a un pasajero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<DetalleReserva> ObtenerPasajerosSeleccionados()
        {
            var lista = new List<DetalleReserva>();

            for (int i = 0; i < dgvPasajeros.RowCount; i++)
            {
                var detalle = new DetalleReserva();
                var p = new Pasajero();
                p.Nombre = dgvPasajeros.Rows[i].Cells["Nombre"].Value.ToString();
                p.Apellido = dgvPasajeros.Rows[i].Cells["Apellido"].Value.ToString();
                p.Email = dgvPasajeros.Rows[i].Cells["Mail"].Value.ToString();
                p.NroDocumento = dgvPasajeros.Rows[i].Cells["NumeroDocumento"].Value.ToString();
                p.ObjTipoDocumento = new TipoDocumento() {
                    IdTipoDocumento = Convert.ToInt32(dgvPasajeros.Rows[i].Cells["IdTipoDocumento"].Value),
                    Nombre = dgvPasajeros.Rows[i].Cells["TipoDocumento"].Value.ToString()
                };
                detalle.ObjPasajero = p;
                detalle.EsTitular = Convert.ToBoolean(dgvPasajeros.Rows[i].Cells["Titular"].Value);


                lista.Add(detalle);
            }

            return lista;
        }

        private bool SeSeleccionoUnTitular()
        {
            bool res = false;

            for (int i = 0; i < dgvPasajeros.RowCount; i++)
            {
                if (Convert.ToBoolean(dgvPasajeros.Rows[i].Cells["Titular"].Value) && dgvPasajeros.Rows[i].Cells["Mail"].Value.ToString() != "")
                {
                    return true;
                }
            }

            return res;
        }

        private void FrmRegistrarReserva_FormClosing(object sender, FormClosingEventArgs e)
        {
            gestorReserva.CancelarTransaccion();
        }
    }
}
