
namespace CajaRegistradoa
{
    partial class FormPuntoVenta
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPuntoVenta));
            this.label2 = new System.Windows.Forms.Label();
            this.BarraEstado = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTelTienda = new System.Windows.Forms.Label();
            this.lblNombreTienda = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboxDevice = new System.Windows.Forms.ComboBox();
            this.btnOffScanner = new System.Windows.Forms.Button();
            this.btnOnScanner = new System.Windows.Forms.Button();
            this.lblNombreOperador = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblImporte = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblTotalVenta = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTotalLetras = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.lblCambio = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lstViewVenta = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCancelarVenta = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.pboxCamara = new System.Windows.Forms.PictureBox();
            this.btnCorteCaja = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnCerrarVenta = new System.Windows.Forms.Button();
            this.btnAperturaCaja = new System.Windows.Forms.Button();
            this.btnMasDUnProducto = new System.Windows.Forms.Button();
            this.btnBorrarProducto = new System.Windows.Forms.Button();
            this.BarraEstado.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxCamara)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkCyan;
            this.label2.Location = new System.Drawing.Point(320, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(470, 41);
            this.label2.TabIndex = 2;
            this.label2.Text = "R E G I S T R O   D E  V E N T A";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BarraEstado
            // 
            this.BarraEstado.BackColor = System.Drawing.SystemColors.Control;
            this.BarraEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BarraEstado.Controls.Add(this.label7);
            this.BarraEstado.Controls.Add(this.lblTelTienda);
            this.BarraEstado.Controls.Add(this.lblNombreTienda);
            this.BarraEstado.Controls.Add(this.label14);
            this.BarraEstado.Controls.Add(this.cboxDevice);
            this.BarraEstado.Controls.Add(this.btnOffScanner);
            this.BarraEstado.Controls.Add(this.btnOnScanner);
            this.BarraEstado.Controls.Add(this.lblNombreOperador);
            this.BarraEstado.Controls.Add(this.label1);
            this.BarraEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BarraEstado.Location = new System.Drawing.Point(0, 664);
            this.BarraEstado.Name = "BarraEstado";
            this.BarraEstado.Size = new System.Drawing.Size(1255, 32);
            this.BarraEstado.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(225, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 23);
            this.label7.TabIndex = 22;
            this.label7.Text = "Operador:";
            // 
            // lblTelTienda
            // 
            this.lblTelTienda.AutoSize = true;
            this.lblTelTienda.Location = new System.Drawing.Point(557, 9);
            this.lblTelTienda.Name = "lblTelTienda";
            this.lblTelTienda.Size = new System.Drawing.Size(34, 13);
            this.lblTelTienda.TabIndex = 21;
            this.lblTelTienda.Text = "---------";
            this.lblTelTienda.Visible = false;
            // 
            // lblNombreTienda
            // 
            this.lblNombreTienda.AutoSize = true;
            this.lblNombreTienda.Location = new System.Drawing.Point(464, 11);
            this.lblNombreTienda.Name = "lblNombreTienda";
            this.lblNombreTienda.Size = new System.Drawing.Size(31, 13);
            this.lblNombreTienda.TabIndex = 20;
            this.lblNombreTienda.Text = "--------";
            this.lblNombreTienda.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkCyan;
            this.label14.Location = new System.Drawing.Point(766, 5);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(69, 21);
            this.label14.TabIndex = 19;
            this.label14.Text = "Scanner:";
            // 
            // cboxDevice
            // 
            this.cboxDevice.FormattingEnabled = true;
            this.cboxDevice.Location = new System.Drawing.Point(838, 5);
            this.cboxDevice.Name = "cboxDevice";
            this.cboxDevice.Size = new System.Drawing.Size(103, 21);
            this.cboxDevice.TabIndex = 18;
            // 
            // btnOffScanner
            // 
            this.btnOffScanner.BackColor = System.Drawing.Color.Red;
            this.btnOffScanner.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnOffScanner.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnOffScanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOffScanner.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOffScanner.ForeColor = System.Drawing.Color.White;
            this.btnOffScanner.Image = ((System.Drawing.Image)(resources.GetObject("btnOffScanner.Image")));
            this.btnOffScanner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOffScanner.Location = new System.Drawing.Point(1008, 5);
            this.btnOffScanner.Name = "btnOffScanner";
            this.btnOffScanner.Size = new System.Drawing.Size(65, 22);
            this.btnOffScanner.TabIndex = 17;
            this.btnOffScanner.Text = "O&ff";
            this.btnOffScanner.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOffScanner.UseVisualStyleBackColor = false;
            this.btnOffScanner.Click += new System.EventHandler(this.btnOffScanner_Click);
            // 
            // btnOnScanner
            // 
            this.btnOnScanner.BackColor = System.Drawing.Color.Black;
            this.btnOnScanner.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnOnScanner.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnOnScanner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOnScanner.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOnScanner.ForeColor = System.Drawing.Color.White;
            this.btnOnScanner.Image = ((System.Drawing.Image)(resources.GetObject("btnOnScanner.Image")));
            this.btnOnScanner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOnScanner.Location = new System.Drawing.Point(943, 5);
            this.btnOnScanner.Name = "btnOnScanner";
            this.btnOnScanner.Size = new System.Drawing.Size(61, 22);
            this.btnOnScanner.TabIndex = 16;
            this.btnOnScanner.Text = "&On";
            this.btnOnScanner.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOnScanner.UseVisualStyleBackColor = false;
            this.btnOnScanner.Click += new System.EventHandler(this.btnOnScanner_Click);
            // 
            // lblNombreOperador
            // 
            this.lblNombreOperador.AutoSize = true;
            this.lblNombreOperador.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreOperador.ForeColor = System.Drawing.Color.DimGray;
            this.lblNombreOperador.Location = new System.Drawing.Point(322, 5);
            this.lblNombreOperador.Name = "lblNombreOperador";
            this.lblNombreOperador.Size = new System.Drawing.Size(146, 23);
            this.lblNombreOperador.TabIndex = 4;
            this.lblNombreOperador.Text = "-----------------";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(12, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "CAJA 1  Abierta";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.lblImporte);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(767, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 194);
            this.panel1.TabIndex = 4;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporte.ForeColor = System.Drawing.Color.Black;
            this.lblImporte.Location = new System.Drawing.Point(6, 81);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(370, 108);
            this.lblImporte.TabIndex = 2;
            this.lblImporte.Text = "$ 00.00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(3, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 42);
            this.label4.TabIndex = 1;
            this.label4.Text = "IMPORTE:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblTotalVenta);
            this.panel2.Location = new System.Drawing.Point(767, 256);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(434, 200);
            this.panel2.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 42);
            this.label6.TabIndex = 4;
            this.label6.Text = "TOTAL:";
            // 
            // lblTotalVenta
            // 
            this.lblTotalVenta.AutoSize = true;
            this.lblTotalVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVenta.ForeColor = System.Drawing.Color.Black;
            this.lblTotalVenta.Location = new System.Drawing.Point(6, 85);
            this.lblTotalVenta.Name = "lblTotalVenta";
            this.lblTotalVenta.Size = new System.Drawing.Size(370, 108);
            this.lblTotalVenta.TabIndex = 3;
            this.lblTotalVenta.Text = "$ 00.00";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.lblTotalLetras);
            this.panel3.Controls.Add(this.txtEfectivo);
            this.panel3.Controls.Add(this.lblCambio);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(12, 458);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(731, 200);
            this.panel3.TabIndex = 6;
            // 
            // lblTotalLetras
            // 
            this.lblTotalLetras.AutoSize = true;
            this.lblTotalLetras.Font = new System.Drawing.Font("Microsoft Tai Le", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalLetras.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalLetras.Location = new System.Drawing.Point(38, 160);
            this.lblTotalLetras.Name = "lblTotalLetras";
            this.lblTotalLetras.Size = new System.Drawing.Size(587, 34);
            this.lblTotalLetras.TabIndex = 9;
            this.lblTotalLetras.Text = "----------------------------------------------------";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Tai Le", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEfectivo.Location = new System.Drawing.Point(315, 10);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(299, 69);
            this.txtEfectivo.TabIndex = 8;
            this.txtEfectivo.Enter += new System.EventHandler(this.txtEfectivo_Enter);
            this.txtEfectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEfectivo_KeyPress);
            this.txtEfectivo.Leave += new System.EventHandler(this.txtEfectivo_Leave);
            // 
            // lblCambio
            // 
            this.lblCambio.AutoSize = true;
            this.lblCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCambio.ForeColor = System.Drawing.Color.Black;
            this.lblCambio.Location = new System.Drawing.Point(315, 92);
            this.lblCambio.Name = "lblCambio";
            this.lblCambio.Size = new System.Drawing.Size(192, 55);
            this.lblCambio.TabIndex = 7;
            this.lblCambio.Text = "$ 00.00";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(85, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(233, 55);
            this.label5.TabIndex = 6;
            this.label5.Text = "CAMBIO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(34, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(285, 55);
            this.label3.TabIndex = 5;
            this.label3.Text = "EFECTIVO:";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.lstViewVenta);
            this.panel4.Location = new System.Drawing.Point(174, 58);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(569, 398);
            this.panel4.TabIndex = 7;
            // 
            // lstViewVenta
            // 
            this.lstViewVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lstViewVenta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstViewVenta.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader7});
            this.lstViewVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstViewVenta.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstViewVenta.FullRowSelect = true;
            this.lstViewVenta.GridLines = true;
            this.lstViewVenta.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewVenta.HideSelection = false;
            this.lstViewVenta.Location = new System.Drawing.Point(-2, -2);
            this.lstViewVenta.MultiSelect = false;
            this.lstViewVenta.Name = "lstViewVenta";
            this.lstViewVenta.Size = new System.Drawing.Size(564, 398);
            this.lstViewVenta.TabIndex = 1;
            this.lstViewVenta.UseCompatibleStateImageBehavior = false;
            this.lstViewVenta.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Código";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Cantidad";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Descripción del producto";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 260;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Importe";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 100;
            // 
            // btnCancelarVenta
            // 
            this.btnCancelarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelarVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarVenta.Enabled = false;
            this.btnCancelarVenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelarVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnCancelarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarVenta.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarVenta.ForeColor = System.Drawing.Color.White;
            this.btnCancelarVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarVenta.Location = new System.Drawing.Point(12, 195);
            this.btnCancelarVenta.Name = "btnCancelarVenta";
            this.btnCancelarVenta.Size = new System.Drawing.Size(139, 57);
            this.btnCancelarVenta.TabIndex = 8;
            this.btnCancelarVenta.Text = "Cancelar &venta";
            this.btnCancelarVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarVenta.UseVisualStyleBackColor = false;
            this.btnCancelarVenta.Click += new System.EventHandler(this.btnCancelarVenta_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.pboxCamara);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.DarkCyan;
            this.groupBox5.Location = new System.Drawing.Point(767, 468);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(180, 190);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Scanner";
            // 
            // pboxCamara
            // 
            this.pboxCamara.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pboxCamara.Image = global::CajaRegistradoa.Properties.Resources.Scanner;
            this.pboxCamara.Location = new System.Drawing.Point(4, 22);
            this.pboxCamara.Name = "pboxCamara";
            this.pboxCamara.Size = new System.Drawing.Size(170, 162);
            this.pboxCamara.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxCamara.TabIndex = 16;
            this.pboxCamara.TabStop = false;
            // 
            // btnCorteCaja
            // 
            this.btnCorteCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCorteCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCorteCaja.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCorteCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnCorteCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCorteCaja.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCorteCaja.ForeColor = System.Drawing.Color.White;
            this.btnCorteCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCorteCaja.Location = new System.Drawing.Point(12, 267);
            this.btnCorteCaja.Name = "btnCorteCaja";
            this.btnCorteCaja.Size = new System.Drawing.Size(139, 57);
            this.btnCorteCaja.TabIndex = 20;
            this.btnCorteCaja.Text = " Corte de &caja";
            this.btnCorteCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCorteCaja.UseVisualStyleBackColor = false;
            this.btnCorteCaja.Click += new System.EventHandler(this.btnCorteCaja_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnCerrarVenta
            // 
            this.btnCerrarVenta.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCerrarVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarVenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btnCerrarVenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnCerrarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarVenta.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarVenta.ForeColor = System.Drawing.Color.White;
            this.btnCerrarVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarVenta.Location = new System.Drawing.Point(12, 341);
            this.btnCerrarVenta.Name = "btnCerrarVenta";
            this.btnCerrarVenta.Size = new System.Drawing.Size(139, 57);
            this.btnCerrarVenta.TabIndex = 21;
            this.btnCerrarVenta.Text = " &Guardar venta";
            this.btnCerrarVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCerrarVenta.UseVisualStyleBackColor = false;
            this.btnCerrarVenta.Click += new System.EventHandler(this.btnCerrarVenta_Click);
            // 
            // btnAperturaCaja
            // 
            this.btnAperturaCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAperturaCaja.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAperturaCaja.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnAperturaCaja.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnAperturaCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAperturaCaja.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAperturaCaja.ForeColor = System.Drawing.Color.White;
            this.btnAperturaCaja.Image = ((System.Drawing.Image)(resources.GetObject("btnAperturaCaja.Image")));
            this.btnAperturaCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAperturaCaja.Location = new System.Drawing.Point(12, 12);
            this.btnAperturaCaja.Name = "btnAperturaCaja";
            this.btnAperturaCaja.Size = new System.Drawing.Size(184, 40);
            this.btnAperturaCaja.TabIndex = 18;
            this.btnAperturaCaja.Text = "&Apertura de caja";
            this.btnAperturaCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAperturaCaja.UseVisualStyleBackColor = false;
            this.btnAperturaCaja.Click += new System.EventHandler(this.btnAperturaCaja_Click);
            // 
            // btnMasDUnProducto
            // 
            this.btnMasDUnProducto.BackColor = System.Drawing.Color.DarkCyan;
            this.btnMasDUnProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMasDUnProducto.Enabled = false;
            this.btnMasDUnProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnMasDUnProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnMasDUnProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMasDUnProducto.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMasDUnProducto.ForeColor = System.Drawing.Color.White;
            this.btnMasDUnProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnMasDUnProducto.Image")));
            this.btnMasDUnProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMasDUnProducto.Location = new System.Drawing.Point(12, 127);
            this.btnMasDUnProducto.Name = "btnMasDUnProducto";
            this.btnMasDUnProducto.Size = new System.Drawing.Size(139, 57);
            this.btnMasDUnProducto.TabIndex = 10;
            this.btnMasDUnProducto.Text = "Act&ualizar cantidad";
            this.btnMasDUnProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMasDUnProducto.UseVisualStyleBackColor = false;
            this.btnMasDUnProducto.Click += new System.EventHandler(this.btnMasDUnProducto_Click);
            // 
            // btnBorrarProducto
            // 
            this.btnBorrarProducto.BackColor = System.Drawing.Color.DarkCyan;
            this.btnBorrarProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBorrarProducto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnBorrarProducto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnBorrarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrarProducto.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrarProducto.ForeColor = System.Drawing.Color.White;
            this.btnBorrarProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnBorrarProducto.Image")));
            this.btnBorrarProducto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrarProducto.Location = new System.Drawing.Point(12, 58);
            this.btnBorrarProducto.Name = "btnBorrarProducto";
            this.btnBorrarProducto.Size = new System.Drawing.Size(139, 52);
            this.btnBorrarProducto.TabIndex = 9;
            this.btnBorrarProducto.Text = "&Eliminar producto";
            this.btnBorrarProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBorrarProducto.UseVisualStyleBackColor = false;
            this.btnBorrarProducto.Click += new System.EventHandler(this.btnBorrarProducto_Click);
            // 
            // FormPuntoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1255, 696);
            this.Controls.Add(this.btnCerrarVenta);
            this.Controls.Add(this.btnCorteCaja);
            this.Controls.Add(this.btnAperturaCaja);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.btnMasDUnProducto);
            this.Controls.Add(this.btnBorrarProducto);
            this.Controls.Add(this.btnCancelarVenta);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.BarraEstado);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPuntoVenta";
            this.Text = "s";
            this.Load += new System.EventHandler(this.FormPuntoVenta_Load);
            this.BarraEstado.ResumeLayout(false);
            this.BarraEstado.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxCamara)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel BarraEstado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNombreOperador;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblTotalVenta;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.Label lblCambio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboxDevice;
        private System.Windows.Forms.Button btnOffScanner;
        private System.Windows.Forms.Button btnOnScanner;
        private System.Windows.Forms.Button btnCancelarVenta;
        private System.Windows.Forms.Button btnBorrarProducto;
        private System.Windows.Forms.Button btnMasDUnProducto;
        private System.Windows.Forms.ListView lstViewVenta;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.PictureBox pboxCamara;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnAperturaCaja;
        private System.Windows.Forms.Button btnCorteCaja;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnCerrarVenta;
        private System.Windows.Forms.Label lblTotalLetras;
        private System.Windows.Forms.Label lblNombreTienda;
        private System.Windows.Forms.Label lblTelTienda;
        private System.Windows.Forms.Label label7;
    }
}