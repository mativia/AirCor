namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    partial class FrmDefinicionVuelo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDefinicionVuelo));
            this.cmbCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbAeropuertoDestino = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAsientosPC = new System.Windows.Forms.MaskedTextBox();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.dgvDefVuelo = new System.Windows.Forms.DataGridView();
            this.ColumnImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.NroVuelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distancia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CiudadOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodAeropuertoOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CiudadDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodAeropuertoDestino = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVigenteDesde = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaVigenteHasta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorarioEmbarque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorarioPartida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorarioLlegada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MatriculaAvion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dias = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tarifas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbAeropuertoOrigen = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtNroVuelo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCiudadDestino = new System.Windows.Forms.ComboBox();
            this.dtpHorarioPartida = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaVigenteDesde = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dtpHorarioEmbarque = new System.Windows.Forms.DateTimePicker();
            this.dtpHorarioLlegada = new System.Windows.Forms.DateTimePicker();
            this.txtDistancia = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpFechaVigenteHasta = new System.Windows.Forms.DateTimePicker();
            this.chkLunes = new System.Windows.Forms.CheckBox();
            this.panDiasSemana = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.chkDomingo = new System.Windows.Forms.CheckBox();
            this.chkSabado = new System.Windows.Forms.CheckBox();
            this.chkViernes = new System.Windows.Forms.CheckBox();
            this.chkJueves = new System.Windows.Forms.CheckBox();
            this.chkMiercoles = new System.Windows.Forms.CheckBox();
            this.chkMartes = new System.Windows.Forms.CheckBox();
            this.cmbAvion = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTarifaPC = new System.Windows.Forms.TextBox();
            this.txtTarifaCB = new System.Windows.Forms.TextBox();
            this.txtTarifaCT = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLimpiar = new FontAwesome.Sharp.IconButton();
            this.txtFiltroNroVuelo = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cmbFiltroCiudadOrigen = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.cmbFiltroCiudadDestino = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.cmbFiltroAvion = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.btnLimpiarFiltros = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefVuelo)).BeginInit();
            this.panDiasSemana.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbCiudadOrigen
            // 
            this.cmbCiudadOrigen.FormattingEnabled = true;
            this.cmbCiudadOrigen.Location = new System.Drawing.Point(11, 105);
            this.cmbCiudadOrigen.Name = "cmbCiudadOrigen";
            this.cmbCiudadOrigen.Size = new System.Drawing.Size(255, 21);
            this.cmbCiudadOrigen.TabIndex = 3;
            this.cmbCiudadOrigen.TextUpdate += new System.EventHandler(this.cmbCiudad_TextUpdate);
            this.cmbCiudadOrigen.DropDownClosed += new System.EventHandler(this.cmbCiudadOrigen_DropDownClosed);
            this.cmbCiudadOrigen.TextChanged += new System.EventHandler(this.cmbCiudadOrigen_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.SteelBlue;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(14, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 231;
            this.label8.Text = "Ciudad Destino:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.SteelBlue;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(-70, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 227;
            this.label7.Text = "Pais Origen:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.SteelBlue;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(8, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 226;
            this.label6.Text = "Ciudad Origen:";
            // 
            // cmbAeropuertoDestino
            // 
            this.cmbAeropuertoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAeropuertoDestino.Enabled = false;
            this.cmbAeropuertoDestino.FormattingEnabled = true;
            this.cmbAeropuertoDestino.Location = new System.Drawing.Point(11, 228);
            this.cmbAeropuertoDestino.Name = "cmbAeropuertoDestino";
            this.cmbAeropuertoDestino.Size = new System.Drawing.Size(255, 21);
            this.cmbAeropuertoDestino.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(10, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 222;
            this.label4.Text = "Aeropuerto Destino:";
            // 
            // txtAsientosPC
            // 
            this.txtAsientosPC.Location = new System.Drawing.Point(-67, 158);
            this.txtAsientosPC.Mask = "000";
            this.txtAsientosPC.Name = "txtAsientosPC";
            this.txtAsientosPC.Size = new System.Drawing.Size(31, 20);
            this.txtAsientosPC.TabIndex = 221;
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
            this.btnEliminar.Location = new System.Drawing.Point(15, 661);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEliminar.Size = new System.Drawing.Size(143, 32);
            this.btnEliminar.TabIndex = 217;
            this.btnEliminar.Text = "Cancelar";
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
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Handshake;
            this.btnGuardar.IconColor = System.Drawing.Color.White;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 25;
            this.btnGuardar.Location = new System.Drawing.Point(164, 661);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGuardar.Size = new System.Drawing.Size(145, 32);
            this.btnGuardar.TabIndex = 216;
            this.btnGuardar.Text = "Confirmar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvDefVuelo
            // 
            this.dgvDefVuelo.AllowUserToAddRows = false;
            this.dgvDefVuelo.AllowUserToDeleteRows = false;
            this.dgvDefVuelo.AllowUserToResizeColumns = false;
            this.dgvDefVuelo.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDefVuelo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDefVuelo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefVuelo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnImg,
            this.NroVuelo,
            this.Distancia,
            this.CiudadOrigen,
            this.CodAeropuertoOrigen,
            this.CiudadDestino,
            this.CodAeropuertoDestino,
            this.FechaCreacion,
            this.FechaVigenteDesde,
            this.FechaVigenteHasta,
            this.HorarioEmbarque,
            this.HorarioPartida,
            this.HorarioLlegada,
            this.MatriculaAvion,
            this.Dias,
            this.Tarifas});
            this.dgvDefVuelo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvDefVuelo.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvDefVuelo.Location = new System.Drawing.Point(346, 157);
            this.dgvDefVuelo.MultiSelect = false;
            this.dgvDefVuelo.Name = "dgvDefVuelo";
            this.dgvDefVuelo.ReadOnly = true;
            this.dgvDefVuelo.RowHeadersVisible = false;
            this.dgvDefVuelo.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvDefVuelo.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDefVuelo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDefVuelo.Size = new System.Drawing.Size(1012, 536);
            this.dgvDefVuelo.TabIndex = 215;
            this.dgvDefVuelo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDefVuelo_CellClick);
            this.dgvDefVuelo.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDefVuelo_ColumnHeaderMouseClick);
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
            // NroVuelo
            // 
            this.NroVuelo.HeaderText = "Numero de Vuelo";
            this.NroVuelo.Name = "NroVuelo";
            this.NroVuelo.ReadOnly = true;
            // 
            // Distancia
            // 
            this.Distancia.HeaderText = "Distancia (km)";
            this.Distancia.Name = "Distancia";
            this.Distancia.ReadOnly = true;
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
            // FechaCreacion
            // 
            this.FechaCreacion.HeaderText = "Fecha de Creación";
            this.FechaCreacion.Name = "FechaCreacion";
            this.FechaCreacion.ReadOnly = true;
            // 
            // FechaVigenteDesde
            // 
            this.FechaVigenteDesde.HeaderText = "Fecha Desde";
            this.FechaVigenteDesde.Name = "FechaVigenteDesde";
            this.FechaVigenteDesde.ReadOnly = true;
            // 
            // FechaVigenteHasta
            // 
            this.FechaVigenteHasta.HeaderText = "Fecha Hasta";
            this.FechaVigenteHasta.Name = "FechaVigenteHasta";
            this.FechaVigenteHasta.ReadOnly = true;
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
            // MatriculaAvion
            // 
            this.MatriculaAvion.HeaderText = "Matricula Avion";
            this.MatriculaAvion.Name = "MatriculaAvion";
            this.MatriculaAvion.ReadOnly = true;
            // 
            // Dias
            // 
            this.Dias.HeaderText = "Dias";
            this.Dias.Name = "Dias";
            this.Dias.ReadOnly = true;
            this.Dias.Visible = false;
            // 
            // Tarifas
            // 
            this.Tarifas.HeaderText = "Tarifas";
            this.Tarifas.Name = "Tarifas";
            this.Tarifas.ReadOnly = true;
            this.Tarifas.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.SteelBlue;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(171, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 214;
            this.label3.Text = "Horario de Llegada:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.SteelBlue;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(10, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 13);
            this.label10.TabIndex = 211;
            this.label10.Text = "Aeropuerto Origen:";
            // 
            // cmbAeropuertoOrigen
            // 
            this.cmbAeropuertoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAeropuertoOrigen.Enabled = false;
            this.cmbAeropuertoOrigen.FormattingEnabled = true;
            this.cmbAeropuertoOrigen.Location = new System.Drawing.Point(12, 145);
            this.cmbAeropuertoOrigen.Name = "cmbAeropuertoOrigen";
            this.cmbAeropuertoOrigen.Size = new System.Drawing.Size(254, 21);
            this.cmbAeropuertoOrigen.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.SteelBlue;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(-70, 102);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(54, 13);
            this.label13.TabIndex = 209;
            this.label13.Text = "Distancia:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.SteelBlue;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(171, 284);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 13);
            this.label14.TabIndex = 208;
            this.label14.Text = "Horario de Partida:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.SteelBlue;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(171, 323);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(110, 13);
            this.label15.TabIndex = 207;
            this.label15.Text = "Horario de Embarque:";
            // 
            // txtNroVuelo
            // 
            this.txtNroVuelo.Location = new System.Drawing.Point(11, 63);
            this.txtNroVuelo.Name = "txtNroVuelo";
            this.txtNroVuelo.Size = new System.Drawing.Size(94, 20);
            this.txtNroVuelo.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.SteelBlue;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(8, 47);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 13);
            this.label16.TabIndex = 205;
            this.label16.Text = "Numero de Vuelo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 24);
            this.label2.TabIndex = 204;
            this.label2.Text = "Detalle Definicion de Vuelo:";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 705);
            this.label1.TabIndex = 203;
            // 
            // cmbCiudadDestino
            // 
            this.cmbCiudadDestino.FormattingEnabled = true;
            this.cmbCiudadDestino.Location = new System.Drawing.Point(11, 188);
            this.cmbCiudadDestino.Name = "cmbCiudadDestino";
            this.cmbCiudadDestino.Size = new System.Drawing.Size(255, 21);
            this.cmbCiudadDestino.TabIndex = 5;
            this.cmbCiudadDestino.TextUpdate += new System.EventHandler(this.cmbCiudadDestino_TextUpdate);
            this.cmbCiudadDestino.DropDownClosed += new System.EventHandler(this.cmbCiudadDestino_DropDownClosed);
            this.cmbCiudadDestino.TextChanged += new System.EventHandler(this.cmbCiudadDestino_TextChanged);
            // 
            // dtpHorarioPartida
            // 
            this.dtpHorarioPartida.CustomFormat = "HH:mm";
            this.dtpHorarioPartida.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHorarioPartida.Location = new System.Drawing.Point(174, 300);
            this.dtpHorarioPartida.Name = "dtpHorarioPartida";
            this.dtpHorarioPartida.ShowUpDown = true;
            this.dtpHorarioPartida.Size = new System.Drawing.Size(106, 20);
            this.dtpHorarioPartida.TabIndex = 9;
            // 
            // dtpFechaVigenteDesde
            // 
            this.dtpFechaVigenteDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVigenteDesde.Location = new System.Drawing.Point(11, 300);
            this.dtpFechaVigenteDesde.MinDate = new System.DateTime(2022, 9, 29, 0, 0, 0, 0);
            this.dtpFechaVigenteDesde.Name = "dtpFechaVigenteDesde";
            this.dtpFechaVigenteDesde.Size = new System.Drawing.Size(107, 20);
            this.dtpFechaVigenteDesde.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.SteelBlue;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(8, 284);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 236;
            this.label9.Text = "Fecha desde:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.SteelBlue;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(8, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 13);
            this.label12.TabIndex = 237;
            this.label12.Text = "Fechas de Vigencia:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.SteelBlue;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(9, 323);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 13);
            this.label17.TabIndex = 238;
            this.label17.Text = "Fecha hasta:";
            // 
            // dtpHorarioEmbarque
            // 
            this.dtpHorarioEmbarque.CustomFormat = "HH:mm";
            this.dtpHorarioEmbarque.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHorarioEmbarque.Location = new System.Drawing.Point(174, 339);
            this.dtpHorarioEmbarque.Name = "dtpHorarioEmbarque";
            this.dtpHorarioEmbarque.ShowUpDown = true;
            this.dtpHorarioEmbarque.Size = new System.Drawing.Size(106, 20);
            this.dtpHorarioEmbarque.TabIndex = 10;
            // 
            // dtpHorarioLlegada
            // 
            this.dtpHorarioLlegada.CustomFormat = "HH:mm";
            this.dtpHorarioLlegada.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHorarioLlegada.Location = new System.Drawing.Point(175, 378);
            this.dtpHorarioLlegada.Name = "dtpHorarioLlegada";
            this.dtpHorarioLlegada.ShowUpDown = true;
            this.dtpHorarioLlegada.Size = new System.Drawing.Size(106, 20);
            this.dtpHorarioLlegada.TabIndex = 11;
            // 
            // txtDistancia
            // 
            this.txtDistancia.Location = new System.Drawing.Point(155, 63);
            this.txtDistancia.Name = "txtDistancia";
            this.txtDistancia.Size = new System.Drawing.Size(94, 20);
            this.txtDistancia.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.SteelBlue;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(152, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 242;
            this.label11.Text = "Distancia (km):";
            // 
            // dtpFechaVigenteHasta
            // 
            this.dtpFechaVigenteHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVigenteHasta.Location = new System.Drawing.Point(13, 339);
            this.dtpFechaVigenteHasta.MinDate = new System.DateTime(2022, 9, 29, 0, 0, 0, 0);
            this.dtpFechaVigenteHasta.Name = "dtpFechaVigenteHasta";
            this.dtpFechaVigenteHasta.Size = new System.Drawing.Size(107, 20);
            this.dtpFechaVigenteHasta.TabIndex = 8;
            // 
            // chkLunes
            // 
            this.chkLunes.AutoSize = true;
            this.chkLunes.BackColor = System.Drawing.Color.SteelBlue;
            this.chkLunes.ForeColor = System.Drawing.Color.White;
            this.chkLunes.Location = new System.Drawing.Point(15, 18);
            this.chkLunes.Name = "chkLunes";
            this.chkLunes.Size = new System.Drawing.Size(55, 17);
            this.chkLunes.TabIndex = 12;
            this.chkLunes.Text = "Lunes";
            this.chkLunes.UseVisualStyleBackColor = false;
            // 
            // panDiasSemana
            // 
            this.panDiasSemana.BackColor = System.Drawing.Color.SteelBlue;
            this.panDiasSemana.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panDiasSemana.Controls.Add(this.label18);
            this.panDiasSemana.Controls.Add(this.chkDomingo);
            this.panDiasSemana.Controls.Add(this.chkSabado);
            this.panDiasSemana.Controls.Add(this.chkViernes);
            this.panDiasSemana.Controls.Add(this.chkJueves);
            this.panDiasSemana.Controls.Add(this.chkMiercoles);
            this.panDiasSemana.Controls.Add(this.chkMartes);
            this.panDiasSemana.Controls.Add(this.chkLunes);
            this.panDiasSemana.ForeColor = System.Drawing.Color.Black;
            this.panDiasSemana.Location = new System.Drawing.Point(11, 415);
            this.panDiasSemana.Name = "panDiasSemana";
            this.panDiasSemana.Size = new System.Drawing.Size(292, 71);
            this.panDiasSemana.TabIndex = 245;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.SteelBlue;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(12, 2);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(115, 13);
            this.label18.TabIndex = 246;
            this.label18.Text = "Dias de la semana:";
            // 
            // chkDomingo
            // 
            this.chkDomingo.AutoSize = true;
            this.chkDomingo.BackColor = System.Drawing.Color.SteelBlue;
            this.chkDomingo.ForeColor = System.Drawing.SystemColors.Window;
            this.chkDomingo.Location = new System.Drawing.Point(219, 18);
            this.chkDomingo.Name = "chkDomingo";
            this.chkDomingo.Size = new System.Drawing.Size(68, 17);
            this.chkDomingo.TabIndex = 15;
            this.chkDomingo.Text = "Domingo";
            this.chkDomingo.UseVisualStyleBackColor = false;
            // 
            // chkSabado
            // 
            this.chkSabado.AutoSize = true;
            this.chkSabado.BackColor = System.Drawing.Color.SteelBlue;
            this.chkSabado.ForeColor = System.Drawing.SystemColors.Window;
            this.chkSabado.Location = new System.Drawing.Point(153, 41);
            this.chkSabado.Name = "chkSabado";
            this.chkSabado.Size = new System.Drawing.Size(63, 17);
            this.chkSabado.TabIndex = 18;
            this.chkSabado.Text = "Sábado";
            this.chkSabado.UseVisualStyleBackColor = false;
            // 
            // chkViernes
            // 
            this.chkViernes.AutoSize = true;
            this.chkViernes.BackColor = System.Drawing.Color.SteelBlue;
            this.chkViernes.ForeColor = System.Drawing.SystemColors.Window;
            this.chkViernes.Location = new System.Drawing.Point(153, 18);
            this.chkViernes.Name = "chkViernes";
            this.chkViernes.Size = new System.Drawing.Size(61, 17);
            this.chkViernes.TabIndex = 14;
            this.chkViernes.Text = "Viernes";
            this.chkViernes.UseVisualStyleBackColor = false;
            // 
            // chkJueves
            // 
            this.chkJueves.AutoSize = true;
            this.chkJueves.BackColor = System.Drawing.Color.SteelBlue;
            this.chkJueves.ForeColor = System.Drawing.SystemColors.Window;
            this.chkJueves.Location = new System.Drawing.Point(75, 41);
            this.chkJueves.Name = "chkJueves";
            this.chkJueves.Size = new System.Drawing.Size(60, 17);
            this.chkJueves.TabIndex = 17;
            this.chkJueves.Text = "Jueves";
            this.chkJueves.UseVisualStyleBackColor = false;
            // 
            // chkMiercoles
            // 
            this.chkMiercoles.AutoSize = true;
            this.chkMiercoles.BackColor = System.Drawing.Color.SteelBlue;
            this.chkMiercoles.ForeColor = System.Drawing.SystemColors.Window;
            this.chkMiercoles.Location = new System.Drawing.Point(75, 18);
            this.chkMiercoles.Name = "chkMiercoles";
            this.chkMiercoles.Size = new System.Drawing.Size(71, 17);
            this.chkMiercoles.TabIndex = 13;
            this.chkMiercoles.Text = "Miercoles";
            this.chkMiercoles.UseVisualStyleBackColor = false;
            // 
            // chkMartes
            // 
            this.chkMartes.AutoSize = true;
            this.chkMartes.BackColor = System.Drawing.Color.SteelBlue;
            this.chkMartes.ForeColor = System.Drawing.Color.White;
            this.chkMartes.Location = new System.Drawing.Point(15, 41);
            this.chkMartes.Name = "chkMartes";
            this.chkMartes.Size = new System.Drawing.Size(58, 17);
            this.chkMartes.TabIndex = 16;
            this.chkMartes.Text = "Martes";
            this.chkMartes.UseVisualStyleBackColor = false;
            // 
            // cmbAvion
            // 
            this.cmbAvion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAvion.FormattingEnabled = true;
            this.cmbAvion.Location = new System.Drawing.Point(11, 505);
            this.cmbAvion.Name = "cmbAvion";
            this.cmbAvion.Size = new System.Drawing.Size(218, 21);
            this.cmbAvion.TabIndex = 19;
            this.cmbAvion.SelectionChangeCommitted += new System.EventHandler(this.cmbAvion_SelectionChangeCommitted);
            this.cmbAvion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbAvion_MouseClick);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.SteelBlue;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(8, 489);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(37, 13);
            this.label19.TabIndex = 247;
            this.label19.Text = "Avion:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.SteelBlue;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(16, 3);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 13);
            this.label20.TabIndex = 248;
            this.label20.Text = "Tarifas:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.SteelBlue;
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(12, 23);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 13);
            this.label21.TabIndex = 249;
            this.label21.Text = "Clase Turista:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.SteelBlue;
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(114, 23);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(81, 13);
            this.label22.TabIndex = 251;
            this.label22.Text = "Clase Business:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.SteelBlue;
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(218, 23);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(74, 13);
            this.label23.TabIndex = 253;
            this.label23.Text = "Primera Clase:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.BackColor = System.Drawing.Color.SteelBlue;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(171, 262);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(58, 13);
            this.label24.TabIndex = 255;
            this.label24.Text = "Horarios:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTarifaPC);
            this.panel1.Controls.Add(this.txtTarifaCB);
            this.panel1.Controls.Add(this.txtTarifaCT);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label22);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(6, 532);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 64);
            this.panel1.TabIndex = 256;
            // 
            // txtTarifaPC
            // 
            this.txtTarifaPC.Location = new System.Drawing.Point(218, 39);
            this.txtTarifaPC.Name = "txtTarifaPC";
            this.txtTarifaPC.Size = new System.Drawing.Size(101, 20);
            this.txtTarifaPC.TabIndex = 262;
            // 
            // txtTarifaCB
            // 
            this.txtTarifaCB.Location = new System.Drawing.Point(114, 39);
            this.txtTarifaCB.Name = "txtTarifaCB";
            this.txtTarifaCB.Size = new System.Drawing.Size(101, 20);
            this.txtTarifaCB.TabIndex = 261;
            // 
            // txtTarifaCT
            // 
            this.txtTarifaCT.Location = new System.Drawing.Point(10, 39);
            this.txtTarifaCT.Name = "txtTarifaCT";
            this.txtTarifaCT.Size = new System.Drawing.Size(101, 20);
            this.txtTarifaCT.TabIndex = 260;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.White;
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(346, 12);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(1012, 48);
            this.label25.TabIndex = 257;
            this.label25.Text = "Lista de Definiciones de Vuelo:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(346, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1012, 91);
            this.label5.TabIndex = 258;
            this.label5.Text = "Filtros:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnLimpiar.Location = new System.Drawing.Point(13, 623);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLimpiar.Size = new System.Drawing.Size(296, 32);
            this.btnLimpiar.TabIndex = 259;
            this.btnLimpiar.Text = "Limpiar Selección";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // txtFiltroNroVuelo
            // 
            this.txtFiltroNroVuelo.Location = new System.Drawing.Point(404, 106);
            this.txtFiltroNroVuelo.Name = "txtFiltroNroVuelo";
            this.txtFiltroNroVuelo.Size = new System.Drawing.Size(94, 20);
            this.txtFiltroNroVuelo.TabIndex = 260;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.White;
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(401, 90);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(92, 13);
            this.label26.TabIndex = 261;
            this.label26.Text = "Numero de Vuelo:";
            // 
            // cmbFiltroCiudadOrigen
            // 
            this.cmbFiltroCiudadOrigen.FormattingEnabled = true;
            this.cmbFiltroCiudadOrigen.Location = new System.Drawing.Point(513, 105);
            this.cmbFiltroCiudadOrigen.Name = "cmbFiltroCiudadOrigen";
            this.cmbFiltroCiudadOrigen.Size = new System.Drawing.Size(255, 21);
            this.cmbFiltroCiudadOrigen.TabIndex = 262;
            this.cmbFiltroCiudadOrigen.TextUpdate += new System.EventHandler(this.cmbFiltroCiudadOrigen_TextUpdate);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.White;
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(510, 89);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(77, 13);
            this.label27.TabIndex = 263;
            this.label27.Text = "Ciudad Origen:";
            // 
            // cmbFiltroCiudadDestino
            // 
            this.cmbFiltroCiudadDestino.FormattingEnabled = true;
            this.cmbFiltroCiudadDestino.Location = new System.Drawing.Point(785, 105);
            this.cmbFiltroCiudadDestino.Name = "cmbFiltroCiudadDestino";
            this.cmbFiltroCiudadDestino.Size = new System.Drawing.Size(255, 21);
            this.cmbFiltroCiudadDestino.TabIndex = 264;
            this.cmbFiltroCiudadDestino.TextUpdate += new System.EventHandler(this.cmbFiltroCiudadDestino_TextUpdate);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.White;
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(782, 89);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(82, 13);
            this.label28.TabIndex = 265;
            this.label28.Text = "Ciudad Destino:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.White;
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(1053, 89);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(37, 13);
            this.label29.TabIndex = 267;
            this.label29.Text = "Avion:";
            // 
            // cmbFiltroAvion
            // 
            this.cmbFiltroAvion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroAvion.FormattingEnabled = true;
            this.cmbFiltroAvion.Location = new System.Drawing.Point(1056, 105);
            this.cmbFiltroAvion.Name = "cmbFiltroAvion";
            this.cmbFiltroAvion.Size = new System.Drawing.Size(167, 21);
            this.cmbFiltroAvion.TabIndex = 266;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscar.IconColor = System.Drawing.Color.White;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 25;
            this.btnBuscar.Location = new System.Drawing.Point(1237, 73);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBuscar.Size = new System.Drawing.Size(116, 32);
            this.btnBuscar.TabIndex = 268;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiarFiltros
            // 
            this.btnLimpiarFiltros.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnLimpiarFiltros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarFiltros.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLimpiarFiltros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarFiltros.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.btnLimpiarFiltros.IconColor = System.Drawing.Color.White;
            this.btnLimpiarFiltros.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLimpiarFiltros.IconSize = 25;
            this.btnLimpiarFiltros.Location = new System.Drawing.Point(1237, 111);
            this.btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            this.btnLimpiarFiltros.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLimpiarFiltros.Size = new System.Drawing.Size(116, 32);
            this.btnLimpiarFiltros.TabIndex = 269;
            this.btnLimpiarFiltros.Text = "Limpiar Filtros";
            this.btnLimpiarFiltros.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLimpiarFiltros.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiarFiltros.UseVisualStyleBackColor = false;
            this.btnLimpiarFiltros.Click += new System.EventHandler(this.btnLimpiarFiltros_Click);
            // 
            // FrmDefinicionVuelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 705);
            this.Controls.Add(this.btnLimpiarFiltros);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.cmbFiltroAvion);
            this.Controls.Add(this.cmbFiltroCiudadDestino);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.cmbFiltroCiudadOrigen);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtFiltroNroVuelo);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cmbAvion);
            this.Controls.Add(this.panDiasSemana);
            this.Controls.Add(this.dtpFechaVigenteHasta);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtDistancia);
            this.Controls.Add(this.dtpHorarioLlegada);
            this.Controls.Add(this.dtpHorarioEmbarque);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpFechaVigenteDesde);
            this.Controls.Add(this.dtpHorarioPartida);
            this.Controls.Add(this.cmbCiudadDestino);
            this.Controls.Add(this.cmbCiudadOrigen);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbAeropuertoDestino);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAsientosPC);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dgvDefVuelo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbAeropuertoOrigen);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtNroVuelo);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmDefinicionVuelo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Definicion de Vuelo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmDefinicionVuelo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefVuelo)).EndInit();
            this.panDiasSemana.ResumeLayout(false);
            this.panDiasSemana.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCiudadOrigen;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbAeropuertoDestino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox txtAsientosPC;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.DataGridView dgvDefVuelo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbAeropuertoOrigen;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtNroVuelo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCiudadDestino;
        private System.Windows.Forms.DateTimePicker dtpHorarioPartida;
        private System.Windows.Forms.DateTimePicker dtpFechaVigenteDesde;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker dtpHorarioEmbarque;
        private System.Windows.Forms.DateTimePicker dtpHorarioLlegada;
        private System.Windows.Forms.TextBox txtDistancia;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpFechaVigenteHasta;
        private System.Windows.Forms.CheckBox chkLunes;
        private System.Windows.Forms.Panel panDiasSemana;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox chkDomingo;
        private System.Windows.Forms.CheckBox chkSabado;
        private System.Windows.Forms.CheckBox chkViernes;
        private System.Windows.Forms.CheckBox chkJueves;
        private System.Windows.Forms.CheckBox chkMiercoles;
        private System.Windows.Forms.CheckBox chkMartes;
        private System.Windows.Forms.ComboBox cmbAvion;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton btnLimpiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreAeropuertoOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreAeropuertoDestino;
        private System.Windows.Forms.DataGridViewImageColumn ColumnImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroVuelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Distancia;
        private System.Windows.Forms.DataGridViewTextBoxColumn CiudadOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodAeropuertoOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn CiudadDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodAeropuertoDestino;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVigenteDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaVigenteHasta;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorarioEmbarque;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorarioPartida;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorarioLlegada;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatriculaAvion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dias;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tarifas;
        private System.Windows.Forms.TextBox txtTarifaPC;
        private System.Windows.Forms.TextBox txtTarifaCB;
        private System.Windows.Forms.TextBox txtTarifaCT;
        private System.Windows.Forms.TextBox txtFiltroNroVuelo;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ComboBox cmbFiltroCiudadOrigen;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox cmbFiltroCiudadDestino;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cmbFiltroAvion;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnLimpiarFiltros;
    }
}