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
using tp_pav1_grupo10.Repositorios;
using tp_pav1_grupo10.Servicios;

namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    public partial class FrmPerfiles : Form
    {

        private readonly PerfilServicios perfilServicio;
        private int idPerfil;

        public FrmPerfiles()
        {
            InitializeComponent();
            perfilServicio = new PerfilServicios();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = "";
            chkSeguridad.Checked = false;
            chkReportes.Checked = false;
            chkPlanificarVuelos.Checked = false;
            chkEstadoVuelo.Checked = false;
            chkRegistros.Checked = false;
            chkReservas.Checked = false;
            txtNombre.Focus();
            this.idPerfil = 0;
        }

        private void CargarGrilla()
        {
            List<Perfil> listaPerfiles = perfilServicio.GetPerfiles();
            dgvPerfiles.Rows.Clear();

            for (int i = 0; i < listaPerfiles.Count; i++)
            {

                var fila = new string[]
                {
                    null, // esta es la columna de la imagen
                    listaPerfiles[i].IdPerfil.ToString(),
                    listaPerfiles[i].Nombre,
                };
                dgvPerfiles.Rows.Add(fila);

                foreach (var permiso in listaPerfiles[i].ListaPermisos)
                {
                    if (permiso.IdPermiso == 1) // Seguridad
                    {
                        dgvPerfiles.Rows[i].Cells["Seguridad"].Value = true;
                    }
                    if (permiso.IdPermiso == 2) // Reportes
                    {
                        dgvPerfiles.Rows[i].Cells["Reportes"].Value = true;
                    }
                    if (permiso.IdPermiso == 3) // PlanificarVuelos
                    {
                        dgvPerfiles.Rows[i].Cells["PlanificarVuelos"].Value = true;
                    }
                    if (permiso.IdPermiso == 4) // EstadoVuelos
                    {
                        dgvPerfiles.Rows[i].Cells["EstadoVuelos"].Value = true;
                    }
                    if (permiso.IdPermiso == 5) // Registros
                    {
                        dgvPerfiles.Rows[i].Cells["Registros"].Value = true;
                    }
                    if (permiso.IdPermiso == 6) // Reservas
                    {
                        dgvPerfiles.Rows[i].Cells["Reservas"].Value = true;
                    }
                }
            }
            // modificaciones para hacer blanca la imagen por defecto
            for (int i = 0; i < dgvPerfiles.RowCount; i++)
            {
                dgvPerfiles.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }
        }

        private void FrmPerfiles_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            lblIdPerfil.Text = idPerfil.ToString();
            dgvPerfiles.ClearSelection();
            dgvPerfiles.AllowUserToOrderColumns = false;

            // Hacer que las columnas no se puedan ordenar
            for (int i = 0; i < dgvPerfiles.ColumnCount; i++)
            {
                dgvPerfiles.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            idPerfil = 0;
            lblIdPerfil.Text = idPerfil.ToString();
            dgvPerfiles.ClearSelection();
            for (int i = 0; i < dgvPerfiles.RowCount; i++)
            {
                dgvPerfiles.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Perfil perfil = new Perfil()
            {
                IdPerfil = idPerfil,
                Nombre = txtNombre.Text.ToString().Trim(),
                ListaPermisos = new List<Permiso>()
            };
            if (chkSeguridad.Checked)
            {
                Permiso per = new Permiso()
                {
                    IdPermiso = 1
                };
                 perfil.ListaPermisos.Add(per);
            }
            if (chkReportes.Checked)
            {
                Permiso per = new Permiso()
                {
                    IdPermiso = 2
                };
                perfil.ListaPermisos.Add(per);
            }
            if (chkPlanificarVuelos.Checked)
            {
                Permiso per = new Permiso()
                {
                    IdPermiso = 3
                };
                perfil.ListaPermisos.Add(per);
            }
            if (chkEstadoVuelo.Checked)
            {
                Permiso per = new Permiso()
                {
                    IdPermiso = 4
                };
                perfil.ListaPermisos.Add(per);
            }
            if (chkRegistros.Checked)
            {
                Permiso per = new Permiso()
                {
                    IdPermiso = 5
                };
                perfil.ListaPermisos.Add(per);
            }
            if (chkReservas.Checked)
            {
                Permiso per = new Permiso()
                {
                    IdPermiso = 6
                };
                perfil.ListaPermisos.Add(per);
            }


            if (idPerfil == 0)
            {
                InsertPerfiles(perfil);
            }
            else
            {
                UpdatePerfiles(perfil);
            }
        }

        private void InsertPerfiles(Perfil perfil)
        {
            try
            {
                string mensaje = perfilServicio.InsertPerfiles(perfil);
                if (mensaje == "")
                {
                    MessageBox.Show("El perfil se agrego con éxito", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dgvPerfiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (idPerfil != 0)
            {
                for (int i = 0; i < dgvPerfiles.RowCount; i++)
                {
                    int valor = Convert.ToInt32(dgvPerfiles.Rows[i].Cells["IdPerfiles"].Value);
                    if (valor == idPerfil)
                    {
                        dgvPerfiles.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
                    }
                }
            }

            LimpiarCampos();

            int indice = e.RowIndex; // obtengo el indice de la fila seleccionada
            if (indice >= 0)
            {
                txtNombre.Text = dgvPerfiles.Rows[indice].Cells["Nombre"].Value.ToString();
                if (Convert.ToBoolean(dgvPerfiles.Rows[indice].Cells["Seguridad"].Value))
                {
                    chkSeguridad.Checked = true;
                }
                if (Convert.ToBoolean(dgvPerfiles.Rows[indice].Cells["Reportes"].Value))
                {
                    chkReportes.Checked = true;
                }
                if (Convert.ToBoolean(dgvPerfiles.Rows[indice].Cells["PlanificarVuelos"].Value))
                {
                    chkPlanificarVuelos.Checked = true;
                }
                if (Convert.ToBoolean(dgvPerfiles.Rows[indice].Cells["EstadoVuelos"].Value))
                {
                    chkEstadoVuelo.Checked = true;
                }
                if (Convert.ToBoolean(dgvPerfiles.Rows[indice].Cells["Registros"].Value))
                {
                    chkRegistros.Checked = true;
                }
                if (Convert.ToBoolean(dgvPerfiles.Rows[indice].Cells["Reservas"].Value))
                {
                    chkReservas.Checked = true;
                }

                this.idPerfil = Convert.ToInt32(dgvPerfiles.Rows[indice].Cells["IdPerfiles"].Value.ToString().Trim());
                dgvPerfiles.Rows[indice].Cells["ColumnImg"].Value = Properties.Resources.check_gris_20x20;
            }
        }
    

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idPerfil != 0)
                {
                    DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere eliminar el perfil?", "Eliminar perfil", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (resultadoDialogo.ToString() == "OK")
                    {
                        perfilServicio.DeletePerfiles(idPerfil);

                        MessageBox.Show("El perfil ha sido eliminado", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                        LimpiarCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un perfil primero", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void UpdatePerfiles(Perfil perfil)
        {
            try
            {
                DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere modificar el perfil?", "Modificar perfil", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultadoDialogo.ToString() == "OK")
                {
                    string mensaje = perfilServicio.UpdatePerfiles(perfil);
                    if (mensaje == "")
                    {
                        MessageBox.Show("El perfil ha sido actualizado", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
