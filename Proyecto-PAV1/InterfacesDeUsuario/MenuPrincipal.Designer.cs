namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.imiSeguridad = new FontAwesome.Sharp.IconMenuItem();
            this.iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            this.imiCerrarSesion = new FontAwesome.Sharp.IconMenuItem();
            this.imiReportes = new FontAwesome.Sharp.IconMenuItem();
            this.imiEstadisticaPasajes = new FontAwesome.Sharp.IconMenuItem();
            this.imiInformeVuelos = new FontAwesome.Sharp.IconMenuItem();
            this.imiInformeDetalladoVuelo = new FontAwesome.Sharp.IconMenuItem();
            this.imiVuelos = new FontAwesome.Sharp.IconMenuItem();
            this.imiPlanificarVuelos = new FontAwesome.Sharp.IconMenuItem();
            this.imiConsultarEstados = new FontAwesome.Sharp.IconMenuItem();
            this.imiRegistros = new FontAwesome.Sharp.IconMenuItem();
            this.imiPasajeros = new FontAwesome.Sharp.IconMenuItem();
            this.imiAviones = new FontAwesome.Sharp.IconMenuItem();
            this.imiAeropuertos = new FontAwesome.Sharp.IconMenuItem();
            this.imiPaises = new FontAwesome.Sharp.IconMenuItem();
            this.imiProvincias = new FontAwesome.Sharp.IconMenuItem();
            this.imiCiudades = new FontAwesome.Sharp.IconMenuItem();
            this.imiEmpleados = new FontAwesome.Sharp.IconMenuItem();
            this.imiReservas = new FontAwesome.Sharp.IconMenuItem();
            this.imiConsultarReserva = new FontAwesome.Sharp.IconMenuItem();
            this.imiRegistrarReserva = new FontAwesome.Sharp.IconMenuItem();
            this.lblUsuLogueado = new System.Windows.Forms.Label();
            this.lblPerfil = new System.Windows.Forms.Label();
            this.iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161))))); // Azul oscuro
            this.menuStrip1.ForeColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imiSeguridad,
            this.imiReportes,
            this.imiVuelos,
            this.imiRegistros,
            this.imiReservas});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1350, 86);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // imiSeguridad
            // 
            this.imiSeguridad.AutoSize = false;
            this.imiSeguridad.BackColor = System.Drawing.Color.Transparent;
            this.imiSeguridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconMenuItem2,
            this.iconMenuItem1,
            this.imiCerrarSesion});
            this.imiSeguridad.Enabled = false;
            this.imiSeguridad.IconChar = FontAwesome.Sharp.IconChar.UserLock;
            this.imiSeguridad.IconColor = System.Drawing.Color.White;
            this.imiSeguridad.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiSeguridad.IconSize = 44;
            this.imiSeguridad.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiSeguridad.Name = "imiSeguridad";
            this.imiSeguridad.Padding = new System.Windows.Forms.Padding(8);
            this.imiSeguridad.Size = new System.Drawing.Size(140, 74);
            this.imiSeguridad.Text = "Seguridad";
            this.imiSeguridad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.imiSeguridad.Click += new System.EventHandler(this.imiSeguridad_Click);
            // 
            // iconMenuItem2
            // 
            this.iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.iconMenuItem2.IconColor = System.Drawing.Color.White;
            this.iconMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem2.IconSize = 36;
            this.iconMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iconMenuItem2.Name = "iconMenuItem2";
            this.iconMenuItem2.Size = new System.Drawing.Size(220, 46);
            this.iconMenuItem2.Text = "Usuarios";
            this.iconMenuItem2.Click += new System.EventHandler(this.iconMenuItem2_Click);
            // 
            // imiCerrarSesion
            // 
            this.imiCerrarSesion.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.imiCerrarSesion.IconColor = System.Drawing.Color.White;
            this.imiCerrarSesion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiCerrarSesion.IconSize = 36;
            this.imiCerrarSesion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiCerrarSesion.Name = "imiCerrarSesion";
            this.imiCerrarSesion.Size = new System.Drawing.Size(220, 46);
            this.imiCerrarSesion.Text = "Cerrar Sesión";
            this.imiCerrarSesion.Click += new System.EventHandler(this.iconMenuItem3_Click);
            // 
            // imiReportes
            // 
            this.imiReportes.AutoSize = false;
            this.imiReportes.BackColor = System.Drawing.Color.Transparent;
            this.imiReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imiEstadisticaPasajes,
            this.imiInformeVuelos,
            this.imiInformeDetalladoVuelo});
            this.imiReportes.Enabled = false;
            this.imiReportes.IconChar = FontAwesome.Sharp.IconChar.AreaChart;
            this.imiReportes.IconColor = System.Drawing.Color.White;
            this.imiReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiReportes.IconSize = 44;
            this.imiReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiReportes.Name = "imiReportes";
            this.imiReportes.Padding = new System.Windows.Forms.Padding(8);
            this.imiReportes.Size = new System.Drawing.Size(120, 74);
            this.imiReportes.Text = "Reportes";
            this.imiReportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.imiReportes.Click += new System.EventHandler(this.imiReportes_Click);
            // 
            // imiEstadisticaPasajes
            // 
            this.imiEstadisticaPasajes.IconChar = FontAwesome.Sharp.IconChar.PieChart;
            this.imiEstadisticaPasajes.IconColor = System.Drawing.Color.White;
            this.imiEstadisticaPasajes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiEstadisticaPasajes.IconSize = 36;
            this.imiEstadisticaPasajes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiEstadisticaPasajes.Name = "imiEstadisticaPasajes";
            this.imiEstadisticaPasajes.Size = new System.Drawing.Size(242, 46);
            this.imiEstadisticaPasajes.Text = "Estadistica de Pasajes";
            this.imiEstadisticaPasajes.Click += new System.EventHandler(this.imiEstadisticaPasajes_Click);
            // 
            // imiInformeVuelos
            // 
            this.imiInformeVuelos.IconChar = FontAwesome.Sharp.IconChar.FileAlt;
            this.imiInformeVuelos.IconColor = System.Drawing.Color.White;
            this.imiInformeVuelos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiInformeVuelos.IconSize = 36;
            this.imiInformeVuelos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiInformeVuelos.Name = "imiInformeVuelos";
            this.imiInformeVuelos.Size = new System.Drawing.Size(242, 46);
            this.imiInformeVuelos.Text = "Informe de Vuelos";
            this.imiInformeVuelos.Click += new System.EventHandler(this.imiInformeVuelos_Click);
            // 
            // imiInformeDetalladoVuelo
            // 
            this.imiInformeDetalladoVuelo.IconChar = FontAwesome.Sharp.IconChar.FileAlt;
            this.imiInformeDetalladoVuelo.IconColor = System.Drawing.Color.White;
            this.imiInformeDetalladoVuelo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiInformeDetalladoVuelo.IconSize = 36;
            this.imiInformeDetalladoVuelo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiInformeDetalladoVuelo.Name = "imiInformeDetalladoVuelo";
            this.imiInformeDetalladoVuelo.Size = new System.Drawing.Size(242, 46);
            this.imiInformeDetalladoVuelo.Text = "Informe Detallado de Vuelo";
            this.imiInformeDetalladoVuelo.Click += new System.EventHandler(this.imiInformeDetalladoVuelo_Click);
            // 
            // imiVuelos
            // 
            this.imiVuelos.AutoSize = false;
            this.imiVuelos.BackColor = System.Drawing.Color.Transparent;
            this.imiVuelos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imiPlanificarVuelos,
            this.imiConsultarEstados});
            this.imiVuelos.Enabled = false;
            this.imiVuelos.IconChar = FontAwesome.Sharp.IconChar.PlaneDeparture;
            this.imiVuelos.IconColor = System.Drawing.Color.White;
            this.imiVuelos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiVuelos.IconSize = 44;
            this.imiVuelos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiVuelos.Name = "imiVuelos";
            this.imiVuelos.Padding = new System.Windows.Forms.Padding(8);
            this.imiVuelos.Size = new System.Drawing.Size(120, 74);
            this.imiVuelos.Text = "Vuelos";
            this.imiVuelos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.imiVuelos.Click += new System.EventHandler(this.imiVuelos_Click);
            // 
            // imiPlanificarVuelos
            // 
            this.imiPlanificarVuelos.Enabled = false;
            this.imiPlanificarVuelos.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.imiPlanificarVuelos.IconColor = System.Drawing.Color.White;
            this.imiPlanificarVuelos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiPlanificarVuelos.IconSize = 36;
            this.imiPlanificarVuelos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiPlanificarVuelos.Name = "imiPlanificarVuelos";
            this.imiPlanificarVuelos.Size = new System.Drawing.Size(185, 46);
            this.imiPlanificarVuelos.Text = "Planificar Vuelos";
            this.imiPlanificarVuelos.Click += new System.EventHandler(this.imiPlanificarVuelos_Click);
            // 
            // imiConsultarEstados
            // 
            this.imiConsultarEstados.Enabled = false;
            this.imiConsultarEstados.IconChar = FontAwesome.Sharp.IconChar.PlaneCircleExclamation;
            this.imiConsultarEstados.IconColor = System.Drawing.Color.White;
            this.imiConsultarEstados.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiConsultarEstados.IconSize = 36;
            this.imiConsultarEstados.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiConsultarEstados.Name = "imiConsultarEstados";
            this.imiConsultarEstados.Size = new System.Drawing.Size(185, 46);
            this.imiConsultarEstados.Text = "Estado Vuelos";
            this.imiConsultarEstados.Click += new System.EventHandler(this.imiConsultarEstados_Click);
            // 
            // imiRegistros
            // 
            this.imiRegistros.AutoSize = false;
            this.imiRegistros.BackColor = System.Drawing.Color.Transparent;
            this.imiRegistros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imiPasajeros,
            this.imiAviones,
            this.imiAeropuertos,
            this.imiPaises,
            this.imiProvincias,
            this.imiCiudades,
            this.imiEmpleados});
            this.imiRegistros.Enabled = false;
            this.imiRegistros.IconChar = FontAwesome.Sharp.IconChar.FilePen;
            this.imiRegistros.IconColor = System.Drawing.Color.White;
            this.imiRegistros.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiRegistros.IconSize = 44;
            this.imiRegistros.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiRegistros.Name = "imiRegistros";
            this.imiRegistros.Padding = new System.Windows.Forms.Padding(8);
            this.imiRegistros.Size = new System.Drawing.Size(120, 74);
            this.imiRegistros.Text = "Registros";
            this.imiRegistros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.imiRegistros.Click += new System.EventHandler(this.imiRegistros_Click);
            // 
            // imiPasajeros
            // 
            this.imiPasajeros.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.imiPasajeros.IconColor = System.Drawing.Color.White;
            this.imiPasajeros.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiPasajeros.IconSize = 36;
            this.imiPasajeros.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiPasajeros.Name = "imiPasajeros";
            this.imiPasajeros.Size = new System.Drawing.Size(163, 46);
            this.imiPasajeros.Text = "Pasajeros";
            this.imiPasajeros.Click += new System.EventHandler(this.imiPasajeros_Click);
            // 
            // imiAviones
            // 
            this.imiAviones.IconChar = FontAwesome.Sharp.IconChar.Plane;
            this.imiAviones.IconColor = System.Drawing.Color.White;
            this.imiAviones.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiAviones.IconSize = 36;
            this.imiAviones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiAviones.Name = "imiAviones";
            this.imiAviones.Size = new System.Drawing.Size(163, 46);
            this.imiAviones.Text = "Aviones";
            this.imiAviones.Click += new System.EventHandler(this.imiAviones_Click);
            // 
            // imiAeropuertos
            // 
            this.imiAeropuertos.IconChar = FontAwesome.Sharp.IconChar.PlaneUp;
            this.imiAeropuertos.IconColor = System.Drawing.Color.White;
            this.imiAeropuertos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiAeropuertos.IconSize = 36;
            this.imiAeropuertos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiAeropuertos.Name = "imiAeropuertos";
            this.imiAeropuertos.Size = new System.Drawing.Size(163, 46);
            this.imiAeropuertos.Text = "Aeropuertos";
            this.imiAeropuertos.Click += new System.EventHandler(this.imiAeropuertos_Click);
            // 
            // imiPaises
            // 
            this.imiPaises.IconChar = FontAwesome.Sharp.IconChar.EarthAmericas;
            this.imiPaises.IconColor = System.Drawing.Color.White;
            this.imiPaises.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiPaises.IconSize = 36;
            this.imiPaises.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiPaises.Name = "imiPaises";
            this.imiPaises.Size = new System.Drawing.Size(163, 46);
            this.imiPaises.Text = "Paises";
            this.imiPaises.Click += new System.EventHandler(this.imiPaises_Click);
            // 
            // imiProvincias
            // 
            this.imiProvincias.IconChar = FontAwesome.Sharp.IconChar.MapLocationDot;
            this.imiProvincias.IconColor = System.Drawing.Color.White;
            this.imiProvincias.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiProvincias.IconSize = 36;
            this.imiProvincias.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiProvincias.Name = "imiProvincias";
            this.imiProvincias.Size = new System.Drawing.Size(163, 46);
            this.imiProvincias.Text = "Provincias";
            this.imiProvincias.Click += new System.EventHandler(this.imiProvincias_Click);
            // 
            // imiCiudades
            // 
            this.imiCiudades.IconChar = FontAwesome.Sharp.IconChar.Building;
            this.imiCiudades.IconColor = System.Drawing.Color.White;
            this.imiCiudades.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiCiudades.IconSize = 36;
            this.imiCiudades.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiCiudades.Name = "imiCiudades";
            this.imiCiudades.Size = new System.Drawing.Size(163, 46);
            this.imiCiudades.Text = "Ciudades";
            this.imiCiudades.Click += new System.EventHandler(this.imiCiudades_Click);
            // 
            // imiEmpleados
            // 
            this.imiEmpleados.IconChar = FontAwesome.Sharp.IconChar.UserTie;
            this.imiEmpleados.IconColor = System.Drawing.Color.White;
            this.imiEmpleados.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiEmpleados.IconSize = 36;
            this.imiEmpleados.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiEmpleados.Name = "imiEmpleados";
            this.imiEmpleados.Size = new System.Drawing.Size(163, 46);
            this.imiEmpleados.Text = "Empleados";
            this.imiEmpleados.Click += new System.EventHandler(this.imiEmpleados_Click);
            // 
            // imiReservas
            // 
            this.imiReservas.AutoSize = false;
            this.imiReservas.BackColor = System.Drawing.Color.Transparent;
            this.imiReservas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imiConsultarReserva,
            this.imiRegistrarReserva});
            this.imiReservas.Enabled = false;
            this.imiReservas.IconChar = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.imiReservas.IconColor = System.Drawing.Color.White;
            this.imiReservas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiReservas.IconSize = 44;
            this.imiReservas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiReservas.Name = "imiReservas";
            this.imiReservas.Padding = new System.Windows.Forms.Padding(8);
            this.imiReservas.Size = new System.Drawing.Size(140, 74);
            this.imiReservas.Text = "Reservas";
            this.imiReservas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.imiReservas.Click += new System.EventHandler(this.imiReservas_Click);
            // 
            // imiConsultarReserva
            // 
            this.imiConsultarReserva.IconChar = FontAwesome.Sharp.IconChar.CalendarDay;
            this.imiConsultarReserva.IconColor = System.Drawing.Color.White;
            this.imiConsultarReserva.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiConsultarReserva.IconSize = 36;
            this.imiConsultarReserva.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiConsultarReserva.Name = "imiConsultarReserva";
            this.imiConsultarReserva.Size = new System.Drawing.Size(192, 46);
            this.imiConsultarReserva.Text = "Consultar Reserva";
            this.imiConsultarReserva.Click += new System.EventHandler(this.imiConsultarReserva_Click);
            // 
            // imiRegistrarReserva
            // 
            this.imiRegistrarReserva.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.imiRegistrarReserva.IconColor = System.Drawing.Color.White;
            this.imiRegistrarReserva.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.imiRegistrarReserva.IconSize = 36;
            this.imiRegistrarReserva.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imiRegistrarReserva.Name = "imiRegistrarReserva";
            this.imiRegistrarReserva.Size = new System.Drawing.Size(192, 46);
            this.imiRegistrarReserva.Text = "Registrar Reserva";
            this.imiRegistrarReserva.Click += new System.EventHandler(this.imiRegistrarReserva_Click);
            // 
            // lblUsuLogueado
            // 
            this.lblUsuLogueado.AutoSize = true;
            this.lblUsuLogueado.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuLogueado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuLogueado.ForeColor = System.Drawing.Color.White;
            this.lblUsuLogueado.Location = new System.Drawing.Point(1202, 18);
            this.lblUsuLogueado.Name = "lblUsuLogueado";
            this.lblUsuLogueado.Size = new System.Drawing.Size(98, 15);
            this.lblUsuLogueado.TabIndex = 1;
            this.lblUsuLogueado.Text = "lblUsuLogueado";
            // 
            // lblPerfil
            // 
            this.lblPerfil.AutoSize = true;
            this.lblPerfil.BackColor = System.Drawing.Color.Transparent;
            this.lblPerfil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerfil.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPerfil.Location = new System.Drawing.Point(1202, 44);
            this.lblPerfil.Name = "lblPerfil";
            this.lblPerfil.Size = new System.Drawing.Size(48, 15);
            this.lblPerfil.TabIndex = 2;
            this.lblPerfil.Text = "lblPerfil";
            // 
            // iconMenuItem1
            // 
            this.iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.DriversLicense;
            this.iconMenuItem1.IconColor = System.Drawing.Color.White;
            this.iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem1.IconSize = 36;
            this.iconMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.iconMenuItem1.Name = "iconMenuItem1";
            this.iconMenuItem1.Size = new System.Drawing.Size(204, 46);
            this.iconMenuItem1.Text = "Perfiles";
            this.iconMenuItem1.Click += new System.EventHandler(this.iconMenuItem1_Click_1);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::tp_pav1_grupo10.Properties.Resources.avion;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.lblPerfil);
            this.Controls.Add(this.lblUsuLogueado);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem imiRegistros;
        private FontAwesome.Sharp.IconMenuItem imiReportes;
        private FontAwesome.Sharp.IconMenuItem imiVuelos;
        private FontAwesome.Sharp.IconMenuItem imiPlanificarVuelos;
        private FontAwesome.Sharp.IconMenuItem imiConsultarEstados;
        private FontAwesome.Sharp.IconMenuItem imiAeropuertos;
        private FontAwesome.Sharp.IconMenuItem imiEmpleados;
        private FontAwesome.Sharp.IconMenuItem imiSeguridad;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
        private FontAwesome.Sharp.IconMenuItem imiCerrarSesion;
        private FontAwesome.Sharp.IconMenuItem imiPasajeros;
        private FontAwesome.Sharp.IconMenuItem imiAviones;
        private FontAwesome.Sharp.IconMenuItem imiPaises;
        private FontAwesome.Sharp.IconMenuItem imiProvincias;
        private FontAwesome.Sharp.IconMenuItem imiCiudades;
        private FontAwesome.Sharp.IconMenuItem imiReservas;
        private FontAwesome.Sharp.IconMenuItem imiConsultarReserva;
        private FontAwesome.Sharp.IconMenuItem imiRegistrarReserva;
        private FontAwesome.Sharp.IconMenuItem imiInformeVuelos;
        private FontAwesome.Sharp.IconMenuItem imiEstadisticaPasajes;
        private FontAwesome.Sharp.IconMenuItem imiInformeDetalladoVuelo;
        private System.Windows.Forms.Label lblUsuLogueado;
        private System.Windows.Forms.Label lblPerfil;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
    }
}