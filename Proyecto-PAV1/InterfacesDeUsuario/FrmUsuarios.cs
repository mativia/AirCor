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
    public partial class FrmUsuarios : Form
    {
        private readonly UsuarioServicios usuarioServicios;
        private readonly PerfilServicios perfilServicios;
        private int idUsuario;
        public FrmUsuarios()
        {
            InitializeComponent();
            usuarioServicios = new UsuarioServicios();
            perfilServicios = new PerfilServicios();
            idUsuario = 0;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            CargarPerfiles();
            dgvUsuarios.ClearSelection();
            lblIdUsuario.Text = idUsuario.ToString();

            // nombre de columnas
            dgvUsuarios.Columns["NombreUsuario"].HeaderText = "Nombre Usuario";
            dgvUsuarios.Columns["NombrePerfil"].HeaderText = "Nombre Perfil";

            dgvUsuarios.Columns["NombreUsuario"].Width = 120;
            dgvUsuarios.Columns["NombrePerfil"].Width = 180;

            // ocultar idusuario e idperfil
            dgvUsuarios.Columns["IdUsuario"].Visible = false;
            dgvUsuarios.Columns["IdPerfil"].Visible = false;

            // Hacer que las columnas no se puedan ordenar
            for (int i = 0; i < dgvUsuarios.ColumnCount; i++)
            {
                dgvUsuarios.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void CargarGrilla()
        {
            DataTable tablaUsuarios = usuarioServicios.GetUsuarios();
            dgvUsuarios.DataSource = tablaUsuarios;
            for (int i = 0; i < dgvUsuarios.RowCount; i++)
            {
                dgvUsuarios.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtContraseña.Clear();
            txtConfirmarContraseña.Clear();
            cmbPerfil.SelectedValue = -1;
        }

        private void CargarPerfiles()
        {
            DataTable tablaPefiles = perfilServicios.GetSoloPerfiles();
            cmbPerfil.DataSource = tablaPefiles;
            cmbPerfil.DisplayMember = "Nombre";
            cmbPerfil.ValueMember = "IdPerfil";
            cmbPerfil.SelectedValue = -1;
        }

        private void InsertarUsuario(Usuario nuevoUsuario, string confContraseña)
        {
            string mensaje = usuarioServicios.InsertUsuarios(nuevoUsuario, confContraseña);
            if (mensaje == "")
            {
                MessageBox.Show("El usuario se agrego con éxito", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                this.idUsuario = 0;
                lblIdUsuario.Text = this.idUsuario.ToString();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UpdateUsuario(Usuario usuario, string confContraseña)
        {
            DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere modificar el usuario?", "Modificar usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultadoDialogo.ToString() == "OK")
            {
                string mensaje = usuarioServicios.UpdateUsuarios(usuario, confContraseña);
                if (mensaje == "")
                {
                    MessageBox.Show("El usuario ha sido actualizado", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    this.idUsuario = 0;
                    lblIdUsuario.Text = idUsuario.ToString();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario()
            {
                IdUsuario = this.idUsuario,
                Nombre = txtNombre.Text.ToString(),
                Contraseña = txtContraseña.Text.ToString(),
                ObjPerfil = new Perfil() { IdPerfil = Convert.ToInt32(cmbPerfil.SelectedValue) }
            };
            string confContraseña = txtConfirmarContraseña.Text.ToString();

            if (idUsuario == 0)
            {
                InsertarUsuario(usuario, confContraseña);
            }
            else
            {
                UpdateUsuario(usuario, confContraseña);
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            idUsuario = 0;
            lblIdUsuario.Text = this.idUsuario.ToString();
            dgvUsuarios.ClearSelection();
            for (int i = 0; i < dgvUsuarios.RowCount; i++)
            {
                dgvUsuarios.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (idUsuario != 0)
            {
                // COLOCO EL CHECK ANTERIOR EN BLANCO, TENGO EL ID DEL PAIS QUE ESTABA SELECCIONADO ANTES
                // PERO NECESITO SU UBICACIÓN EN LA GRILLA
                for (int i = 0; i < dgvUsuarios.RowCount; i++)
                {
                    int valor = Convert.ToInt32(dgvUsuarios.Rows[i].Cells["IdUsuario"].Value);
                    if (valor == idUsuario)
                    {
                        dgvUsuarios.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
                    }
                }
            }
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "ColumnImg")
            {
                int indice = e.RowIndex; // obtengo el indice de la fila seleccionada
                if (indice >= 0)
                {
                    // cambiar los textbox y combos
                    txtNombre.Text = dgvUsuarios.Rows[indice].Cells["NombreUsuario"].Value.ToString();
                    txtContraseña.Clear();
                    txtConfirmarContraseña.Clear();
                    cmbPerfil.SelectedValue = dgvUsuarios.Rows[indice].Cells["IdPerfil"].Value;

                    this.idUsuario = Convert.ToInt32(dgvUsuarios.Rows[indice].Cells["IdUsuario"].Value.ToString());
                    lblIdUsuario.Text = idUsuario.ToString();

                    dgvUsuarios.Rows[indice].Cells["ColumnImg"].Value = Properties.Resources.check_gris_20x20;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere eliminar el usuario?", "Eliminar usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (idUsuario != 0)
            {
                if (resultadoDialogo.ToString() == "OK")
                {
                    string mensaje = usuarioServicios.DeleteUsuarios(idUsuario);
                    if (mensaje == "")
                    {
                        MessageBox.Show("El usuario ha sido eliminado", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                        this.idUsuario = 0;
                        lblIdUsuario.Text = idUsuario.ToString();
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
                MessageBox.Show("Debe seleccionar un usuario primero", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
