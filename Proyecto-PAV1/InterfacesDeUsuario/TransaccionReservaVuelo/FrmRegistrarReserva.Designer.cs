namespace tp_pav1_grupo10.InterfacesDeUsuario
{
    partial class FrmRegistrarReserva
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistrarReserva));
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnConfirmar = new FontAwesome.Sharp.IconButton();
            this.btnAgregarPasajero = new FontAwesome.Sharp.IconButton();
            this.btnEliminarPasajero = new FontAwesome.Sharp.IconButton();
            this.dgvPasajeros = new System.Windows.Forms.DataGridView();
            this.Titular = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IdTipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TelefonoCelular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdNacionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nacionalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdSexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sexo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.ipbCirculo = new FontAwesome.Sharp.IconPictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasajeros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipbCirculo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Selección";
            this.dataGridViewImageColumn1.Image = global::tp_pav1_grupo10.Properties.Resources.png_sin_nada;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Width = 60;
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
            this.btnConfirmar.Location = new System.Drawing.Point(1045, 409);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnConfirmar.Size = new System.Drawing.Size(121, 35);
            this.btnConfirmar.TabIndex = 157;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnAgregarPasajero
            // 
            this.btnAgregarPasajero.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAgregarPasajero.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarPasajero.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAgregarPasajero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPasajero.ForeColor = System.Drawing.Color.White;
            this.btnAgregarPasajero.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAgregarPasajero.IconColor = System.Drawing.Color.White;
            this.btnAgregarPasajero.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAgregarPasajero.IconSize = 25;
            this.btnAgregarPasajero.Location = new System.Drawing.Point(1004, 22);
            this.btnAgregarPasajero.Name = "btnAgregarPasajero";
            this.btnAgregarPasajero.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnAgregarPasajero.Size = new System.Drawing.Size(162, 35);
            this.btnAgregarPasajero.TabIndex = 172;
            this.btnAgregarPasajero.Text = "Agregar Pasajero";
            this.btnAgregarPasajero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarPasajero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregarPasajero.UseVisualStyleBackColor = false;
            this.btnAgregarPasajero.Click += new System.EventHandler(this.btnRegistrarPasajero_Click);
            // 
            // btnEliminarPasajero
            // 
            this.btnEliminarPasajero.BackColor = System.Drawing.Color.Firebrick;
            this.btnEliminarPasajero.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarPasajero.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEliminarPasajero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarPasajero.ForeColor = System.Drawing.Color.White;
            this.btnEliminarPasajero.IconChar = FontAwesome.Sharp.IconChar.TrashAlt;
            this.btnEliminarPasajero.IconColor = System.Drawing.Color.White;
            this.btnEliminarPasajero.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminarPasajero.IconSize = 25;
            this.btnEliminarPasajero.Location = new System.Drawing.Point(1004, 63);
            this.btnEliminarPasajero.Name = "btnEliminarPasajero";
            this.btnEliminarPasajero.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnEliminarPasajero.Size = new System.Drawing.Size(162, 35);
            this.btnEliminarPasajero.TabIndex = 173;
            this.btnEliminarPasajero.Text = "Quitar Pasajero";
            this.btnEliminarPasajero.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminarPasajero.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminarPasajero.UseVisualStyleBackColor = false;
            this.btnEliminarPasajero.Click += new System.EventHandler(this.btnEliminarPasajero_Click);
            // 
            // dgvPasajeros
            // 
            this.dgvPasajeros.AllowUserToAddRows = false;
            this.dgvPasajeros.AllowUserToDeleteRows = false;
            this.dgvPasajeros.AllowUserToResizeColumns = false;
            this.dgvPasajeros.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPasajeros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPasajeros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPasajeros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Titular,
            this.IdTipoDocumento,
            this.TipoDocumento,
            this.NumeroDocumento,
            this.Nombre,
            this.Apellido,
            this.FechaNacimiento,
            this.TelefonoCelular,
            this.Mail,
            this.IdNacionalidad,
            this.Nacionalidad,
            this.IdSexo,
            this.Sexo});
            this.dgvPasajeros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvPasajeros.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dgvPasajeros.Location = new System.Drawing.Point(14, 120);
            this.dgvPasajeros.MultiSelect = false;
            this.dgvPasajeros.Name = "dgvPasajeros";
            this.dgvPasajeros.RowHeadersVisible = false;
            this.dgvPasajeros.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPasajeros.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPasajeros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPasajeros.Size = new System.Drawing.Size(1152, 283);
            this.dgvPasajeros.TabIndex = 202;
            this.dgvPasajeros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPasajeros_CellContentClick);
            // 
            // Titular
            // 
            this.Titular.HeaderText = "Titular";
            this.Titular.MinimumWidth = 6;
            this.Titular.Name = "Titular";
            this.Titular.Width = 125;
            // 
            // IdTipoDocumento
            // 
            this.IdTipoDocumento.HeaderText = "IdTipoDocumento";
            this.IdTipoDocumento.MinimumWidth = 6;
            this.IdTipoDocumento.Name = "IdTipoDocumento";
            this.IdTipoDocumento.Visible = false;
            this.IdTipoDocumento.Width = 125;
            // 
            // TipoDocumento
            // 
            this.TipoDocumento.HeaderText = "Tipo de Documento";
            this.TipoDocumento.MinimumWidth = 6;
            this.TipoDocumento.Name = "TipoDocumento";
            this.TipoDocumento.ReadOnly = true;
            this.TipoDocumento.Width = 125;
            // 
            // NumeroDocumento
            // 
            this.NumeroDocumento.HeaderText = "Numero de Documento";
            this.NumeroDocumento.MinimumWidth = 6;
            this.NumeroDocumento.Name = "NumeroDocumento";
            this.NumeroDocumento.ReadOnly = true;
            this.NumeroDocumento.Width = 125;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 125;
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.MinimumWidth = 6;
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            this.Apellido.Width = 125;
            // 
            // FechaNacimiento
            // 
            this.FechaNacimiento.HeaderText = "Fecha Nacimiento";
            this.FechaNacimiento.MinimumWidth = 6;
            this.FechaNacimiento.Name = "FechaNacimiento";
            this.FechaNacimiento.Visible = false;
            this.FechaNacimiento.Width = 125;
            // 
            // TelefonoCelular
            // 
            this.TelefonoCelular.HeaderText = "Teléfono Celular";
            this.TelefonoCelular.MinimumWidth = 6;
            this.TelefonoCelular.Name = "TelefonoCelular";
            this.TelefonoCelular.ReadOnly = true;
            this.TelefonoCelular.Width = 125;
            // 
            // Mail
            // 
            this.Mail.HeaderText = "Mail";
            this.Mail.MinimumWidth = 6;
            this.Mail.Name = "Mail";
            this.Mail.ReadOnly = true;
            this.Mail.Width = 125;
            // 
            // IdNacionalidad
            // 
            this.IdNacionalidad.HeaderText = "IdNacionalidad";
            this.IdNacionalidad.MinimumWidth = 6;
            this.IdNacionalidad.Name = "IdNacionalidad";
            this.IdNacionalidad.Visible = false;
            this.IdNacionalidad.Width = 125;
            // 
            // Nacionalidad
            // 
            this.Nacionalidad.HeaderText = "Nacionalidad";
            this.Nacionalidad.MinimumWidth = 6;
            this.Nacionalidad.Name = "Nacionalidad";
            this.Nacionalidad.ReadOnly = true;
            this.Nacionalidad.Width = 125;
            // 
            // IdSexo
            // 
            this.IdSexo.HeaderText = "IdSexo";
            this.IdSexo.MinimumWidth = 6;
            this.IdSexo.Name = "IdSexo";
            this.IdSexo.Visible = false;
            this.IdSexo.Width = 125;
            // 
            // Sexo
            // 
            this.Sexo.HeaderText = "Sexo";
            this.Sexo.MinimumWidth = 6;
            this.Sexo.Name = "Sexo";
            this.Sexo.ReadOnly = true;
            this.Sexo.Width = 125;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.SteelBlue;
            this.label4.Font = new System.Drawing.Font("Impact", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(43, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 46);
            this.label4.TabIndex = 204;
            this.label4.Text = "2";
            // 
            // ipbCirculo
            // 
            this.ipbCirculo.BackColor = System.Drawing.Color.SteelBlue;
            this.ipbCirculo.IconChar = FontAwesome.Sharp.IconChar.Circle;
            this.ipbCirculo.IconColor = System.Drawing.Color.White;
            this.ipbCirculo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ipbCirculo.IconSize = 101;
            this.ipbCirculo.Location = new System.Drawing.Point(14, 13);
            this.ipbCirculo.Name = "ipbCirculo";
            this.ipbCirculo.Size = new System.Drawing.Size(106, 101);
            this.ipbCirculo.TabIndex = 203;
            this.ipbCirculo.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1183, 114);
            this.label1.TabIndex = 205;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(126, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 39);
            this.label2.TabIndex = 206;
            this.label2.Text = "¿Quiénes viajan?";
            // 
            // FrmRegistrarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1183, 463);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ipbCirculo);
            this.Controls.Add(this.dgvPasajeros);
            this.Controls.Add(this.btnEliminarPasajero);
            this.Controls.Add(this.btnAgregarPasajero);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRegistrarReserva";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Pasajeros de Reserva";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRegistrarReserva_FormClosing);
            this.Load += new System.EventHandler(this.FrmRegistrarReserva_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPasajeros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ipbCirculo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton btnConfirmar;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private FontAwesome.Sharp.IconButton btnAgregarPasajero;
        private FontAwesome.Sharp.IconButton btnEliminarPasajero;
        private System.Windows.Forms.DataGridView dgvPasajeros;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Titular;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn TelefonoCelular;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdNacionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nacionalidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdSexo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sexo;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconPictureBox ipbCirculo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}