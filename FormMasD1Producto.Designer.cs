
namespace CajaRegistradoa
{
    partial class FormMasD1Producto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMasD1Producto));
            this.btnActualizarCantidad = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescripcionProducto = new System.Windows.Forms.TextBox();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnActualizarCantidad
            // 
            this.btnActualizarCantidad.BackColor = System.Drawing.Color.DarkCyan;
            this.btnActualizarCantidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnActualizarCantidad.Enabled = false;
            this.btnActualizarCantidad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnActualizarCantidad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnActualizarCantidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarCantidad.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarCantidad.ForeColor = System.Drawing.Color.White;
            this.btnActualizarCantidad.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarCantidad.Image")));
            this.btnActualizarCantidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizarCantidad.Location = new System.Drawing.Point(28, 215);
            this.btnActualizarCantidad.Name = "btnActualizarCantidad";
            this.btnActualizarCantidad.Size = new System.Drawing.Size(139, 41);
            this.btnActualizarCantidad.TabIndex = 21;
            this.btnActualizarCantidad.Text = "&Actualizar";
            this.btnActualizarCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizarCantidad.UseVisualStyleBackColor = false;
            this.btnActualizarCantidad.Click += new System.EventHandler(this.btnActualizarCantidad_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(212, 215);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(139, 40);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Cursor = System.Windows.Forms.Cursors.No;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.ForeColor = System.Drawing.Color.DimGray;
            this.txtCodigo.Location = new System.Drawing.Point(28, 33);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(146, 32);
            this.txtCodigo.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Location = new System.Drawing.Point(24, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 23);
            this.label6.TabIndex = 24;
            this.label6.Text = "Código:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Location = new System.Drawing.Point(24, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(249, 26);
            this.label7.TabIndex = 26;
            this.label7.Text = "Descripción del producto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(23, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 26);
            this.label4.TabIndex = 28;
            this.label4.Text = "Cantidad:";
            // 
            // txtDescripcionProducto
            // 
            this.txtDescripcionProducto.Cursor = System.Windows.Forms.Cursors.No;
            this.txtDescripcionProducto.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcionProducto.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescripcionProducto.Location = new System.Drawing.Point(28, 98);
            this.txtDescripcionProducto.Name = "txtDescripcionProducto";
            this.txtDescripcionProducto.ReadOnly = true;
            this.txtDescripcionProducto.Size = new System.Drawing.Size(323, 32);
            this.txtDescripcionProducto.TabIndex = 3;
            // 
            // txtImporte
            // 
            this.txtImporte.Cursor = System.Windows.Forms.Cursors.No;
            this.txtImporte.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporte.ForeColor = System.Drawing.Color.DimGray;
            this.txtImporte.Location = new System.Drawing.Point(212, 158);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.ReadOnly = true;
            this.txtImporte.Size = new System.Drawing.Size(139, 32);
            this.txtImporte.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(208, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 23);
            this.label1.TabIndex = 31;
            this.label1.Text = "Importe:";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(129, 158);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(45, 32);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress_1);
            // 
            // FormMasD1Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(365, 271);
            this.ControlBox = false;
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtImporte);
            this.Controls.Add(this.txtDescripcionProducto);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnActualizarCantidad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormMasD1Producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Actualizar cantidad de producto";
            this.Load += new System.EventHandler(this.FormMasD1Producto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnActualizarCantidad;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescripcionProducto;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtCantidad;
    }
}