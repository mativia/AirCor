namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    partial class FrmSeleccionAsiento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeleccionAsiento));
            this.tcSeleccionAsiento = new System.Windows.Forms.TabControl();
            this.tpClaseTurista = new System.Windows.Forms.TabPage();
            this.dgvTurista = new System.Windows.Forms.DataGridView();
            this.tpClaseBusiness = new System.Windows.Forms.TabPage();
            this.dgvBusiness = new System.Windows.Forms.DataGridView();
            this.tpPrimeraClase = new System.Windows.Forms.TabPage();
            this.dgvPrimera = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTipoClase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoClase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ipbCirculo = new FontAwesome.Sharp.IconPictureBox();
            this.btnConfirmar = new FontAwesome.Sharp.IconButton();
            this.tcSeleccionAsiento.SuspendLayout();
            this.tpClaseTurista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurista)).BeginInit();
            this.tpClaseBusiness.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusiness)).BeginInit();
            this.tpPrimeraClase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrimera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipbCirculo)).BeginInit();
            this.SuspendLayout();
            // 
            // tcSeleccionAsiento
            // 
            this.tcSeleccionAsiento.Controls.Add(this.tpClaseTurista);
            this.tcSeleccionAsiento.Controls.Add(this.tpClaseBusiness);
            this.tcSeleccionAsiento.Controls.Add(this.tpPrimeraClase);
            this.tcSeleccionAsiento.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tcSeleccionAsiento.Location = new System.Drawing.Point(0, 331);
            this.tcSeleccionAsiento.Name = "tcSeleccionAsiento";
            this.tcSeleccionAsiento.SelectedIndex = 0;
            this.tcSeleccionAsiento.Size = new System.Drawing.Size(864, 401);
            this.tcSeleccionAsiento.TabIndex = 0;
            this.tcSeleccionAsiento.SelectedIndexChanged += new System.EventHandler(this.tcSeleccionAsiento_SelectedIndexChanged);
            // 
            // tpClaseTurista
            // 
            this.tpClaseTurista.Controls.Add(this.dgvTurista);
            this.tpClaseTurista.Location = new System.Drawing.Point(4, 22);
            this.tpClaseTurista.Name = "tpClaseTurista";
            this.tpClaseTurista.Padding = new System.Windows.Forms.Padding(3);
            this.tpClaseTurista.Size = new System.Drawing.Size(856, 375);
            this.tpClaseTurista.TabIndex = 0;
            this.tpClaseTurista.Text = "Clase Turista";
            this.tpClaseTurista.UseVisualStyleBackColor = true;
            // 
            // dgvTurista
            // 
            this.dgvTurista.AllowUserToAddRows = false;
            this.dgvTurista.AllowUserToDeleteRows = false;
            this.dgvTurista.AllowUserToResizeColumns = false;
            this.dgvTurista.AllowUserToResizeRows = false;
            this.dgvTurista.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTurista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTurista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTurista.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTurista.Location = new System.Drawing.Point(45, 21);
            this.dgvTurista.MultiSelect = false;
            this.dgvTurista.Name = "dgvTurista";
            this.dgvTurista.ReadOnly = true;
            this.dgvTurista.RowHeadersVisible = false;
            this.dgvTurista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvTurista.Size = new System.Drawing.Size(780, 343);
            this.dgvTurista.TabIndex = 0;
            this.dgvTurista.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurista_CellClick);
            this.dgvTurista.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTurista_CellFormatting);
            this.dgvTurista.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvTurista_CellPainting);
            // 
            // tpClaseBusiness
            // 
            this.tpClaseBusiness.Controls.Add(this.dgvBusiness);
            this.tpClaseBusiness.Location = new System.Drawing.Point(4, 22);
            this.tpClaseBusiness.Name = "tpClaseBusiness";
            this.tpClaseBusiness.Padding = new System.Windows.Forms.Padding(3);
            this.tpClaseBusiness.Size = new System.Drawing.Size(856, 375);
            this.tpClaseBusiness.TabIndex = 1;
            this.tpClaseBusiness.Text = "Clase Business";
            this.tpClaseBusiness.UseVisualStyleBackColor = true;
            // 
            // dgvBusiness
            // 
            this.dgvBusiness.AllowUserToAddRows = false;
            this.dgvBusiness.AllowUserToDeleteRows = false;
            this.dgvBusiness.AllowUserToResizeColumns = false;
            this.dgvBusiness.AllowUserToResizeRows = false;
            this.dgvBusiness.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBusiness.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBusiness.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBusiness.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBusiness.Location = new System.Drawing.Point(45, 21);
            this.dgvBusiness.MultiSelect = false;
            this.dgvBusiness.Name = "dgvBusiness";
            this.dgvBusiness.ReadOnly = true;
            this.dgvBusiness.RowHeadersVisible = false;
            this.dgvBusiness.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvBusiness.Size = new System.Drawing.Size(780, 343);
            this.dgvBusiness.TabIndex = 212;
            this.dgvBusiness.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBusiness_CellClick);
            this.dgvBusiness.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvBusiness_CellFormatting);
            this.dgvBusiness.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvBusiness_CellPainting);
            // 
            // tpPrimeraClase
            // 
            this.tpPrimeraClase.Controls.Add(this.dgvPrimera);
            this.tpPrimeraClase.Location = new System.Drawing.Point(4, 22);
            this.tpPrimeraClase.Name = "tpPrimeraClase";
            this.tpPrimeraClase.Padding = new System.Windows.Forms.Padding(3);
            this.tpPrimeraClase.Size = new System.Drawing.Size(856, 375);
            this.tpPrimeraClase.TabIndex = 2;
            this.tpPrimeraClase.Text = "Primera Clase";
            this.tpPrimeraClase.UseVisualStyleBackColor = true;
            // 
            // dgvPrimera
            // 
            this.dgvPrimera.AllowUserToAddRows = false;
            this.dgvPrimera.AllowUserToDeleteRows = false;
            this.dgvPrimera.AllowUserToResizeColumns = false;
            this.dgvPrimera.AllowUserToResizeRows = false;
            this.dgvPrimera.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPrimera.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPrimera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPrimera.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPrimera.Location = new System.Drawing.Point(45, 21);
            this.dgvPrimera.MultiSelect = false;
            this.dgvPrimera.Name = "dgvPrimera";
            this.dgvPrimera.ReadOnly = true;
            this.dgvPrimera.RowHeadersVisible = false;
            this.dgvPrimera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPrimera.Size = new System.Drawing.Size(780, 343);
            this.dgvPrimera.TabIndex = 213;
            this.dgvPrimera.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPrimera_CellClick);
            this.dgvPrimera.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvPrimera_CellFormatting);
            this.dgvPrimera.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvPrimera_CellPainting);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(124, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(353, 39);
            this.label2.TabIndex = 210;
            this.label2.Text = "Selección de Asientos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("Impact", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(41, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 46);
            this.label4.TabIndex = 208;
            this.label4.Text = "3";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(864, 114);
            this.label1.TabIndex = 209;
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.AllowUserToAddRows = false;
            this.dgvDetalles.AllowUserToDeleteRows = false;
            this.dgvDetalles.AllowUserToResizeColumns = false;
            this.dgvDetalles.AllowUserToResizeRows = false;
            this.dgvDetalles.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Apellido,
            this.Asiento,
            this.TipoDocumento,
            this.NroDocumento,
            this.IdTipoClase,
            this.TipoClase});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalles.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDetalles.Location = new System.Drawing.Point(49, 120);
            this.dgvDetalles.MultiSelect = false;
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.ReadOnly = true;
            this.dgvDetalles.RowHeadersVisible = false;
            this.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalles.Size = new System.Drawing.Size(551, 180);
            this.dgvDetalles.TabIndex = 1;
            this.dgvDetalles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalles_CellClick);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            // 
            // Asiento
            // 
            this.Asiento.HeaderText = "Asiento";
            this.Asiento.Name = "Asiento";
            this.Asiento.ReadOnly = true;
            // 
            // TipoDocumento
            // 
            this.TipoDocumento.HeaderText = "TipoDocumento";
            this.TipoDocumento.Name = "TipoDocumento";
            this.TipoDocumento.ReadOnly = true;
            this.TipoDocumento.Visible = false;
            // 
            // NroDocumento
            // 
            this.NroDocumento.HeaderText = "NroDocumento";
            this.NroDocumento.Name = "NroDocumento";
            this.NroDocumento.ReadOnly = true;
            this.NroDocumento.Visible = false;
            // 
            // IdTipoClase
            // 
            this.IdTipoClase.HeaderText = "IdTipoClase";
            this.IdTipoClase.Name = "IdTipoClase";
            this.IdTipoClase.ReadOnly = true;
            this.IdTipoClase.Visible = false;
            // 
            // TipoClase
            // 
            this.TipoClase.HeaderText = "Tipo Clase";
            this.TipoClase.Name = "TipoClase";
            this.TipoClase.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(626, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 180);
            this.panel1.TabIndex = 211;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(77, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ocupado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(77, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Asignado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(77, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Disponible";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::tp_pav1_grupo10.Properties.Resources.ocupado;
            this.pictureBox3.Location = new System.Drawing.Point(17, 121);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(54, 53);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::tp_pav1_grupo10.Properties.Resources.asignado;
            this.pictureBox2.Location = new System.Drawing.Point(17, 64);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(54, 53);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::tp_pav1_grupo10.Properties.Resources.disponible;
            this.pictureBox1.Location = new System.Drawing.Point(17, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 53);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ipbCirculo
            // 
            this.ipbCirculo.BackColor = System.Drawing.Color.SteelBlue;
            this.ipbCirculo.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.ipbCirculo.IconColor = System.Drawing.Color.White;
            this.ipbCirculo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ipbCirculo.IconSize = 101;
            this.ipbCirculo.Location = new System.Drawing.Point(12, 13);
            this.ipbCirculo.Name = "ipbCirculo";
            this.ipbCirculo.Size = new System.Drawing.Size(106, 101);
            this.ipbCirculo.TabIndex = 207;
            this.ipbCirculo.TabStop = false;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.ForestGreen;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar.IconChar = FontAwesome.Sharp.IconChar.Handshake;
            this.btnConfirmar.IconColor = System.Drawing.Color.White;
            this.btnConfirmar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConfirmar.IconSize = 25;
            this.btnConfirmar.Location = new System.Drawing.Point(708, 306);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnConfirmar.Size = new System.Drawing.Size(121, 35);
            this.btnConfirmar.TabIndex = 212;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // FrmSeleccionAsiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(864, 732);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDetalles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ipbCirculo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tcSeleccionAsiento);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSeleccionAsiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccion de Asientos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSeleccionAsiento_FormClosing);
            this.Load += new System.EventHandler(this.FrmSeleccionAsiento_Load);
            this.tcSeleccionAsiento.ResumeLayout(false);
            this.tpClaseTurista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurista)).EndInit();
            this.tpClaseBusiness.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBusiness)).EndInit();
            this.tpPrimeraClase.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrimera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipbCirculo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcSeleccionAsiento;
        private System.Windows.Forms.TabPage tpClaseTurista;
        private System.Windows.Forms.TabPage tpClaseBusiness;
        private System.Windows.Forms.TabPage tpPrimeraClase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconPictureBox ipbCirculo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTurista;
        private System.Windows.Forms.DataGridView dgvDetalles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvBusiness;
        private System.Windows.Forms.DataGridView dgvPrimera;
        private FontAwesome.Sharp.IconButton btnConfirmar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTipoClase;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoClase;
    }
}