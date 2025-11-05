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
    public partial class Login : Form
    {
        private readonly UsuarioServicios usuarioServicios;
        private bool contraseñaVisible;
        public Login()
        {
            InitializeComponent();
            usuarioServicios = new UsuarioServicios();
            contraseñaVisible = false;
        }

        private void ValidarUsuarioHardCode()
        {
            if(txtUsuario.Text == "admin" && txtContraseña.Text == "admin")
            {
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos");
            }
        }

        private void ValidarUsuario()
        {
            try
            {
                var usuarioIngresado = txtUsuario.Text;

                Usuario usuario = new Usuario();
                usuario.Nombre = usuarioIngresado;
                usuario.Contraseña = txtContraseña.Text;

                Usuario usuarioLogueado = usuarioServicios.Login(usuario);
                if (usuarioLogueado == null)
                {
                    MessageBox.Show("Usuario/contraseña inválida", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MenuPrincipal ventana = new MenuPrincipal(this);
                    ventana.Show();
                    this.Hide();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hubo un error en el almacenamiento de datos", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        public void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtContraseña.Clear();
            txtUsuario.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ValidarUsuario();
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ValidarUsuario();
            }
        }

        private void btnMostrarContraseña_Click(object sender, EventArgs e)
        {
            if (contraseñaVisible)
            {
                txtContraseña.PasswordChar = '*';
                btnMostrarContraseña.IconChar = FontAwesome.Sharp.IconChar.Eye;
                contraseñaVisible = false;
                
            }
            else
            {
                txtContraseña.PasswordChar = '\0';
                btnMostrarContraseña.IconChar = FontAwesome.Sharp.IconChar.EyeSlash;
                contraseñaVisible = true;
            }
        }
    }
}
