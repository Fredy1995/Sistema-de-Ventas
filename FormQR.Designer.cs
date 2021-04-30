
namespace CajaRegistradoa
{
    partial class FormQR
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQR));
            this.label2 = new System.Windows.Forms.Label();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.btngGuardar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.pboxGuardar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCambiarT = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnGenerarIDProducto = new System.Windows.Forms.Button();
            this.pb150 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pb250 = new System.Windows.Forms.PictureBox();
            this.pb200 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pboxGuardar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb150)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb250)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb200)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(403, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(461, 41);
            this.label2.TabIndex = 2;
            this.label2.Text = "C R E A R   C Ó D I G O S   Q R";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lineShape1
            // 
            this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape1.BorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lineShape1.BorderWidth = 2;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = -1;
            this.lineShape1.X2 = 1695;
            this.lineShape1.Y1 = 54;
            this.lineShape1.Y2 = 54;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1255, 685);
            this.shapeContainer1.TabIndex = 3;
            this.shapeContainer1.TabStop = false;
            // 
            // btngGuardar
            // 
            this.btngGuardar.BackColor = System.Drawing.Color.DarkCyan;
            this.btngGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btngGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btngGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btngGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngGuardar.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngGuardar.ForeColor = System.Drawing.Color.White;
            this.btngGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btngGuardar.Image")));
            this.btngGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btngGuardar.Location = new System.Drawing.Point(161, 559);
            this.btngGuardar.Name = "btngGuardar";
            this.btngGuardar.Size = new System.Drawing.Size(216, 41);
            this.btngGuardar.TabIndex = 5;
            this.btngGuardar.Text = "&Guardar como...";
            this.btngGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btngGuardar.UseVisualStyleBackColor = false;
            this.btngGuardar.Click += new System.EventHandler(this.btngGuardar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Cursor = System.Windows.Forms.Cursors.No;
            this.txtCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigo.ForeColor = System.Drawing.Color.DimGray;
            this.txtCodigo.Location = new System.Drawing.Point(217, 145);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(220, 31);
            this.txtCodigo.TabIndex = 6;
            this.txtCodigo.TextChanged += new System.EventHandler(this.txtCodigo_TextChanged);
            // 
            // pboxGuardar
            // 
            this.pboxGuardar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pboxGuardar.Location = new System.Drawing.Point(137, 182);
            this.pboxGuardar.Name = "pboxGuardar";
            this.pboxGuardar.Size = new System.Drawing.Size(300, 300);
            this.pboxGuardar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pboxGuardar.TabIndex = 7;
            this.pboxGuardar.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkCyan;
            this.label1.Location = new System.Drawing.Point(3, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 23);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tamaño recomendado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkCyan;
            this.label3.Location = new System.Drawing.Point(41, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Código producto:";
            // 
            // txtX
            // 
            this.txtX.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtX.ForeColor = System.Drawing.Color.DarkGray;
            this.txtX.Location = new System.Drawing.Point(217, 94);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(62, 32);
            this.txtX.TabIndex = 10;
            this.txtX.Text = "100";
            this.txtX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtX_KeyPress);
            this.txtX.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtX_KeyUp);
            // 
            // txtY
            // 
            this.txtY.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtY.ForeColor = System.Drawing.Color.DarkGray;
            this.txtY.Location = new System.Drawing.Point(313, 94);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(52, 32);
            this.txtY.TabIndex = 11;
            this.txtY.Text = "100";
            this.txtY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtY_KeyPress);
            this.txtY.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtY_KeyUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkCyan;
            this.label4.Location = new System.Drawing.Point(285, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkCyan;
            this.label5.Location = new System.Drawing.Point(366, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Píxeles.";
            // 
            // btnCambiarT
            // 
            this.btnCambiarT.BackColor = System.Drawing.Color.DarkCyan;
            this.btnCambiarT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnCambiarT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnCambiarT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarT.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarT.ForeColor = System.Drawing.Color.White;
            this.btnCambiarT.Image = ((System.Drawing.Image)(resources.GetObject("btnCambiarT.Image")));
            this.btnCambiarT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarT.Location = new System.Drawing.Point(455, 88);
            this.btnCambiarT.Name = "btnCambiarT";
            this.btnCambiarT.Size = new System.Drawing.Size(232, 41);
            this.btnCambiarT.TabIndex = 14;
            this.btnCambiarT.Text = "Cambiar &tamaño";
            this.btnCambiarT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarT.UseVisualStyleBackColor = false;
            this.btnCambiarT.Click += new System.EventHandler(this.btnCambiarT_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkCyan;
            this.label6.Location = new System.Drawing.Point(3, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "QR obtenido:";
            // 
            // btnGenerarIDProducto
            // 
            this.btnGenerarIDProducto.BackColor = System.Drawing.Color.DarkCyan;
            this.btnGenerarIDProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarIDProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnGenerarIDProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnGenerarIDProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarIDProducto.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarIDProducto.ForeColor = System.Drawing.Color.White;
            this.btnGenerarIDProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerarIDProducto.Image")));
            this.btnGenerarIDProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarIDProducto.Location = new System.Drawing.Point(161, 499);
            this.btnGenerarIDProducto.Name = "btnGenerarIDProducto";
            this.btnGenerarIDProducto.Size = new System.Drawing.Size(216, 41);
            this.btnGenerarIDProducto.TabIndex = 16;
            this.btnGenerarIDProducto.Text = "Generar &otro ID";
            this.btnGenerarIDProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarIDProducto.UseVisualStyleBackColor = false;
            this.btnGenerarIDProducto.Click += new System.EventHandler(this.btnGenerarIDProducto_Click);
            // 
            // pb150
            // 
            this.pb150.BackColor = System.Drawing.Color.Transparent;
            this.pb150.Image = ((System.Drawing.Image)(resources.GetObject("pb150.Image")));
            this.pb150.Location = new System.Drawing.Point(176, 31);
            this.pb150.Name = "pb150";
            this.pb150.Size = new System.Drawing.Size(150, 150);
            this.pb150.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb150.TabIndex = 17;
            this.pb150.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.pb250);
            this.groupBox1.Controls.Add(this.pb200);
            this.groupBox1.Controls.Add(this.pb150);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
            this.groupBox1.Location = new System.Drawing.Point(455, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(659, 538);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dimensiones QR";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkCyan;
            this.label10.Location = new System.Drawing.Point(407, 507);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 23);
            this.label10.TabIndex = 24;
            this.label10.Text = "250 x 250";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkCyan;
            this.label9.Location = new System.Drawing.Point(31, 507);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 23);
            this.label9.TabIndex = 23;
            this.label9.Text = "300 x 300 ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DarkCyan;
            this.label8.Location = new System.Drawing.Point(332, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 23);
            this.label8.TabIndex = 22;
            this.label8.Text = "200 x 200";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkCyan;
            this.label7.Location = new System.Drawing.Point(45, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 23);
            this.label7.TabIndex = 21;
            this.label7.Text = "150 x 150";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(26, 204);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // pb250
            // 
            this.pb250.BackColor = System.Drawing.Color.Transparent;
            this.pb250.Image = ((System.Drawing.Image)(resources.GetObject("pb250.Image")));
            this.pb250.Location = new System.Drawing.Point(385, 243);
            this.pb250.Name = "pb250";
            this.pb250.Size = new System.Drawing.Size(250, 250);
            this.pb250.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pb250.TabIndex = 19;
            this.pb250.TabStop = false;
            // 
            // pb200
            // 
            this.pb200.BackColor = System.Drawing.Color.Transparent;
            this.pb200.Image = ((System.Drawing.Image)(resources.GetObject("pb200.Image")));
            this.pb200.Location = new System.Drawing.Point(435, 22);
            this.pb200.Name = "pb200";
            this.pb200.Size = new System.Drawing.Size(200, 200);
            this.pb200.TabIndex = 18;
            this.pb200.TabStop = false;
            // 
            // FormQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1255, 685);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnGenerarIDProducto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCambiarT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pboxGuardar);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.btngGuardar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQR";
            this.Text = "FormQR";
            this.Load += new System.EventHandler(this.FormQR_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxGuardar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb150)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb250)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb200)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private System.Windows.Forms.Button btngGuardar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.PictureBox pboxGuardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCambiarT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGenerarIDProducto;
        private System.Windows.Forms.PictureBox pb150;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pb250;
        private System.Windows.Forms.PictureBox pb200;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}