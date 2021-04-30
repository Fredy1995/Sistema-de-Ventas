using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaRegistradoa
{
    public partial class FormMasD1Producto : Form
    {

        public IForm contrato { get; set; }
        public List<int> valores_permitidos = new List<int>() { 8, 13, 37, 38, 39, 40, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 46 };
        private string PathA = @"C:\DataBaseSV\Archivos\"; //Directorio para Archivos
        private string Codigo;
        private int Fila;
        public FormMasD1Producto(string Codigo)
        {
            InitializeComponent();
            this.Codigo = Codigo;
        }

    
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtDescripcionProducto.Text = "";
            txtImporte.Text = "";
            txtCantidad.Text = "";
            this.Close();
        }
      
     /*  public void VerificarTextbox(KeyPressEventArgs e)   //Solo permite agregar números al textbox
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
        }*/

        /*private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerificarTextbox(e);
        }*/

    

        private void FormMasD1Producto_Load(object sender, EventArgs e)
        {
       
            MostrarDatosProducto();
            txtCantidad.Focus();
        }

        private void MostrarDatosProducto()
        {
            string rutaArchivoCompleta = PathA + "Inventario.xlsx";
            txtCodigo.Text = Codigo;

            SLDocument ArchivoExcel = new SLDocument(rutaArchivoCompleta);
            int iRow = 2;


            while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
            {
                if (Codigo == ArchivoExcel.GetCellValueAsString(iRow, 1)) //Recorro el archivo y pregunto si existe el IDProducto 
                {
                    Fila = iRow;  //Obtengo la fila del producto que se va a extraer
                }
                iRow++;
            }
            txtDescripcionProducto.Text = ArchivoExcel.GetCellValueAsString(Fila, 3);
            double precio = ArchivoExcel.GetCellValueAsDouble(Fila, 4);
            txtImporte.Text = precio.ToString("C");
            if (txtDescripcionProducto.Text != "")
            {
                btnActualizarCantidad.Enabled = true;
            }
        }

        private void btnActualizarCantidad_Click(object sender, EventArgs e)
        {
            if(txtCantidad.Text != "")
            {
                double importe = double.Parse(txtImporte.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
                contrato.DatosProducto(txtCodigo.Text, int.Parse(txtCantidad.Text), importe);
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe agregar una cantidad", "Actualizar cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
         
        }
        public void solo_numeros(ref TextBox textbox, KeyPressEventArgs e)
        {
            char signo_decimal = (char)46; //Si pulsan el punto .

            if (char.IsNumber(e.KeyChar) | valores_permitidos.Contains(e.KeyChar) |
                e.KeyChar == (char)Keys.Escape | e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false; // No hacemos nada y dejamos que el sistema controle la pulsación de tecla
                return;
            }
            else if (e.KeyChar == signo_decimal)
            {
                //Si no hay caracteres, o si ya hay un punto, no dejaremos poner el punto(.)
                if (textbox.Text.Length == 0 | textbox.Text.LastIndexOf(signo_decimal) >= 0)
                {
                    e.Handled = true; // Interceptamos la pulsación para que no permitirla.
                }
                else //Si hay caracteres continuamos las comprobaciones
                {
                    //Cambiamos la pulsación al separador decimal definido por el sistema 
                    e.KeyChar = Convert.ToChar(System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator);
                    e.Handled = false; // No hacemos nada y dejamos que el sistema controle la pulsación de tecla
                }
                return;
            }
            else if (e.KeyChar == (char)13) // Si es un enter
            {
                e.Handled = true; //Interceptamos la pulsación para que no la permita.
                SendKeys.Send("{TAB}"); //Pulsamos la tecla Tabulador por código
            }
            else //Para el resto de las teclas
            {
                e.Handled = true; // Interceptamos la pulsación para que no tenga lugar
            }
        }
        private void txtCantidad_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            TextBox textbox = (TextBox)sender; // Convierto el sender a TextBox
            solo_numeros(ref textbox, e); // Llamamos a nuestro método
            if (e.KeyChar == Convert.ToChar(13))
            {
                //Se pulso enter
                e.Handled = true;
                btnActualizarCantidad.Focus();

            }
        }
    }
}
