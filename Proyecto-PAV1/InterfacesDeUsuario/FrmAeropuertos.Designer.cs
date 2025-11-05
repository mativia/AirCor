namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    partial class FrmAeropuertos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAeropuertos));
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.lblCiudad = new System.Windows.Forms.Label();
            this.dgvAeropuerto = new System.Windows.Forms.DataGridView();
            this.ColumnImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblListaAeropuerto = new System.Windows.Forms.Label();
            this.lblAeropuerto = new System.Windows.Forms.Label();
            this.lblNroCalle = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.lblCalle = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblNombreAeropuerto = new System.Windows.Forms.Label();
            this.txtNombreAeropuerto = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.asd = new System.Windows.Forms.Label();
            this.txtNroCalle = new System.Windows.Forms.MaskedTextBox();
            this.cmbCiudad = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.lblIdAeropuerto = new System.Windows.Forms.Label();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAeropuerto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.BackColor = System.Drawing.Color.White;
            this.lblTelefono.ForeColor = System.Drawing.Color.Black;
            this.lblTelefono.Location = new System.Drawing.Point(22, 187);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(52, 13);
            this.lblTelefono.TabIndex = 93;
            this.lblTelefono.Text = "Telefono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(25, 203);
            this.txtTelefono.Mask = "99999999";
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(167, 20);
            this.txtTelefono.TabIndex = 92;
            this.txtTelefono.ValidatingType = typeof(int);
            // 
            // lblCiudad
            // 
            this.lblCiudad.AutoSize = true;
            this.lblCiudad.BackColor = System.Drawing.Color.White;
            this.lblCiudad.ForeColor = System.Drawing.Color.Black;
            this.lblCiudad.Location = new System.Drawing.Point(22, 226);
            this.lblCiudad.Name = "lblCiudad";
            this.lblCiudad.Size = new System.Drawing.Size(43, 13);
            this.lblCiudad.TabIndex = 86;
            this.lblCiudad.Text = "Ciudad:";
            // 
            // dgvAeropuerto
            // 
            this.dgvAeropuerto.AllowUserToAddRows = false;
            this.dgvAeropuerto.AllowUserToDeleteRows = false;
            this.dgvAeropuerto.AllowUserToResizeColumns = false;
            this.dgvAeropuerto.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvAeropuerto.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAeropuerto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAeropuerto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnImg});
            this.dgvAeropuerto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvAeropuerto.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvAeropuerto.Location = new System.Drawing.Point(253, 77);
            this.dgvAeropuerto.Name = "dgvAeropuerto";
            this.dgvAeropuerto.ReadOnly = true;
            this.dgvAeropuerto.RowHeadersVisible = false;
            this.dgvAeropuerto.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvAeropuerto.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAeropuerto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAeropuerto.Size = new System.Drawing.Size(714, 361);
            this.dgvAeropuerto.TabIndex = 74;
            this.dgvAeropuerto.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAeropuerto_CellClick);
            // 
            // ColumnImg
            // 
            this.ColumnImg.HeaderText = "Selección";
            this.ColumnImg.Image = global::tp_pav1_grupo10.Properties.Resources.png_sin_nada;
            this.ColumnImg.MinimumWidth = 6;
            this.ColumnImg.Name = "ColumnImg";
            this.ColumnImg.ReadOnly = true;
            this.ColumnImg.Width = 60;
            // 
            // lblListaAeropuerto
            // 
            this.lblListaAeropuerto.BackColor = System.Drawing.Color.White;
            this.lblListaAeropuerto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblListaAeropuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblListaAeropuerto.ForeColor = System.Drawing.Color.Black;
            this.lblListaAeropuerto.Location = new System.Drawing.Point(253, 12);
            this.lblListaAeropuerto.Name = "lblListaAeropuerto";
            this.lblListaAeropuerto.Size = new System.Drawing.Size(714, 48);
            this.lblListaAeropuerto.TabIndex = 82;
            this.lblListaAeropuerto.Text = "Lista de Aeropuertos:";
            this.lblListaAeropuerto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAeropuerto
            // 
            this.lblAeropuerto.AutoSize = true;
            this.lblAeropuerto.BackColor = System.Drawing.Color.White;
            this.lblAeropuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAeropuerto.ForeColor = System.Drawing.Color.Black;
            this.lblAeropuerto.Location = new System.Drawing.Point(19, 9);
            this.lblAeropuerto.Name = "lblAeropuerto";
            this.lblAeropuerto.Size = new System.Drawing.Size(154, 17);
            this.lblAeropuerto.TabIndex = 81;
            this.lblAeropuerto.Text = "Detalle del Aeropuerto:";
            // 
            // lblNroCalle
            // 
            this.lblNroCalle.AutoSize = true;
            this.lblNroCalle.BackColor = System.Drawing.Color.White;
            this.lblNroCalle.ForeColor = System.Drawing.Color.Black;
            this.lblNroCalle.Location = new System.Drawing.Point(22, 147);
            this.lblNroCalle.Name = "lblNroCalle";
            this.lblNroCalle.Size = new System.Drawing.Size(73, 13);
            this.lblNroCalle.TabIndex = 79;
            this.lblNroCalle.Text = "Numero Calle:";
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(25, 124);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(167, 20);
            this.txtCalle.TabIndex = 78;
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.BackColor = System.Drawing.Color.White;
            this.lblCalle.ForeColor = System.Drawing.Color.Black;
            this.lblCalle.Location = new System.Drawing.Point(22, 108);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(33, 13);
            this.lblCalle.TabIndex = 77;
            this.lblCalle.Text = "Calle:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(25, 85);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(167, 20);
            this.txtCodigo.TabIndex = 76;
            // 
            // lblNombreAeropuerto
            // 
            this.lblNombreAeropuerto.AutoSize = true;
            this.lblNombreAeropuerto.BackColor = System.Drawing.Color.White;
            this.lblNombreAeropuerto.ForeColor = System.Drawing.Color.Black;
            this.lblNombreAeropuerto.Location = new System.Drawing.Point(22, 30);
            this.lblNombreAeropuerto.Name = "lblNombreAeropuerto";
            this.lblNombreAeropuerto.Size = new System.Drawing.Size(47, 13);
            this.lblNombreAeropuerto.TabIndex = 75;
            this.lblNombreAeropuerto.Text = "Nombre:";
            // 
            // txtNombreAeropuerto
            // 
            this.txtNombreAeropuerto.Location = new System.Drawing.Point(25, 46);
            this.txtNombreAeropuerto.Name = "txtNombreAeropuerto";
            this.txtNombreAeropuerto.Size = new System.Drawing.Size(167, 20);
            this.txtNombreAeropuerto.TabIndex = 74;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.BackColor = System.Drawing.Color.White;
            this.lblCodigo.ForeColor = System.Drawing.Color.Black;
            this.lblCodigo.Location = new System.Drawing.Point(22, 69);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 73;
            this.lblCodigo.Text = "Codigo:";
            // 
            // asd
            // 
            this.asd.BackColor = System.Drawing.Color.White;
            this.asd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.asd.Dock = System.Windows.Forms.DockStyle.Left;
            this.asd.Location = new System.Drawing.Point(0, 0);
            this.asd.Name = "asd";
            this.asd.Size = new System.Drawing.Size(238, 450);
            this.asd.TabIndex = 72;
            // 
            // txtNroCalle
            // 
            this.txtNroCalle.Location = new System.Drawing.Point(25, 163);
            this.txtNroCalle.Mask = "99999";
            this.txtNroCalle.Name = "txtNroCalle";
            this.txtNroCalle.Size = new System.Drawing.Size(167, 20);
            this.txtNroCalle.TabIndex = 94;
            this.txtNroCalle.ValidatingType = typeof(int);
            // 
            // cmbCiudad
            // 
            this.cmbCiudad.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.cmbCiudad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCiudad.ForeColor = System.Drawing.Color.Black;
            this.cmbCiudad.FormattingEnabled = true;
            this.cmbCiudad.Location = new System.Drawing.Point(25, 242);
            this.cmbCiudad.Name = "cmbCiudad";
            this.cmbCiudad.Size = new System.Drawing.Size(167, 21);
            this.cmbCiudad.TabIndex = 95;
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
            this.btnLimpiar.Location = new System.Drawing.Point(12, 356);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLimpiar.Size = new System.Drawing.Size(210, 35);
            this.btnLimpiar.TabIndex = 96;
            this.btnLimpiar.Text = "Limpiar Selección";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblIdAeropuerto
            // 
            this.lblIdAeropuerto.AutoSize = true;
            this.lblIdAeropuerto.Location = new System.Drawing.Point(22, 276);
            this.lblIdAeropuerto.Name = "lblIdAeropuerto";
            this.lblIdAeropuerto.Size = new System.Drawing.Size(35, 13);
            this.lblIdAeropuerto.TabIndex = 97;
            this.lblIdAeropuerto.Text = "label3";
            this.lblIdAeropuerto.Visible = false;
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
            this.btnEliminar.Location = new System.Drawing.Point(120, 397);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(102, 35);
            this.btnEliminar.TabIndex = 99;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
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
            this.btnGuardar.Location = new System.Drawing.Point(12, 397);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGuardar.Size = new System.Drawing.Size(102, 35);
            this.btnGuardar.TabIndex = 98;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // FrmAeropuertos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 450);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblIdAeropuerto);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.cmbCiudad);
            this.Controls.Add(this.txtNroCalle);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.lblCiudad);
            this.Controls.Add(this.dgvAeropuerto);
            this.Controls.Add(this.lblListaAeropuerto);
            this.Controls.Add(this.lblAeropuerto);
            this.Controls.Add(this.lblNroCalle);
            this.Controls.Add(this.txtCalle);
            this.Controls.Add(this.lblCalle);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblNombreAeropuerto);
            this.Controls.Add(this.txtNombreAeropuerto);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.asd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAeropuertos";
            this.Text = "Registro de Aeropuertos";
            this.Load += new System.EventHandler(this.FrmAeropuertos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAeropuerto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.MaskedTextBox txtTelefono;
        private System.Windows.Forms.Label lblCiudad;
        private System.Windows.Forms.DataGridView dgvAeropuerto;
        private System.Windows.Forms.Label lblListaAeropuerto;
        private System.Windows.Forms.Label lblAeropuerto;
        private System.Windows.Forms.Label lblNroCalle;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblNombreAeropuerto;
        private System.Windows.Forms.TextBox txtNombreAeropuerto;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Label asd;
        private System.Windows.Forms.MaskedTextBox txtNroCalle;
        private System.Windows.Forms.ComboBox cmbCiudad;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private System.Windows.Forms.Label lblIdAeropuerto;
        private System.Windows.Forms.DataGridViewImageColumn ColumnImg;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnGuardar;
    }
}