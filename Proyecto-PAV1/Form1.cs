using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using tp_pav1_grupo10.Repositorios;

namespace tp_pav1_grupo10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Verificar la existencia de los archivos .dll necesarios
                if (!VerificarDlls())
                {
                    MessageBox.Show("Faltan archivos necesarios. Instalando paquetes requeridos...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    InstalarPaquetesRequeridos();
                }

                // Prueba de conexión a la base de datos para diagnosticar problemas de login
                try
                {
                    var tabla = DBHelper.GetDBHelper().ConsultaSQL("SELECT 1 AS Resultado");
                    // si llega aquí, la conexión y la consulta básica funcionan
                }
                catch (Exception ex)
                {
                    // Mostrar detalle del error para diagnóstico
                    MessageBox.Show("Error al conectar con la base de datos:\n" + ex.Message, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al verificar los archivos necesarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool VerificarDlls()
        {
            // Rutas de los archivos .dll a verificar
            string[] archivosDll = new string[] {
                @".\SqlServerTypes\x64\SqlServerSpatial140.dll",
                @".\SqlServerTypes\x64\msvcr120.dll",
                @".\SqlServerTypes\x86\SqlServerSpatial140.dll",
                @".\SqlServerTypes\x86\msvcr120.dll"
            };

            // Verificar si cada archivo .dll existe
            foreach (string archivo in archivosDll)
            {
                if (!File.Exists(archivo))
                {
                    return false;
                }
            }

            return true;
        }

        private void InstalarPaquetesRequeridos()
        {
            try
            {
                // Aquí puedes agregar el código para instalar los paquetes requeridos, como ejecutar un script de instalación o descargar los archivos faltantes.
                // Por ejemplo, descomentar la siguiente línea para ejecutar un archivo .bat
                // Process.Start(@".\InstaladorPaquetes.bat");

                // O bien, descargar los archivos faltantes desde una ubicación especificada
                //using (WebClient cliente = new WebClient())
                //{
                //    cliente.DownloadFile("url_del_archivo_faltante", "ruta_de_destino_del_archivo");
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar instalar los paquetes requeridos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
