namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    partial class FrmPerfiles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPerfiles));
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkReservas = new System.Windows.Forms.CheckBox();
            this.chkRegistros = new System.Windows.Forms.CheckBox();
            this.chkEstadoVuelo = new System.Windows.Forms.CheckBox();
            this.chkReportes = new System.Windows.Forms.CheckBox();
            this.chkSeguridad = new System.Windows.Forms.CheckBox();
            this.chkPlanificarVuelos = new System.Windows.Forms.CheckBox();
            this.dgvPerfiles = new System.Windows.Forms.DataGridView();
            this.ColumnImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.IdPerfiles = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seguridad = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Reportes = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PlanificarVuelos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EstadoVuelos = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Registros = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Reservas = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.lblIdPerfil = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).BeginInit();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(248, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(618, 48);
            this.label10.TabIndex = 68;
            this.label10.Text = "Lista de Perfiles:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 17);
            this.label1.TabIndex = 67;
            this.label1.Text = "Detalle de Perfiles:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(22, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 65;
            this.label6.Text = "Permisos:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(25, 46);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(167, 20);
            this.txtNombre.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 450);
            this.label2.TabIndex = 62;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chkReservas);
            this.panel1.Controls.Add(this.chkRegistros);
            this.panel1.Controls.Add(this.chkEstadoVuelo);
            this.panel1.Controls.Add(this.chkReportes);
            this.panel1.Controls.Add(this.chkSeguridad);
            this.panel1.Controls.Add(this.chkPlanificarVuelos);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(20, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 152);
            this.panel1.TabIndex = 72;
            // 
            // chkReservas
            // 
            this.chkReservas.AutoSize = true;
            this.chkReservas.Location = new System.Drawing.Point(18, 127);
            this.chkReservas.Name = "chkReservas";
            this.chkReservas.Size = new System.Drawing.Size(71, 17);
            this.chkReservas.TabIndex = 5;
            this.chkReservas.Text = "Reservas";
            this.chkReservas.UseVisualStyleBackColor = true;
            // 
            // chkRegistros
            // 
            this.chkRegistros.AutoSize = true;
            this.chkRegistros.Location = new System.Drawing.Point(19, 104);
            this.chkRegistros.Name = "chkRegistros";
            this.chkRegistros.Size = new System.Drawing.Size(70, 17);
            this.chkRegistros.TabIndex = 4;
            this.chkRegistros.Text = "Registros";
            this.chkRegistros.UseVisualStyleBackColor = true;
            // 
            // chkEstadoVuelo
            // 
            this.chkEstadoVuelo.AutoSize = true;
            this.chkEstadoVuelo.Location = new System.Drawing.Point(19, 81);
            this.chkEstadoVuelo.Name = "chkEstadoVuelo";
            this.chkEstadoVuelo.Size = new System.Drawing.Size(94, 17);
            this.chkEstadoVuelo.TabIndex = 3;
            this.chkEstadoVuelo.Text = "Estado Vuelos";
            this.chkEstadoVuelo.UseVisualStyleBackColor = true;
            // 
            // chkReportes
            // 
            this.chkReportes.AutoSize = true;
            this.chkReportes.Location = new System.Drawing.Point(19, 35);
            this.chkReportes.Name = "chkReportes";
            this.chkReportes.Size = new System.Drawing.Size(69, 17);
            this.chkReportes.TabIndex = 1;
            this.chkReportes.Text = "Reportes";
            this.chkReportes.UseVisualStyleBackColor = true;
            // 
            // chkSeguridad
            // 
            this.chkSeguridad.AutoSize = true;
            this.chkSeguridad.Location = new System.Drawing.Point(19, 12);
            this.chkSeguridad.Name = "chkSeguridad";
            this.chkSeguridad.Size = new System.Drawing.Size(74, 17);
            this.chkSeguridad.TabIndex = 0;
            this.chkSeguridad.Text = "Seguridad";
            this.chkSeguridad.UseVisualStyleBackColor = true;
            // 
            // chkPlanificarVuelos
            // 
            this.chkPlanificarVuelos.AutoSize = true;
            this.chkPlanificarVuelos.Location = new System.Drawing.Point(19, 58);
            this.chkPlanificarVuelos.Name = "chkPlanificarVuelos";
            this.chkPlanificarVuelos.Size = new System.Drawing.Size(104, 17);
            this.chkPlanificarVuelos.TabIndex = 2;
            this.chkPlanificarVuelos.Text = "Planificar Vuelos";
            this.chkPlanificarVuelos.UseVisualStyleBackColor = true;
            // 
            // dgvPerfiles
            // 
            this.dgvPerfiles.AllowUserToAddRows = false;
            this.dgvPerfiles.AllowUserToDeleteRows = false;
            this.dgvPerfiles.AllowUserToResizeColumns = false;
            this.dgvPerfiles.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPerfiles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPerfiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPerfiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnImg,
            this.IdPerfiles,
            this.Nombre,
            this.Seguridad,
            this.Reportes,
            this.PlanificarVuelos,
            this.EstadoVuelos,
            this.Registros,
            this.Reservas});
            this.dgvPerfiles.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvPerfiles.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvPerfiles.Location = new System.Drawing.Point(248, 68);
            this.dgvPerfiles.MultiSelect = false;
            this.dgvPerfiles.Name = "dgvPerfiles";
            this.dgvPerfiles.ReadOnly = true;
            this.dgvPerfiles.RowHeadersVisible = false;
            this.dgvPerfiles.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPerfiles.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPerfiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPerfiles.Size = new System.Drawing.Size(618, 361);
            this.dgvPerfiles.TabIndex = 73;
            this.dgvPerfiles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPerfiles_CellClick);
            // 
            // ColumnImg
            // 
            this.ColumnImg.HeaderText = "Selección";
            this.ColumnImg.Image = global::tp_pav1_grupo10.Properties.Resources.png_sin_nada;
            this.ColumnImg.Name = "ColumnImg";
            this.ColumnImg.ReadOnly = true;
            this.ColumnImg.Width = 60;
            // 
            // IdPerfiles
            // 
            this.IdPerfiles.HeaderText = "IdPerfiles";
            this.IdPerfiles.Name = "IdPerfiles";
            this.IdPerfiles.ReadOnly = true;
            this.IdPerfiles.Visible = false;
            this.IdPerfiles.Width = 75;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 69;
            // 
            // Seguridad
            // 
            this.Seguridad.HeaderText = "Seguridad";
            this.Seguridad.Name = "Seguridad";
            this.Seguridad.ReadOnly = true;
            this.Seguridad.Width = 61;
            // 
            // Reportes
            // 
            this.Reportes.HeaderText = "Reportes";
            this.Reportes.Name = "Reportes";
            this.Reportes.ReadOnly = true;
            this.Reportes.Width = 56;
            // 
            // PlanificarVuelos
            // 
            this.PlanificarVuelos.HeaderText = "Planificar Vuelos";
            this.PlanificarVuelos.Name = "PlanificarVuelos";
            this.PlanificarVuelos.ReadOnly = true;
            this.PlanificarVuelos.Width = 82;
            // 
            // EstadoVuelos
            // 
            this.EstadoVuelos.HeaderText = "Estado Vuelos";
            this.EstadoVuelos.Name = "EstadoVuelos";
            this.EstadoVuelos.ReadOnly = true;
            this.EstadoVuelos.Width = 73;
            // 
            // Registros
            // 
            this.Registros.HeaderText = "Registros";
            this.Registros.Name = "Registros";
            this.Registros.ReadOnly = true;
            this.Registros.Width = 57;
            // 
            // Reservas
            // 
            this.Reservas.HeaderText = "Reservas";
            this.Reservas.Name = "Reservas";
            this.Reservas.ReadOnly = true;
            this.Reservas.Width = 58;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.btnLimpiar.IconColor = System.Drawing.Color.White;
            this.btnLimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiar.IconSize = 25;
            this.btnLimpiar.Location = new System.Drawing.Point(12, 362);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLimpiar.Size = new System.Drawing.Size(210, 35);
            this.btnLimpiar.TabIndex = 76;
            this.btnLimpiar.Text = "Limpiar Selección";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnEliminar.IconColor = System.Drawing.Color.White;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 25;
            this.btnEliminar.Location = new System.Drawing.Point(120, 403);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(102, 35);
            this.btnEliminar.TabIndex = 75;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 25;
            this.btnGuardar.Location = new System.Drawing.Point(12, 403);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGuardar.Size = new System.Drawing.Size(102, 35);
            this.btnGuardar.TabIndex = 74;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblIdPerfil
            // 
            this.lblIdPerfil.AutoSize = true;
            this.lblIdPerfil.BackColor = System.Drawing.Color.White;
            this.lblIdPerfil.ForeColor = System.Drawing.Color.Black;
            this.lblIdPerfil.Location = new System.Drawing.Point(19, 261);
            this.lblIdPerfil.Name = "lblIdPerfil";
            this.lblIdPerfil.Size = new System.Drawing.Size(15, 13);
            this.lblIdPerfil.TabIndex = 77;
            this.lblIdPerfil.Text = "id";
            this.lblIdPerfil.Visible = false;
            // 
            // FrmPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 450);
            this.Controls.Add(this.lblIdPerfil);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvPerfiles);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPerfiles";
            this.Text = "Registro de Perfiles";
            this.Load += new System.EventHandler(this.FrmPerfiles_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPerfiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkEstadoVuelo;
        private System.Windows.Forms.CheckBox chkReportes;
        private System.Windows.Forms.CheckBox chkSeguridad;
        private System.Windows.Forms.CheckBox chkPlanificarVuelos;
        private System.Windows.Forms.CheckBox chkReservas;
        private System.Windows.Forms.CheckBox chkRegistros;
        private System.Windows.Forms.DataGridView dgvPerfiles;
        private System.Windows.Forms.DataGridViewImageColumn ColumnImg;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.Label lblIdPerfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPerfiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seguridad;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Reportes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn PlanificarVuelos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EstadoVuelos;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Registros;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Reservas;
    }
}