using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ValidarUsuarioHardCode();
            MenuPrincipal ventana = new MenuPrincipal();
            ventana.Show();
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
    }
}
