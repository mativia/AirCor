namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    partial class FrmConsultarVuelos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultarVuelos));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpFechaViaje = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.cmbCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.cmbCiudadDestino = new System.Windows.Forms.ComboBox();
            this.cmbAeropuertoOrigen = new System.Windows.Forms.ComboBox();
            this.cmbAeropuertoDestino = new System.Windows.Forms.ComboBox();
            this.chkHabilitarFecha = new System.Windows.Forms.CheckBox();
            this.btnConfirmarVuelo = new FontAwesome.Sharp.IconButton();
            this.dgvVuelos = new System.Windows.Forms.DataGridView();
            this.IdVuelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroVuelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CiudadOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodAeropuertoOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreAeropuertoOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CiudadDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodAeropuertoDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreAeropuertoDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPartida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorarioEmbarque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorarioPartida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorarioLlegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioClaseTurista = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioClaseBusiness = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioPrimeraClase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipbCirculo = new FontAwesome.Sharp.IconPictureBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuelos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipbCirculo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1245, 160);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(124, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Origen:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(481, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Destino:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(203, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 18);
            this.label5.TabIndex = 117;
            this.label5.Text = "Ciudad:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(562, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 18);
            this.label6.TabIndex = 121;
            this.label6.Text = "Ciudad:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.SteelBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(203, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 18);
            this.label8.TabIndex = 123;
            this.label8.Text = "Aeropuerto:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.SteelBlue;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(562, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 18);
            this.label9.TabIndex = 125;
            this.label9.Text = "Aeropuerto:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.SteelBlue;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(891, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 24);
            this.label10.TabIndex = 126;
            this.label10.Text = "Fecha de Viaje:";
            // 
            // dtpFechaViaje
            // 
            this.dtpFechaViaje.CalendarMonthBackground = System.Drawing.SystemColors.ButtonFace;
            this.dtpFechaViaje.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpFechaViaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaViaje.Location = new System.Drawing.Point(895, 43);
            this.dtpFechaViaje.MinDate = new System.DateTime(2022, 10, 3, 0, 0, 0, 0);
            this.dtpFechaViaje.Name = "dtpFechaViaje";
            this.dtpFechaViaje.Size = new System.Drawing.Size(281, 24);
            this.dtpFechaViaje.TabIndex = 127;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscar.IconColor = System.Drawing.Color.Black;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 25;
            this.btnBuscar.Location = new System.Drawing.Point(895, 79);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBuscar.Size = new System.Drawing.Size(281, 34);
            this.btnBuscar.TabIndex = 129;
            this.btnBuscar.Text = "Buscar Vuelos";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cmbCiudadOrigen
            // 
            this.cmbCiudadOrigen.FormattingEnabled = true;
            this.cmbCiudadOrigen.Location = new System.Drawing.Point(205, 43);
            this.cmbCiudadOrigen.Name = "cmbCiudadOrigen";
            this.cmbCiudadOrigen.Size = new System.Drawing.Size(255, 21);
            this.cmbCiudadOrigen.TabIndex = 130;
            this.cmbCiudadOrigen.TextUpdate += new System.EventHandler(this.cmbCiudadOrigen_TextUpdate);
            this.cmbCiudadOrigen.DropDownClosed += new System.EventHandler(this.cmbCiudadOrigen_DropDownClosed);
            this.cmbCiudadOrigen.TextChanged += new System.EventHandler(this.cmbCiudadOrigen_TextChanged);
            // 
            // cmbCiudadDestino
            // 
            this.cmbCiudadDestino.FormattingEnabled = true;
            this.cmbCiudadDestino.Location = new System.Drawing.Point(565, 43);
            this.cmbCiudadDestino.Name = "cmbCiudadDestino";
            this.cmbCiudadDestino.Size = new System.Drawing.Size(255, 21);
            this.cmbCiudadDestino.TabIndex = 131;
            this.cmbCiudadDestino.TextUpdate += new System.EventHandler(this.cmbCiudadDestino_TextUpdate);
            this.cmbCiudadDestino.DropDownClosed += new System.EventHandler(this.cmbCiudadDestino_DropDownClosed);
            this.cmbCiudadDestino.TextChanged += new System.EventHandler(this.cmbCiudadDestino_TextChanged);
            // 
            // cmbAeropuertoOrigen
            // 
            this.cmbAeropuertoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAeropuertoOrigen.Enabled = false;
            this.cmbAeropuertoOrigen.FormattingEnabled = true;
            this.cmbAeropuertoOrigen.Location = new System.Drawing.Point(206, 88);
            this.cmbAeropuertoOrigen.Name = "cmbAeropuertoOrigen";
            this.cmbAeropuertoOrigen.Size = new System.Drawing.Size(254, 21);
            this.cmbAeropuertoOrigen.TabIndex = 132;
            // 
            // cmbAeropuertoDestino
            // 
            this.cmbAeropuertoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAeropuertoDestino.Enabled = false;
            this.cmbAeropuertoDestino.FormattingEnabled = true;
            this.cmbAeropuertoDestino.Location = new System.Drawing.Point(565, 88);
            this.cmbAeropuertoDestino.Name = "cmbAeropuertoDestino";
            this.cmbAeropuertoDestino.Size = new System.Drawing.Size(255, 21);
            this.cmbAeropuertoDestino.TabIndex = 133;
            // 
            // chkHabilitarFecha
            // 
            this.chkHabilitarFecha.AutoSize = true;
            this.chkHabilitarFecha.BackColor = System.Drawing.Color.SteelBlue;
            this.chkHabilitarFecha.ForeColor = System.Drawing.Color.White;
            this.chkHabilitarFecha.Location = new System.Drawing.Point(1066, 22);
            this.chkHabilitarFecha.Name = "chkHabilitarFecha";
            this.chkHabilitarFecha.Size = new System.Drawing.Size(137, 17);
            this.chkHabilitarFecha.TabIndex = 134;
            this.chkHabilitarFecha.Text = "Habilitar Filtro de Fecha";
            this.chkHabilitarFecha.UseVisualStyleBackColor = false;
            this.chkHabilitarFecha.CheckedChanged += new System.EventHandler(this.chkHabilitarFecha_CheckedChanged);
            // 
            // btnConfirmarVuelo
            // 
            this.btnConfirmarVuelo.BackColor = System.Drawing.Color.ForestGreen;
            this.btnConfirmarVuelo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmarVuelo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnConfirmarVuelo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarVuelo.ForeColor = System.Drawing.Color.White;
            this.btnConfirmarVuelo.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnConfirmarVuelo.IconColor = System.Drawing.Color.White;
            this.btnConfirmarVuelo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConfirmarVuelo.IconSize = 25;
            this.btnConfirmarVuelo.Location = new System.Drawing.Point(1095, 530);
            this.btnConfirmarVuelo.Name = "btnConfirmarVuelo";
            this.btnConfirmarVuelo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnConfirmarVuelo.Size = new System.Drawing.Size(121, 35);
            this.btnConfirmarVuelo.TabIndex = 136;
            this.btnConfirmarVuelo.Text = "Confirmar Vuelo";
            this.btnConfirmarVuelo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmarVuelo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmarVuelo.UseVisualStyleBackColor = false;
            this.btnConfirmarVuelo.Click += new System.EventHandler(this.btnConfirmarVuelo_Click);
            // 
            // dgvVuelos
            // 
            this.dgvVuelos.AllowUserToAddRows = false;
            this.dgvVuelos.AllowUserToDeleteRows = false;
            this.dgvVuelos.AllowUserToOrderColumns = true;
            this.dgvVuelos.AllowUserToResizeColumns = false;
            this.dgvVuelos.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvVuelos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVuelos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVuelos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdVuelo,
            this.NroVuelo,
            this.CiudadOrigen,
            this.CodAeropuertoOrigen,
            this.NombreAeropuertoOrigen,
            this.CiudadDestino,
            this.CodAeropuertoDestino,
            this.NombreAeropuertoDestino,
            this.FechaPartida,
            this.HorarioEmbarque,
            this.HorarioPartida,
            this.HorarioLlegada,
            this.PrecioClaseTurista,
            this.PrecioClaseBusiness,
            this.PrecioPrimeraClase});
            this.dgvVuelos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvVuelos.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvVuelos.Location = new System.Drawing.Point(12, 163);
            this.dgvVuelos.MultiSelect = false;
            this.dgvVuelos.Name = "dgvVuelos";
            this.dgvVuelos.ReadOnly = true;
            this.dgvVuelos.RowHeadersVisible = false;
            this.dgvVuelos.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvVuelos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVuelos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVuelos.Size = new System.Drawing.Size(1221, 355);
            this.dgvVuelos.TabIndex = 128;
            this.dgvVuelos.SelectionChanged += new System.EventHandler(this.dgvVuelos_SelectionChanged);
            // 
            // IdVuelo
            // 
            this.IdVuelo.HeaderText = "IdVuelo";
            this.IdVuelo.Name = "IdVuelo";
            this.IdVuelo.ReadOnly = true;
            this.IdVuelo.Visible = false;
            // 
            // NroVuelo
            // 
            this.NroVuelo.HeaderText = "Nro de Vuelo";
            this.NroVuelo.Name = "NroVuelo";
            this.NroVuelo.ReadOnly = true;
            // 
            // CiudadOrigen
            // 
            this.CiudadOrigen.HeaderText = "Ciudad Origen";
            this.CiudadOrigen.Name = "CiudadOrigen";
            this.CiudadOrigen.ReadOnly = true;
            // 
            // CodAeropuertoOrigen
            // 
            this.CodAeropuertoOrigen.HeaderText = "Aeropuerto Origen";
            this.CodAeropuertoOrigen.Name = "CodAeropuertoOrigen";
            this.CodAeropuertoOrigen.ReadOnly = true;
            // 
            // NombreAeropuertoOrigen
            // 
            this.NombreAeropuertoOrigen.HeaderText = "NombreAeropuertoOrigen";
            this.NombreAeropuertoOrigen.Name = "NombreAeropuertoOrigen";
            this.NombreAeropuertoOrigen.ReadOnly = true;
            this.NombreAeropuertoOrigen.Visible = false;
            // 
            // CiudadDestino
            // 
            this.CiudadDestino.HeaderText = "Ciudad Destino";
            this.CiudadDestino.Name = "CiudadDestino";
            this.CiudadDestino.ReadOnly = true;
            // 
            // CodAeropuertoDestino
            // 
            this.CodAeropuertoDestino.HeaderText = "Aeropuerto Destino";
            this.CodAeropuertoDestino.Name = "CodAeropuertoDestino";
            this.CodAeropuertoDestino.ReadOnly = true;
            // 
            // NombreAeropuertoDestino
            // 
            this.NombreAeropuertoDestino.HeaderText = "NombreAeropuertoDestino";
            this.NombreAeropuertoDestino.Name = "NombreAeropuertoDestino";
            this.NombreAeropuertoDestino.ReadOnly = true;
            this.NombreAeropuertoDestino.Visible = false;
            // 
            // FechaPartida
            // 
            this.FechaPartida.HeaderText = "Fecha Partida";
            this.FechaPartida.Name = "FechaPartida";
            this.FechaPartida.ReadOnly = true;
            // 
            // HorarioEmbarque
            // 
            this.HorarioEmbarque.HeaderText = "Horario Embarque";
            this.HorarioEmbarque.Name = "HorarioEmbarque";
            this.HorarioEmbarque.ReadOnly = true;
            // 
            // HorarioPartida
            // 
            this.HorarioPartida.HeaderText = "Horario Partida";
            this.HorarioPartida.Name = "HorarioPartida";
            this.HorarioPartida.ReadOnly = true;
            // 
            // HorarioLlegada
            // 
            this.HorarioLlegada.HeaderText = "Horario Llegada";
            this.HorarioLlegada.Name = "HorarioLlegada";
            this.HorarioLlegada.ReadOnly = true;
            // 
            // PrecioClaseTurista
            // 
            this.PrecioClaseTurista.HeaderText = "Precio Clase Turista";
            this.PrecioClaseTurista.Name = "PrecioClaseTurista";
            this.PrecioClaseTurista.ReadOnly = true;
            // 
            // PrecioClaseBusiness
            // 
            this.PrecioClaseBusiness.HeaderText = "Precio Clase Business";
            this.PrecioClaseBusiness.Name = "PrecioClaseBusiness";
            this.PrecioClaseBusiness.ReadOnly = true;
            // 
            // PrecioPrimeraClase
            // 
            this.PrecioPrimeraClase.HeaderText = "Precio Primera Clase";
            this.PrecioPrimeraClase.Name = "PrecioPrimeraClase";
            this.PrecioPrimeraClase.ReadOnly = true;
            // 
            // ipbCirculo
            // 
            this.ipbCirculo.BackColor = System.Drawing.Color.SteelBlue;
            this.ipbCirculo.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.ipbCirculo.IconColor = System.Drawing.Color.White;
            this.ipbCirculo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ipbCirculo.IconSize = 101;
            this.ipbCirculo.Location = new System.Drawing.Point(12, 15);
            this.ipbCirculo.Name = "ipbCirculo";
            this.ipbCirculo.Size = new System.Drawing.Size(106, 101);
            this.ipbCirculo.TabIndex = 138;
            this.ipbCirculo.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("Impact", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(43, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 46);
            this.label4.TabIndex = 139;
            this.label4.Text = "1";
            // 
            // FrmConsultarVuelos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1245, 577);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ipbCirculo);
            this.Controls.Add(this.btnConfirmarVuelo);
            this.Controls.Add(this.chkHabilitarFecha);
            this.Controls.Add(this.cmbAeropuertoDestino);
            this.Controls.Add(this.cmbAeropuertoOrigen);
            this.Controls.Add(this.cmbCiudadDestino);
            this.Controls.Add(this.cmbCiudadOrigen);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvVuelos);
            this.Controls.Add(this.dtpFechaViaje);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1153, 600);
            this.Name = "FrmConsultarVuelos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultar Vuelos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConsultarVuelos_FormClosing);
            this.Load += new System.EventHandler(this.FrmConsultarVuelos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVuelos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipbCirculo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpFechaViaje;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.ComboBox cmbCiudadOrigen;
        private System.Windows.Forms.ComboBox cmbCiudadDestino;
        private System.Windows.Forms.ComboBox cmbAeropuertoOrigen;
        private System.Windows.Forms.ComboBox cmbAeropuertoDestino;
        private System.Windows.Forms.CheckBox chkHabilitarFecha;
        private FontAwesome.Sharp.IconButton btnConfirmarVuelo;
        private System.Windows.Forms.DataGridView dgvVuelos;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVuelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroVuelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CiudadOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodAeropuertoOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreAeropuertoOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn CiudadDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodAeropuertoDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreAeropuertoDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPartida;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorarioEmbarque;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorarioPartida;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorarioLlegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioClaseTurista;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioClaseBusiness;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioPrimeraClase;
        private FontAwesome.Sharp.IconPictureBox ipbCirculo;
        private System.Windows.Forms.Label label4;
    }
}