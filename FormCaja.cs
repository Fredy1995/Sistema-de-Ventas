using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaRegistradoa
{
    public partial class FormCaja : Form
    {
        public List<int> valores_permitidos = new List<int>() { 8, 13, 37, 38, 39, 40, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 46 };
        private string PathA = @"C:\DataBaseSV\Archivos\"; //Directorio para Archivos
        private double IdUsuario,precio,TotalVendido,cantidad;
        private long NumSalida;
        private int Fila;
        public FormCaja(double iduser)
        {
            InitializeComponent();
            this.IdUsuario = iduser;
        }

        private void FormCaja_Load(object sender, EventArgs e)
        {
            string rutaArchivoCompleta = PathA + "AperturasDeCaja.xlsx";
            txtDescripcion.Focus();
            CargarinformacionTienda();
            CargarNombreOperador(); //Cargo el nombre del operador
            CargarApertura(rutaArchivoCompleta); //metodo que se encarga de mostrar el saldo inicial
            SumarTotalVendidoPorDia(); //Metodo que se encarga de calcular el total vendido en un dia
            MostrarSalidasGastosListView(); //Metodo que se encarga de mostrar los gastos en la lista
            OperacionCaja(rutaArchivoCompleta); //Metodo que se encarga de restar los gastos de la lista de lo que hay en caja
            

        }
        private void OperacionCaja(string rutaArchivoCompleta) //Metodo que se encarga en llevar el control Total de caja
        {
            double TotalGastos = 0,EnCaja;
            double cantidad = double.Parse(lblSaldoInicial.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US")) + double.Parse(lblTotalVendido.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
            if (lstViewSalidas.Items.Count > 0) //Pregunto si hay almenos 1 gasto en la lista
            {
                for (int i = 0; i < lstViewSalidas.Items.Count; i++)
                {
                    TotalGastos += double.Parse(lstViewSalidas.Items[i].SubItems[1].Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
                }
                EnCaja = cantidad - TotalGastos;
                ActualizarTotalEnCaja(rutaArchivoCompleta, EnCaja); //Cantidad sobrante, despues de restar los gastos
            }
            else
            {
                ActualizarTotalEnCaja(rutaArchivoCompleta, cantidad);
            }
        }
        private void ActualizarTotalEnCaja(string rutaArchivoCompleta,double cantidad)
        {
            
            if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe
            {
                TotalEnCaja TEC = new TotalEnCaja(cantidad, DateTime.Now.ToShortDateString(), rutaArchivoCompleta);
                TEC.AddTotalCajaToExcel();
                MostrarTotalEnCaja(); //Metodo que solo muestra lo que hay en TotalEnCaja desde el archivo excel AperturasDeCaja.xlsx
            }
              
        }
       
        private void MostrarTotalEnCaja() //Metodo que se encarga de buscar en el archivo AperturasDeCaja, el Total que hay en Caja
        {
            string rutaArchivoCompleta = PathA + "AperturasDeCaja.xlsx";
            if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe
            {
                try
                {

                    SLDocument ArchivoExcel = new SLDocument(rutaArchivoCompleta);
                    int iRow = 1;
                    while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                    {
                        if (DateTime.Now.ToShortDateString() == ArchivoExcel.GetCellValueAsString(iRow, 3)) //Recorro el archivo y pregunto si existe la fecha en el archivo
                        {
                            lblTotalCaja.Text = ArchivoExcel.GetCellValueAsDouble(iRow, 6).ToString("C");
                        }
                        iRow++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void CargarApertura(string rutaArchivoCompleta) //Metodo que devuelve verdadero si encontro una apertura agregada, busca por fecha
        {
            
            if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe
            {
                try
                {

                    SLDocument ArchivoExcel = new SLDocument(rutaArchivoCompleta);
                    int iRow = 1;
                    while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                    {
                        if (DateTime.Now.ToShortDateString() == ArchivoExcel.GetCellValueAsString(iRow, 3)) //Recorro el archivo y pregunto si existe la fecha en el archivo
                        {
                            lblSaldoInicial.Text = ArchivoExcel.GetCellValueAsDouble(iRow, 2).ToString("C");
                        }
                        iRow++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }     
        }

        private void SumarTotalVendidoPorDia() //Metodo que se encarga de calcular el total vendido en un dia 
        {
            string CarpetaAnio = PathA + "ControlVentas" + "\\" + DateTime.Now.Year;
            string CarpetaMes = CarpetaAnio + "\\" + obtenerNombreMesNumero(DateTime.Now.Month);
            string rutaArchivoCompleta = CarpetaMes + "\\" + DateTime.Now.DayOfWeek + "_" + DateTime.Now.Day + ".xlsx"; //Nombre del archivo Excel NombreDIA_NumeroDia.xlsx
            if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe
            {
                try
                {
                    SLDocument s2 = new SLDocument(rutaArchivoCompleta);
                    int iRow = 2;
                    while (!string.IsNullOrEmpty(s2.GetCellValueAsString(iRow, 1)))
                    {

                        TotalVendido += s2.GetCellValueAsDouble(iRow, 6); //Acumula el total de importe ganado por dia
                        iRow++;
                    }
                    lblTotalVendido.Text = TotalVendido.ToString("C");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private string obtenerNombreMesNumero(int numeroMes) //Metodo que de vuelve el nombre del MES
        {
            try
            {
                DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                string nombreMes = formatoFecha.GetMonthName(numeroMes);
                return nombreMes;
            }
            catch
            {
                return "Desconocido";
            }
        }
        public void CargarinformacionTienda()
        {

            string rutaArchivoCompleta = PathA + "InfoTienda.xlsx";

            if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe
            {
                SLDocument ArchivoExcel = new SLDocument(rutaArchivoCompleta);
                int iRow = 2;
                while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                {
                    if (ArchivoExcel.GetCellValueAsString(iRow, 1) != "Ej: Mi tienda S.A DE C.V" && ArchivoExcel.GetCellValueAsString(iRow, 3) != "################" && ArchivoExcel.GetCellValueAsString(iRow, 5) != "(##) ##-##-##-##-##")
                    {
                        lblNombreEmpresa.Text = ArchivoExcel.GetCellValueAsString(iRow, 1);
                        lblNombreEmpresa.Visible = true;
                        lblDireccion.Text = "Dirección:  " + ArchivoExcel.GetCellValueAsString(iRow, 3);
                        lblDireccion.Visible = true;
                        lblTelefono.Text = "Tel: " + ArchivoExcel.GetCellValueAsString(iRow, 5);
                        lblTelefono.Visible = true;

                    }
                    else
                    {
                        lblNombreEmpresa.Visible = false;
                        lblDireccion.Visible = false;
                        lblTelefono.Visible = false;
                    }
                    iRow++;
                }
            }
        }

        private void CargarNombreOperador()
        {


            //Al entrar, inicializo los textbox con los datos existentes en el Excel
            string rutaArchivoCompleta = PathA + "Usuarios.xlsx";
            if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe
            {
                SLDocument ArchivoExcel = new SLDocument(rutaArchivoCompleta);
                int iRow = 2;
                while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                {
                    if (IdUsuario == ArchivoExcel.GetCellValueAsDouble(iRow, 1))
                    {
                        lblOperador.Text = ArchivoExcel.GetCellValueAsString(iRow, 5) + " " + ArchivoExcel.GetCellValueAsString(iRow, 6);
                    }
                    iRow++;
                }


            }
            else
            {
                lblOperador.Text = "----------------------";
            }
        }
        private void txtDescripcion_Enter(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "Agregar descripción...")
            {
                txtDescripcion.Text = "";
                txtDescripcion.ForeColor = Color.Black;
            }
        }
        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            if (txtDescripcion.Text == "")
            {
                txtDescripcion.Text = "Agregar descripción...";
                txtDescripcion.ForeColor = Color.Silver;
            }
        }

        private void txtCantidad_Enter(object sender, EventArgs e)
        {
            if (txtCantidad.Text != "")
            {
                txtCantidad.Text = "";
                txtCantidad.ForeColor = Color.Black;

            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "")
            {
                txtCantidad.Text = "$ 0.00";
                txtCantidad.ForeColor = Color.Silver;
            }
            else
            {
                precio = double.Parse(txtCantidad.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
                txtCantidad.Text = precio.ToString("C"); //Agrego el $
            }
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {
            string rutaArchivoCompleta = PathA + "AperturasDeCaja.xlsx";
            if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe
            {
                if ( double.Parse(txtCantidad.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US")) < double.Parse(lblTotalCaja.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US")))
                {
                    if(double.Parse(txtCantidad.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US")) > 0)
                    {
                       
                        AgregarSalida(); //Metodo que se encarga de agregar la salida de efectivo y guardarla en un archivo excel RegistroDEGastos.xlsx
                       
                        /*txtDescripcion.Text = "Agregar descripción...";
                        txtDescripcion.ForeColor = Color.Silver;
                        txtCantidad.Text = "$ 0.00";
                        txtCantidad.ForeColor = Color.Silver;
                        txtDescripcion.Focus();*/
                    }
                    else
                    {
                        MessageBox.Show("Por favor ingrese otra cantidad...", "CANTIDAD INVÁLIDA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                   
                }
                else
                {
                    MessageBox.Show("Lo sentimos..., no hay dinero disponible...", "DINERO INSUFICIENTE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Es necesario aperturar caja para poder continuar...", "APERTURA DE CAJA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtDescripcion.Text = "Agregar descripción...";
            txtDescripcion.ForeColor = Color.Silver;
            txtCantidad.Text = "$ 0.00";
            txtCantidad.ForeColor = Color.Silver;
            txtDescripcion.Focus();
        }
        public long DevuelveNoSalidaNoRepetido(string rutaArchivoCompleta) //Devuelve No. de Salida que no existe en RegistroDeGastos
        {
           
            long dato;

            if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe
            {
                SLDocument ArchivoExcel = new SLDocument(rutaArchivoCompleta);
                int iRow = 2;
                if(!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1))){
                    while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                    {
                        iRow++;
                    }
                    dato = long.Parse(ArchivoExcel.GetCellValueAsString(iRow - 1, 1));
                    NumSalida = dato + 1;
                }
                else
                {
                    NumSalida = 1;
                }
                
            }
            else //si no existe el archivo entonces devuelvo 00000001, como número inicial
            {
                NumSalida = 1;
            }
            return NumSalida;
        }
      
        private void MostrarSalidasGastosListView() //Metodo que se encarga de cargar los datos de Excel RegistroDeGastos a un control ListView 
        {
            string rutaArchivoCompleta = PathA + "RegistroDeGastos.xlsx";
            lstViewSalidas.Items.Clear();
            
            if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe el archivo RegistroDeGastos
            {
                SLDocument ArchivoExcel = new SLDocument(rutaArchivoCompleta);
                int iRow = 2;
                if (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                {
                    while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                    {
                        if (DateTime.Now.ToShortDateString() == ArchivoExcel.GetCellValueAsString(iRow, 4)) //Busca por fecha
                        {
                            //Capturando los valores
                            string NoSalida = ArchivoExcel.GetCellValueAsString(iRow, 1);
                            double Cantidad = ArchivoExcel.GetCellValueAsDouble(iRow, 2);
                            string Concepto = ArchivoExcel.GetCellValueAsString(iRow, 3);
                            string Fecha = ArchivoExcel.GetCellValueAsString(iRow, 4);
                            string Hora = ArchivoExcel.GetCellValueAsString(iRow, 5);
                            string Operador = ArchivoExcel.GetCellValueAsString(iRow, 6);

                            ListViewItem fila = new ListViewItem(NoSalida);
                            cantidad = Convert.ToDouble(Cantidad.ToString());
                            fila.SubItems.Add(cantidad.ToString("C"));
                            fila.SubItems.Add(Concepto);
                            fila.SubItems.Add(Fecha);
                            fila.SubItems.Add(Hora);
                            fila.SubItems.Add(Operador);
                            lstViewSalidas.Items.Add(fila); //Solo se agregán a la lista los de la fecha actual
                        }
                            
                        iRow++;

                    }
                    //Como si hay datos en el archivo Excel RegistroDeGastos entonces Habilito los controles
                
                    btnQuitar.Enabled = true;
                }
                else
                {
                    //Como No hay datos en el archivo Excel RegistroDeGastos entonces Deshabilito los controles
                    btnQuitar.Enabled = false;
                   
                }

            }
        }
        public void DeleteProductoToExcel(string NoSalida)
        {
            string rutaArchivoCompleta = PathA + "RegistroDeGastos.xlsx";
            try
            {
                SLDocument s2 = new SLDocument(rutaArchivoCompleta);
                int iRow = 1;
                while (!string.IsNullOrEmpty(s2.GetCellValueAsString(iRow, 1)))
                {
                    if (NoSalida == s2.GetCellValueAsString(iRow, 1)) //Recorro el archivo y pregunto si existe el Numero de Salida 
                    {
                        Fila = iRow;  //Obtengo la fila a donde que se va a modificar
                    }
                    iRow++;
                }
                s2.DeleteRow(Fila, 1);

                s2.SaveAs(rutaArchivoCompleta);
                MessageBox.Show("¡Salida de efectivo eliminada con éxito!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            string rutaArchivoCompleta = PathA + "AperturasDeCaja.xlsx";
            if (lstViewSalidas.SelectedItems.Count > 0)
            {

                var message = MessageBox.Show("¿Desea eliminar la salida seleccionada?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (message == DialogResult.Yes)
                {
                    for (int i = 0; i < lstViewSalidas.Items.Count; i++)
                    {
                        if (lstViewSalidas.Items[i].Selected)
                        {
                            DeleteProductoToExcel(lstViewSalidas.Items[i].SubItems[0].Text);
                            lstViewSalidas.Items[i].Remove();
                            i--;
                        }
                    }
                }
               
                OperacionCaja(rutaArchivoCompleta); //Metodo que se encarga de restar los gastos de la lista de lo que hay en caja
            }
            else
            {
                MessageBox.Show("Debes seleccionar una salida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            txtCantidad.Focus();
        }

        private void AgregarSalida()
        {
           
            string rutaArchivoCompleta = PathA + "RegistroDeGastos.xlsx";
            string rutaArchivoCompleta2 = PathA + "AperturasDeCaja.xlsx";
            long NoSalida = DevuelveNoSalidaNoRepetido(rutaArchivoCompleta);

            if ( txtDescripcion.Text != "Agregar descripción..." && txtDescripcion.Text != "" && txtCantidad.Text != "" && txtCantidad.Text != "$ 0.00")
            {
                double Cantidad = double.Parse(txtCantidad.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US")); //Quitar el singo de pesos $
                double NuevaCantidad = double.Parse(lblTotalCaja.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US")) - Cantidad;
                CrearExcelSalidasEfectivo CESE = new CrearExcelSalidasEfectivo(NoSalida,Cantidad,txtDescripcion.Text, DateTime.Now.ToShortDateString(), DateTime.Now.ToString("hh:mm"),lblOperador.Text,rutaArchivoCompleta);
                if (File.Exists(rutaArchivoCompleta))
                {
                   
                   CESE.AddProductToExcel();
                    MostrarSalidasGastosListView(); //Muestro en el ListView lo que hay almacenado en el archivo Excel RegistroDeGastos
                }
                else
                {
                    //Si no existe el archivo entonces se crea por primera vez
                    CESE.CrearExcelSE();
                    MostrarSalidasGastosListView();  //Muestro en el ListView lo que hay almacenado en el archivo Excel Inventario
                }
                ActualizarTotalEnCaja(rutaArchivoCompleta2, NuevaCantidad);
            }
            else
            {
                MessageBox.Show("¡Es necesario llenar todos los campos!", "CAMPOS VACÍOS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textbox = (TextBox)sender; // Convierto el sender a TextBox
            solo_numeros(ref textbox, e); // Llamamos a nuestro método
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
    }
}
