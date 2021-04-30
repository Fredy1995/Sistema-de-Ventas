
namespace CajaRegistradoa
{
    partial class FormDatosTienda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDatosTienda));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtSlogan = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPaginaWeb = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodigoPostal = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(100, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "DATOS DE MI TIENDA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(43, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(43, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Slogan:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(43, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Dirección:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(43, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Teléfono de contacto:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkCyan;
            this.label6.Location = new System.Drawing.Point(43, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 26);
            this.label6.TabIndex = 5;
            this.label6.Text = "E-mail:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkCyan;
            this.label7.Location = new System.Drawing.Point(43, 333);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 26);
            this.label7.TabIndex = 6;
            this.label7.Text = "Página web:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.Silver;
            this.txtNombre.Location = new System.Drawing.Point(48, 73);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(339, 28);
            this.txtNombre.TabIndex = 7;
            this.txtNombre.Text = "Ej: Mi tienda S.A DE C.V";
            this.txtNombre.Enter += new System.EventHandler(this.txtNombre_Enter);
            this.txtNombre.Leave += new System.EventHandler(this.txtNombre_Leave);
            // 
            // txtSlogan
            // 
            this.txtSlogan.BackColor = System.Drawing.Color.White;
            this.txtSlogan.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSlogan.ForeColor = System.Drawing.Color.Silver;
            this.txtSlogan.Location = new System.Drawing.Point(48, 129);
            this.txtSlogan.Name = "txtSlogan";
            this.txtSlogan.Size = new System.Drawing.Size(339, 28);
            this.txtSlogan.TabIndex = 8;
            this.txtSlogan.Text = "Ej: ¡Vender producto de calidad!";
            this.txtSlogan.Enter += new System.EventHandler(this.txtSlogan_Enter);
            this.txtSlogan.Leave += new System.EventHandler(this.txtSlogan_Leave);
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.White;
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.ForeColor = System.Drawing.Color.Silver;
            this.txtDireccion.Location = new System.Drawing.Point(48, 189);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(339, 28);
            this.txtDireccion.TabIndex = 9;
            this.txtDireccion.Text = "################";
            this.txtDireccion.Enter += new System.EventHandler(this.txtDireccion_Enter);
            this.txtDireccion.Leave += new System.EventHandler(this.txtDireccion_Leave);
            // 
            // txtTelefono
            // 
            this.txtTelefono.BackColor = System.Drawing.Color.White;
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefono.ForeColor = System.Drawing.Color.Silver;
            this.txtTelefono.Location = new System.Drawing.Point(48, 249);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(209, 28);
            this.txtTelefono.TabIndex = 10;
            this.txtTelefono.Text = "(##) ##-##-##-##-##";
            this.txtTelefono.Enter += new System.EventHandler(this.txtTelefono_Enter);
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            this.txtTelefono.Leave += new System.EventHandler(this.txtTelefono_Leave);
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Silver;
            this.txtEmail.Location = new System.Drawing.Point(48, 302);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(339, 28);
            this.txtEmail.TabIndex = 11;
            this.txtEmail.Text = "Mitienda@gmail.com";
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // txtPaginaWeb
            // 
            this.txtPaginaWeb.BackColor = System.Drawing.Color.White;
            this.txtPaginaWeb.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaginaWeb.ForeColor = System.Drawing.Color.Silver;
            this.txtPaginaWeb.Location = new System.Drawing.Point(48, 362);
            this.txtPaginaWeb.Name = "txtPaginaWeb";
            this.txtPaginaWeb.Size = new System.Drawing.Size(339, 28);
            this.txtPaginaWeb.TabIndex = 12;
            this.txtPaginaWeb.Text = "Ej: www.mitienda.com";
            this.txtPaginaWeb.Enter += new System.EventHandler(this.txtPaginaWeb_Enter);
            this.txtPaginaWeb.Leave += new System.EventHandler(this.txtPaginaWeb_Leave);
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.DarkCyan;
            this.btnActualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizar.FlatAppearance.BorderSize = 0;
            this.btnActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(393, 340);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(150, 52);
            this.btnActualizar.TabIndex = 13;
            this.btnActualizar.Text = "&Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkCyan;
            this.label8.Location = new System.Drawing.Point(388, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(145, 26);
            this.label8.TabIndex = 14;
            this.label8.Text = "Código Postal:";
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.BackColor = System.Drawing.Color.White;
            this.txtCodigoPostal.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoPostal.ForeColor = System.Drawing.Color.Silver;
            this.txtCodigoPostal.Location = new System.Drawing.Point(393, 189);
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(129, 28);
            this.txtCodigoPostal.TabIndex = 15;
            this.txtCodigoPostal.Text = "#####";
            this.txtCodigoPostal.Enter += new System.EventHandler(this.txtCodigoPostal_Enter);
            this.txtCodigoPostal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoPostal_KeyPress);
            this.txtCodigoPostal.Leave += new System.EventHandler(this.txtCodigoPostal_Leave);
            // 
            // FormDatosTienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(633, 404);
            this.Controls.Add(this.txtCodigoPostal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.txtPaginaWeb);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtSlogan);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDatosTienda";
            this.Text = "FormDatosTienda";
            this.Load += new System.EventHandler(this.FormDatosTienda_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtSlogan;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPaginaWeb;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodigoPostal;
    }
}