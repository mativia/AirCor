using System;
using System.IO;
using System.Windows.Forms;

namespace tp_pav1_grupo10.Utilities
{
    public static class ErrorHandler
    {
        private static readonly string LogDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");
        private static readonly string LogFile = Path.Combine(LogDirectory, "app.log");

        public static void Log(Exception ex, string contexto = null)
        {
            try
            {
                if (!Directory.Exists(LogDirectory))
                    Directory.CreateDirectory(LogDirectory);

                using (var sw = new StreamWriter(LogFile, true))
                {
                    sw.WriteLine("------------------------------------------------------------");
                    sw.WriteLine($"Fecha: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    if (!string.IsNullOrEmpty(contexto))
                        sw.WriteLine($"Contexto: {contexto}");
                    sw.WriteLine(ex.ToString());
                    sw.WriteLine();
                }
            }
            catch
            {
                // No hacer nada si falla el logging para no romper la aplicación
            }
        }

        public static void ShowError(Form owner, Exception ex, string mensajeAmigable = null, string contexto = null)
        {
            try
            {
                // Log detallado
                Log(ex, contexto);

                // Mostrar mensaje amigable al usuario
                string texto = mensajeAmigable ?? "Ocurrió un error inesperado. Comuníquese con el administrador.";
                MessageBox.Show(owner, texto, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                // Si algo falla al mostrar, caemos a mostrar el mensaje básico
                try { MessageBox.Show(owner, "Ocurrió un error inesperado.", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); } catch { }
            }
        }
    }
}
