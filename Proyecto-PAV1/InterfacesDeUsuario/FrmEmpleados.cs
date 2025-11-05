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
    public partial class FrmEmpleados : Form
    {
        // FUTUROS CAMBIOS: 
        //   
        private readonly EmpleadoServicios empleadoServicio;
        private readonly UsuarioServicios usuarioServicios;
        private int legajo;

        public FrmEmpleados()
        {
            InitializeComponent();
            empleadoServicio = new EmpleadoServicios();
            usuarioServicios = new UsuarioServicios();
            this.legajo = -1;
        }


        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            CargarGrilla();            
            dgvEmpleados.ClearSelection();

            //nombre de columnas
            dgvEmpleados.Columns["NombreEmpleado"].HeaderText = "Nombre Empleado";
            dgvEmpleados.Columns["NombreUsuario"].HeaderText = "Nombre Usuario";

            dgvEmpleados.Columns["IdUsuario"].Visible = false;
            CargarUsuarios();

            // Hacer que las columnas no se puedan ordenar
            for (int i = 0; i < dgvEmpleados.ColumnCount; i++)
            {
                dgvEmpleados.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void CargarGrilla()
        {
            DataTable tablaEmpleados = empleadoServicio.GetEmpleados();
            dgvEmpleados.DataSource = tablaEmpleados;
            // modificaciones para hacer blanca la imagen por defecto
            for (int i = 0; i < dgvEmpleados.RowCount; i++)
            {
                dgvEmpleados.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }
        }

        public void LimpiarCampos()
        {
            txtLegajo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            cmbUsuario.SelectedIndex = -1;
            txtLegajo.Enabled = true;
        }

        private void CargarUsuarios()
        {
            DataTable tablaUsuarios = usuarioServicios.GetUsuarios();
            cmbUsuario.DataSource = tablaUsuarios;
            cmbUsuario.DisplayMember = "NombreUsuario";
            cmbUsuario.ValueMember = "IdUsuario";
            cmbUsuario.SelectedValue = -1;
        }

        private void InsertarEmpleado(Empleado empleado)
        {
            string mensaje = empleadoServicio.InsertEmpleados(empleado);
            if (mensaje == "")
            {
                MessageBox.Show("El empleado se agrego con éxito", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                this.legajo = -1;
                lblLegajo.Text = legajo.ToString();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateEmpleados(Empleado empleado)
        {
            DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere modificar el empleado?", "Modificar empleado", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultadoDialogo.ToString() == "OK")
            {
                string mensaje = empleadoServicio.UpdateEmpleados(empleado);
                if (mensaje == "")
                {
                    MessageBox.Show("El empleado ha sido actualizado", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    this.legajo = -1;
                    lblLegajo.Text = legajo.ToString();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        { 
            Empleado empleado = new Empleado()
            {
                Legajo = txtLegajo.Text == "" ? -1 : Convert.ToInt32(txtLegajo.Text),
                Apellido = txtApellido.Text.ToString().Trim(),
                Nombre = txtNombre.Text.ToString().Trim(),
                ObjUsuario = new Usuario() { IdUsuario = Convert.ToInt32(cmbUsuario.SelectedValue) }

            };

            if (legajo == -1)
            {
                InsertarEmpleado(empleado);
            }
            else
            {
                UpdateEmpleados(empleado);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (legajo != -1)
            {
                DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere eliminar el empleado?", "Eliminar empleado", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultadoDialogo.ToString() == "OK")
                {
                    string mensaje = empleadoServicio.DeleteEmpleados(legajo);
                    if (mensaje == "")
                    {
                        MessageBox.Show("El empleado ha sido eliminado", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                        this.legajo = 0;
                        lblLegajo.Text = legajo.ToString();
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
                MessageBox.Show("Debe seleccionar un empleado primero", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            this.legajo = -1;
            lblLegajo.Text = legajo.ToString();
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (legajo != -1)
            {    
                for (int i = 0; i < dgvEmpleados.RowCount; i++)
                {
                    int valor = Convert.ToInt32(dgvEmpleados.Rows[i].Cells["Legajo"].Value);
                    if (valor == legajo)
                    {
                        dgvEmpleados.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
                    }
                }
            }
            if (dgvEmpleados.Columns[e.ColumnIndex].Name == "ColumnImg")
            {
                int indice = e.RowIndex; // obtengo el indice de la fila seleccionada
                if (indice >= 0)
                {
                    
                    // cambiar los textbox y combos
                    txtLegajo.Text = dgvEmpleados.Rows[indice].Cells["Legajo"].Value.ToString();
                    txtNombre.Text = dgvEmpleados.Rows[indice].Cells["NombreEmpleado"].Value.ToString();
                    txtApellido.Text = dgvEmpleados.Rows[indice].Cells["Apellido"].Value.ToString();
                    cmbUsuario.SelectedValue = dgvEmpleados.Rows[indice].Cells["IdUsuario"].Value;



                    this.legajo = Convert.ToInt32(dgvEmpleados.Rows[indice].Cells["Legajo"].Value);
                    lblLegajo.Text = legajo.ToString();
                    txtLegajo.Enabled = false;

                    dgvEmpleados.Rows[indice].Cells["ColumnImg"].Value = Properties.Resources.check_gris_20x20;

                }
            }
        }
    }
}
