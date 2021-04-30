using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using SpreadsheetLight;
using System.IO;

namespace CajaRegistradoa
{
    public partial class FormQR : Form
    {
        private string PathA = @"C:\DataBaseSV\Archivos\"; //Directorio para Archivos
       
        public FormQR()
        {
            InitializeComponent();
        }

        private void btngGuardar_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Imagen png|*.png",
                InitialDirectory = @"C:\"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                pboxGuardar.Image.Save(sfd.FileName);
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            CambiarDimensiones();
        }
        private void CambiarDimensiones()
        {
            if (txtCodigo.Text != "")
            {
                BarcodeWriter br = new BarcodeWriter();
                br.Format = BarcodeFormat.QR_CODE;
                Bitmap bm = new Bitmap(br.Write(txtCodigo.Text), Convert.ToInt32(txtX.Text), Convert.ToInt32(txtY.Text));
                pboxGuardar.Image = bm;
            }
        }
        private void txtX_KeyUp(object sender, KeyEventArgs e)
        {
            txtY.Text = txtX.Text;
           
        }

        private void txtY_KeyUp(object sender, KeyEventArgs e)
        {
            txtX.Text = txtY.Text;
            
        }

        private void FormQR_Load(object sender, EventArgs e)
        {
            txtCodigo.Text = DevuelveIDNoRepetido(); //Devuelve ID de Producto
           
        }

        public void btnCambiarT_Click(object sender, EventArgs e)
        {
            if (txtX.Text != "" && txtY.Text != "")
            {
                int DatoTextbox = Convert.ToInt32(txtX.Text);
                if (DatoTextbox >= 100 && DatoTextbox <= 300)
                {
                    CambiarDimensiones();

                }
                else
                {
                    MessageBox.Show("Solo se permiten valores mayor o igual a 100 y menor o igual a 300 píxeles...", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtX.Text = "100";
                    txtY.Text = "100";
                    btnCambiarT_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Solo se permiten valores mayor o igual a 100 y menor o igual a 300 píxeles...", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtX.Text = "100";
                txtY.Text = "100";
                btnCambiarT_Click(sender, e);
            }
            
           
        }
        public string DevuelveIDNoRepetido()
        {
            string IDProducto;
            double Id;
            Random rnd = new Random();
            string rutaArchivoCompleta = PathA + "Inventario.xlsx";
            Id = rnd.Next(10000000, 20000001);
            IDProducto = "ID" + Id;
            if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe
            {
                SLDocument ArchivoExcel = new SLDocument(rutaArchivoCompleta);
                int iRow = 2;

                while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                {

                    if (IDProducto == ArchivoExcel.GetCellValueAsString(iRow, 1))
                    {
                        Id = rnd.Next(10000000, 20000001);
                        IDProducto = "ID" + Id;
                        iRow = 1;
                    }
                    iRow++;
                }

            }
           


            return IDProducto;
        }

        private void btnGenerarIDProducto_Click(object sender, EventArgs e)
        {
           txtCodigo.Text = DevuelveIDNoRepetido(); //Devuelve ID Producto no repetido en el Inventario
        }
        public void VerificarTextbox(KeyPressEventArgs e)   //Solo permite agregar números al textbox
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }
        private void txtX_KeyPress(object sender, KeyPressEventArgs e)//Verificar que solo se ingresen números
        {
            VerificarTextbox(e);
        }

        private void txtY_KeyPress(object sender, KeyPressEventArgs e) //Verificar que solo se ingresen números
        {
            VerificarTextbox(e);
        }

     
    }
}
