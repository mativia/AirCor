using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using tp_pav1_grupo10.InterfacesDeUsuario;

namespace tp_pav1_grupo10
{
    internal static class Program
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr LoadLibrary(string libname);

        private static void LoadNativeAssembly(string path)
        {
            var ptr = LoadLibrary(path);
            if (ptr == IntPtr.Zero)
            {
                throw new Exception(string.Format("Error loading {0} (ErrorCode: {1})", path, Marshal.GetLastWin32Error()));
            }
        }

        private static void LoadNativeAssemblies(string rootApplicationPath)
        {
            // determine arch-specific folder
            var nativeBinaryPath = IntPtr.Size > 4
                ? Path.Combine(rootApplicationPath, "SqlServerTypes", "x64")
                : Path.Combine(rootApplicationPath, "SqlServerTypes", "x86");

            // look for any SqlServerSpatial*.dll (160,140, etc.)
            var spatialDll = Directory.EnumerateFiles(nativeBinaryPath, "SqlServerSpatial*.dll", SearchOption.TopDirectoryOnly).FirstOrDefault();
            if (spatialDll == null)
            {
                throw new FileNotFoundException("No se encontró ningún SqlServerSpatial*.dll en " + nativeBinaryPath);
            }

            // load spatial dll
            LoadNativeAssembly(spatialDll);

            // optionally try to load msvcr120 if present (not required for newer packages)
            var msvc = Path.Combine(nativeBinaryPath, "msvcr120.dll");
            if (File.Exists(msvc))
            {
                LoadNativeAssembly(msvc);
            }
        }

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            // Check presence of at least one SqlServerSpatial DLL under x64/x86
            string x64Dir = Path.Combine(baseDir, "SqlServerTypes", "x64");
            string x86Dir = Path.Combine(baseDir, "SqlServerTypes", "x86");

            bool hasAnySpatial = (Directory.Exists(x64Dir) && Directory.EnumerateFiles(x64Dir, "SqlServerSpatial*.dll").Any())
                                 || (Directory.Exists(x86Dir) && Directory.EnumerateFiles(x86Dir, "SqlServerSpatial*.dll").Any());

            if (!hasAnySpatial)
            {
                var msg = "No se encontró ningún ensamblado nativo SqlServerSpatial en las carpetas:\n\n";
                msg += $" - {x64Dir}\n";
                msg += $" - {x86Dir}\n\n";
                msg += "Soluciones recomendadas:\n";
                msg += "1) Instala el paquete NuGet 'Microsoft.SqlServer.Types' en el proyecto desde Visual Studio.\n";
                msg += "2) Ejecuta el script 'scripts\\get-sqlservertypes.ps1' para extraer los binarios al proyecto.\n";
                msg += "3) Copia los archivos nativos (SqlServerSpatial*.dll y opcionalmente msvcr120.dll) a las carpetas SqlServerTypes\\x64 y SqlServerTypes\\x86 y en Visual Studio marca 'Copy to Output Directory = Copy if newer'.\n";
                MessageBox.Show(msg, "Faltan ensamblados nativos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Load appropriate native dll for current process bitness
                LoadNativeAssemblies(baseDir);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando ensamblados nativos de SqlServerTypes:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new Login());
        }
    }
}
