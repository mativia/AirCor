using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using tp_pav1_grupo10.Entidades;
using tp_pav1_grupo10.Servicios;


namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    public partial class FrmPais : Form
    {
        private readonly PaisServicios paisServicio;
        private int idPais;

        public FrmPais()
        {
            InitializeComponent();
            paisServicio = new PaisServicios();
            
        }
        private void LimpiarCampos()
        {
            txtNombre.Clear();
        }

        private void FrmPais_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            lbldPais.Text = idPais.ToString();
            dgvPaises.ClearSelection();

            // Hacer que las columnas no se puedan ordenar
            for (int i = 0; i < dgvPaises.ColumnCount; i++)
            {
                dgvPaises.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
        }

        private void CargarGrilla()
        {
            var listaPaises = new List<Pais>();
            listaPaises = paisServicio.GetPaises();
            dgvPaises.Rows.Clear();

            foreach (var pais in listaPaises)
            {
                var fila = new string[]
                {
                    null, // esta es la columna de la imagen
                    pais.IdPais.ToString(),
                    pais.Nombre
                };
                dgvPaises.Rows.Add(fila);
            }

            // Limpiar la imagen en la columna de imagenes
            for (int i = 0; i < dgvPaises.RowCount; i++)
            {
               dgvPaises.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada; 
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Pais pais = new Pais()
            {
                IdPais = idPais,
                Nombre = txtNombre.Text.ToString().Trim()
            };

            if (idPais == 0)
            {
                InsertarPais(pais);
            }
            else
            {
                UpdatePais(pais);
            }
        }

        private void InsertarPais(Pais pais)
        {
            string mensaje = paisServicio.InsertPaises(pais);
            if (mensaje == "")
            {
                MessageBox.Show("El pais se agrego con éxito", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                int indicePais = dgvPaises.Rows.Count;
                this.idPais = 0;
                lbldPais.Text = idPais.ToString();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show(mensaje, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SELECCION DE PAISES EN LA GRILLA
        private void dgvPaises_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(idPais != 0)
            {
                // COLOCO EL CHECK ANTERIOR EN BLANCO, TENGO EL ID DEL PAIS QUE ESTABA SELECCIONADO ANTES
                // PERO NECESITO SU UBICACIÓN EN LA GRILLA
                for (int i = 0; i < dgvPaises.RowCount; i++)
                {
                    int valor = Convert.ToInt32(dgvPaises.Rows[i].Cells["IdPaises"].Value);
                    if (valor == idPais)
                    {
                        dgvPaises.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
                    }
                }
            }
            
            int indice = e.RowIndex; // obtengo el indice de la fila seleccionada
            if (indice >= 0)
            {
                txtNombre.Text = dgvPaises.Rows[indice].Cells["NombrePais"].Value.ToString();
                this.idPais = Convert.ToInt32(dgvPaises.Rows[indice].Cells["IdPaises"].Value.ToString().Trim());
                lbldPais.Text = idPais.ToString();

                dgvPaises.Rows[indice].Cells["ColumnImg"].Value = Properties.Resources.check_gris_20x20;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {  
            if (idPais != 0)
            {
                DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere eliminar el pais?", "Eliminar pais", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultadoDialogo.ToString() == "OK")
                {
                    Pais pais = new Pais()
                    {
                        IdPais = idPais,
                        Nombre = txtNombre.Text.ToString().Trim()
                    };

                    string mensaje = paisServicio.DeletePaises(pais);
                    if (mensaje == "")
                    {
                        MessageBox.Show("El país ha sido eliminado", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarGrilla();
                        this.idPais = 0;
                        lbldPais.Text = idPais.ToString();
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
                MessageBox.Show("Debe seleccionar un pais primero", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdatePais(Pais pais)
        {
            DialogResult resultadoDialogo = MessageBox.Show("¿Está seguro que quiere modificar el pais?", "Modificar pais", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resultadoDialogo.ToString() == "OK")
            {
                string mensaje = paisServicio.UpdatePaises(pais);
                if (mensaje == "")
                {
                    MessageBox.Show("El país ha sido actualizado", "¡Éxito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    this.idPais = 0;
                    lbldPais.Text = idPais.ToString();
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
            idPais = 0;
            lbldPais.Text = idPais.ToString();
            dgvPaises.ClearSelection();
            // modificaciones para hacer blanca la imagen por defecto
            for (int i = 0; i < dgvPaises.RowCount; i++)
            {
                dgvPaises.Rows[i].Cells["ColumnImg"].Value = Properties.Resources.png_sin_nada;
            }
        }
    }
}
