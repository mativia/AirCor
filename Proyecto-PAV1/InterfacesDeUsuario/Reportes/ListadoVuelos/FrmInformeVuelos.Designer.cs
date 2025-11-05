namespace tp_pav1_grupo10.InterfacesDeUsuario.Reportes.ListadoVuelos
{
    partial class FrmInformeVuelos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInformeVuelos));
            this.rwListadoVuelos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rwListadoVuelos
            // 
            this.rwListadoVuelos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rwListadoVuelos.LocalReport.ReportEmbeddedResource = "tp_pav1_grupo10.InterfacesDeUsuario.Reportes.ListadoVuelos.InfVuelos.rdlc";
            this.rwListadoVuelos.Location = new System.Drawing.Point(0, 0);
            this.rwListadoVuelos.Margin = new System.Windows.Forms.Padding(2);
            this.rwListadoVuelos.Name = "rwListadoVuelos";
            this.rwListadoVuelos.ServerReport.BearerToken = null;
            this.rwListadoVuelos.Size = new System.Drawing.Size(938, 892);
            this.rwListadoVuelos.TabIndex = 0;
            this.rwListadoVuelos.Load += new System.EventHandler(this.rwListadoVuelos_Load);
            // 
            // FrmInformeVuelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 892);
            this.Controls.Add(this.rwListadoVuelos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmInformeVuelos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informe: Listado de vuelos pendientes";
            this.Load += new System.EventHandler(this.FrmInformeVuelos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rwListadoVuelos;
    }
}