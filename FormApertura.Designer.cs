
namespace CajaRegistradoa
{
    partial class FormApertura
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
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAperturar = new System.Windows.Forms.Button();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(158, 27);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(102, 42);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(7, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 34);
            this.label4.TabIndex = 30;
            this.label4.Text = "Ingresar $:";
            // 
            // btnAperturar
            // 
            this.btnAperturar.BackColor = System.Drawing.Color.DarkCyan;
            this.btnAperturar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAperturar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnAperturar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnAperturar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAperturar.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAperturar.ForeColor = System.Drawing.Color.White;
            this.btnAperturar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAperturar.Location = new System.Drawing.Point(267, 27);
            this.btnAperturar.Name = "btnAperturar";
            this.btnAperturar.Size = new System.Drawing.Size(139, 41);
            this.btnAperturar.TabIndex = 2;
            this.btnAperturar.Text = "&Aperturar";
            this.btnAperturar.UseVisualStyleBackColor = false;
            this.btnAperturar.Click += new System.EventHandler(this.btnAperturar_Click);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.Teal;
            this.lblMensaje.Location = new System.Drawing.Point(11, 76);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(355, 16);
            this.lblMensaje.TabIndex = 32;
            this.lblMensaje.Text = "Es necesario ingresar una cantidad para poder continuar...";
            // 
            // FormApertura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(415, 109);
            this.ControlBox = false;
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.btnAperturar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormApertura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apertura de caja";
            this.Load += new System.EventHandler(this.FormApertura_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAperturar;
        private System.Windows.Forms.Label lblMensaje;
    }
}