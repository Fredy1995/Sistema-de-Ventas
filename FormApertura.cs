using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaRegistradoa
{
    public partial class FormApertura : Form
    {
        public List<int> valores_permitidos = new List<int>() { 8, 13, 37, 38, 39, 40, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 46 };
        private string PathA = @"C:\DataBaseSV\Archivos\"; //Directorio para Archivos
        private string NombreOperador;
        private long NumApertura = 1;
        private bool encontrado;
        public FormApertura(string NombreOperador)
        {
            InitializeComponent();
            this.NombreOperador = NombreOperador;
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
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textbox = (TextBox)sender; // Convierto el sender a TextBox
            solo_numeros(ref textbox, e); // Llamamos a nuestro método
            if (e.KeyChar == Convert.ToChar(13))
            {
                //Se pulso enter
                e.Handled = true;
                btnAperturar.Focus();

            }
        }
        public void playExclamation() //Sonido de Exclamation
        {
            SystemSounds.Exclamation.Play();
        }
        private void btnAperturar_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                APerturarCaja();
                lblMensaje.ForeColor = Color.Teal;
                this.Close();
            }
            else
            {
                playExclamation();
                lblMensaje.ForeColor = Color.Red;
                txtCantidad.Focus();
            }
        }
        private void APerturarCaja() //Metodo que se encarga de Agregar la apertura de caja, agregar cantidad inicial al entrar a registro de venta
        {
            long NoApertura = DevuelveNoAperturaNoRepetido();
            string rutaArchivoCompleta = PathA + "AperturasDeCaja.xlsx";
            CrearExcelAperturaCaja CEAC = new CrearExcelAperturaCaja(NoApertura,Convert.ToDouble(txtCantidad.Text),DateTime.Now.ToShortDateString(), DateTime.Now.ToString("hh:mm"),NombreOperador,rutaArchivoCompleta);
            if (File.Exists(rutaArchivoCompleta))
            {
                if(BuscarFechaApertura(rutaArchivoCompleta, DateTime.Now.ToShortDateString()))
                {
                    CEAC.UpdateAperturaExcel(); //Si Existe una apertura agregada con la misma fecha, entonces, solo actualizo la cantidad, hora y operador
                    encontrado = false;
                }
                else
                {
                    CEAC.AddAperturaToExcel();
                }
              
            }
            else
            {
                //Si no existe el archivo .xlsx entonces se crea por primera vez
                CEAC.CrearExcelAC();
            }
        }
        private bool BuscarFechaApertura(string rutaArchivo,string Fecha) //Metodo que devuelve verdadero si encontro una apertura agregada, busca por fecha
        {
            try
            {

                SLDocument ArchivoExcel = new SLDocument(rutaArchivo);
                int iRow = 1;
                while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                {
                    if (Fecha == ArchivoExcel.GetCellValueAsString(iRow, 3)) //Recorro el archivo y pregunto si existe la fecha en el archivo
                    {
                        encontrado = true;
                    }
                    iRow++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return encontrado;
        }
        public long DevuelveNoAperturaNoRepetido() //Devuelve No. de apertura que no existe en AperturasDeCaja
        {
            string rutaArchivoCompleta = PathA + "AperturasDeCaja.xlsx";
            long dato;

            if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe
            {
                SLDocument ArchivoExcel = new SLDocument(rutaArchivoCompleta);
                int iRow = 2;

                while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                {
                    iRow++;
                }
                dato = long.Parse(ArchivoExcel.GetCellValueAsString(iRow - 1, 1));
                NumApertura = dato + 1;
            }
            else //si no existe el archivo entonces devuelvo 00000001, como número inicial
            {
                NumApertura = 1;
            }


            return NumApertura;
        }
        private void FormApertura_Load(object sender, EventArgs e)
        {
            txtCantidad.Focus();
        }
    }
}
