
namespace CajaRegistradoa
{
    partial class FormResgistrarse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormResgistrarse));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtPaterno = new System.Windows.Forms.TextBox();
            this.txtMaterno = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dFecha = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.btnEncender = new System.Windows.Forms.Button();
            this.btnCapturar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cbDispositivos = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(100, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "AGREGAR NUEVO USUARIO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(8, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre(s):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(8, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Apellidos:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.Silver;
            this.txtNombre.Location = new System.Drawing.Point(13, 59);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(277, 28);
            this.txtNombre.TabIndex = 8;
            this.txtNombre.Text = "---------------------------------------------";
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // txtPaterno
            // 
            this.txtPaterno.BackColor = System.Drawing.Color.White;
            this.txtPaterno.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaterno.ForeColor = System.Drawing.Color.Silver;
            this.txtPaterno.Location = new System.Drawing.Point(13, 119);
            this.txtPaterno.Name = "txtPaterno";
            this.txtPaterno.Size = new System.Drawing.Size(131, 28);
            this.txtPaterno.TabIndex = 9;
            this.txtPaterno.Text = "Paterno";
            this.txtPaterno.Enter += new System.EventHandler(this.txtPaterno_Enter);
            this.txtPaterno.Leave += new System.EventHandler(this.txtPaterno_Leave);
            // 
            // txtMaterno
            // 
            this.txtMaterno.BackColor = System.Drawing.Color.White;
            this.txtMaterno.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaterno.ForeColor = System.Drawing.Color.Silver;
            this.txtMaterno.Location = new System.Drawing.Point(159, 119);
            this.txtMaterno.Name = "txtMaterno";
            this.txtMaterno.Size = new System.Drawing.Size(131, 28);
            this.txtMaterno.TabIndex = 10;
            this.txtMaterno.Text = "Materno";
            this.txtMaterno.Enter += new System.EventHandler(this.txtMaterno_Enter);
            this.txtMaterno.Leave += new System.EventHandler(this.txtMaterno_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dFecha);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPaterno);
            this.groupBox1.Controls.Add(this.txtMaterno);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtEdad);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Silver;
            this.groupBox1.Location = new System.Drawing.Point(12, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 231);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos personales";
            // 
            // dFecha
            // 
            this.dFecha.CalendarFont = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dFecha.CalendarTitleBackColor = System.Drawing.SystemColors.ControlText;
            this.dFecha.CalendarTitleForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.dFecha.CalendarTrailingForeColor = System.Drawing.Color.Silver;
            this.dFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dFecha.Location = new System.Drawing.Point(152, 194);
            this.dFecha.Name = "dFecha";
            this.dFecha.Size = new System.Drawing.Size(139, 28);
            this.dFecha.TabIndex = 22;
            this.dFecha.Value = new System.DateTime(1985, 1, 1, 0, 0, 0, 0);
            this.dFecha.Leave += new System.EventHandler(this.dFecha_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkCyan;
            this.label9.Location = new System.Drawing.Point(1, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 23);
            this.label9.TabIndex = 22;
            this.label9.Text = "F. NACIMIENTO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(8, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "ID:";
            // 
            // txtEdad
            // 
            this.txtEdad.BackColor = System.Drawing.SystemColors.Control;
            this.txtEdad.Cursor = System.Windows.Forms.Cursors.No;
            this.txtEdad.Enabled = false;
            this.txtEdad.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdad.ForeColor = System.Drawing.Color.Silver;
            this.txtEdad.Location = new System.Drawing.Point(232, 159);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(58, 28);
            this.txtEdad.TabIndex = 17;
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Control;
            this.txtID.Cursor = System.Windows.Forms.Cursors.No;
            this.txtID.Enabled = false;
            this.txtID.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtID.ForeColor = System.Drawing.Color.Silver;
            this.txtID.Location = new System.Drawing.Point(52, 160);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(92, 28);
            this.txtID.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkCyan;
            this.label6.Location = new System.Drawing.Point(154, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 23);
            this.label6.TabIndex = 16;
            this.label6.Text = "EDAD:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(13, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 21);
            this.label5.TabIndex = 14;
            this.label5.Text = "FECHA DE REGISTRO:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.DimGray;
            this.lblFecha.Location = new System.Drawing.Point(187, 44);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(100, 21);
            this.lblFecha.TabIndex = 15;
            this.lblFecha.Text = "dd/mm/aaaa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkCyan;
            this.label7.Location = new System.Drawing.Point(3, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 23);
            this.label7.TabIndex = 18;
            this.label7.Text = "CONTRASEÑA:";
            // 
            // txtContraseña
            // 
            this.txtContraseña.BackColor = System.Drawing.Color.White;
            this.txtContraseña.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.ForeColor = System.Drawing.Color.Silver;
            this.txtContraseña.Location = new System.Drawing.Point(136, 55);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(155, 28);
            this.txtContraseña.TabIndex = 19;
            this.txtContraseña.Text = "Password";
            this.txtContraseña.Enter += new System.EventHandler(this.txtContraseña_Enter);
            this.txtContraseña.Leave += new System.EventHandler(this.txtContraseña_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkCyan;
            this.label8.Location = new System.Drawing.Point(1, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 23);
            this.label8.TabIndex = 20;
            this.label8.Text = "USUARIO:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.White;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.Silver;
            this.txtUsuario.Location = new System.Drawing.Point(93, 23);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(197, 28);
            this.txtUsuario.TabIndex = 21;
            this.txtUsuario.Text = "User name";
            this.txtUsuario.Enter += new System.EventHandler(this.txtUsuario_Enter);
            this.txtUsuario.Leave += new System.EventHandler(this.txtUsuario_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUsuario);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtContraseña);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Silver;
            this.groupBox2.Location = new System.Drawing.Point(12, 305);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(297, 90);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cuenta de usuario";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.pbFoto);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Silver;
            this.groupBox3.Location = new System.Drawing.Point(333, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(171, 182);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Foto perfil";
            // 
            // pbFoto
            // 
            this.pbFoto.Image = global::CajaRegistradoa.Properties.Resources.WebCam;
            this.pbFoto.Location = new System.Drawing.Point(6, 21);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(159, 158);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFoto.TabIndex = 0;
            this.pbFoto.TabStop = false;
            // 
            // btnEncender
            // 
            this.btnEncender.BackColor = System.Drawing.Color.DarkCyan;
            this.btnEncender.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEncender.FlatAppearance.BorderSize = 0;
            this.btnEncender.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnEncender.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnEncender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEncender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncender.ForeColor = System.Drawing.Color.White;
            this.btnEncender.Image = ((System.Drawing.Image)(resources.GetObject("btnEncender.Image")));
            this.btnEncender.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEncender.Location = new System.Drawing.Point(333, 257);
            this.btnEncender.Name = "btnEncender";
            this.btnEncender.Size = new System.Drawing.Size(171, 33);
            this.btnEncender.TabIndex = 24;
            this.btnEncender.Text = "&ENCENDER";
            this.btnEncender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEncender.UseVisualStyleBackColor = false;
            this.btnEncender.Click += new System.EventHandler(this.btnEncender_Click);
            // 
            // btnCapturar
            // 
            this.btnCapturar.AccessibleName = "";
            this.btnCapturar.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCapturar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapturar.Enabled = false;
            this.btnCapturar.FlatAppearance.BorderSize = 0;
            this.btnCapturar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnCapturar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnCapturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapturar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapturar.ForeColor = System.Drawing.Color.White;
            this.btnCapturar.Image = ((System.Drawing.Image)(resources.GetObject("btnCapturar.Image")));
            this.btnCapturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapturar.Location = new System.Drawing.Point(333, 296);
            this.btnCapturar.Name = "btnCapturar";
            this.btnCapturar.Size = new System.Drawing.Size(171, 33);
            this.btnCapturar.TabIndex = 25;
            this.btnCapturar.Text = "&CAPTURAR";
            this.btnCapturar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapturar.UseVisualStyleBackColor = false;
            this.btnCapturar.Click += new System.EventHandler(this.btnCapturar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.DarkCyan;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(333, 335);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(171, 61);
            this.btnGuardar.TabIndex = 26;
            this.btnGuardar.Text = "&GUARDAR";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cbDispositivos
            // 
            this.cbDispositivos.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDispositivos.ForeColor = System.Drawing.Color.Silver;
            this.cbDispositivos.FormattingEnabled = true;
            this.cbDispositivos.Location = new System.Drawing.Point(333, 228);
            this.cbDispositivos.Name = "cbDispositivos";
            this.cbDispositivos.Size = new System.Drawing.Size(171, 29);
            this.cbDispositivos.TabIndex = 27;
            this.cbDispositivos.Text = "Dispositivos";
            this.cbDispositivos.SelectedIndexChanged += new System.EventHandler(this.cbDispositivos_SelectedIndexChanged);
            // 
            // FormResgistrarse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(633, 400);
            this.Controls.Add(this.cbDispositivos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCapturar);
            this.Controls.Add(this.btnEncender);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormResgistrarse";
            this.Text = "FormResgistrarse";
            this.Load += new System.EventHandler(this.FormResgistrarse_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtPaterno;
        private System.Windows.Forms.TextBox txtMaterno;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DateTimePicker dFecha;
        private System.Windows.Forms.ComboBox cbDispositivos;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Button btnEncender;
        private System.Windows.Forms.Button btnCapturar;
    }
}