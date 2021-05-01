using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using System.Media;
using System.Globalization;
using System.IO;
using SpreadsheetLight;

namespace CajaRegistradoa
{
    public partial class FormPuntoVenta : Form, IForm
    {
        public List<int> valores_permitidos = new List<int>() { 8, 13, 37, 38, 39, 40, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 46 };
        private string PathA = @"C:\DataBaseSV\Archivos\"; //Directorio para Archivos
        private string Pathtxt = @"C:\DataBaseSV\StatusCamara.txt"; //Archivo de texto
        private bool SeInicioCamara, encontrado, encontradoItem;
        private int Fila, FilItem;
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        private double IdUsuario, TotalItems, TotalVendido;
        private string CodigoProduct;
        private long NumNotaVenta = 1;
        private const string CodigoTotalxDia = "ID11111111";
        public FormPuntoVenta(double iduser)
        {
            InitializeComponent();
            this.IdUsuario = iduser;
        }
        private bool BuscarFechaApertura(string rutaArchivo, string Fecha) //Metodo que devuelve verdadero si encontro una apertura agregada, busca por fecha
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
        private void FormPuntoVenta_Load(object sender, EventArgs e)
        {
            CrearDirectorios(); //Metodo que crea las carpetas: ControlVentas , Año, Mes, Solo los crea si no existen
            CargarNombreOperador(); //Cargo el nombre del operador de la CAJA 1
            string rutaArchivoCompleta = PathA + "AperturasDeCaja.xlsx";
            if (File.Exists(rutaArchivoCompleta))
            {
                if (!BuscarFechaApertura(rutaArchivoCompleta, DateTime.Now.ToShortDateString())) //Pregunto si existe la apertura de hoy, si no existe, lo niego para poder activar el formulario
                {
                    btnAperturaCaja_Click(sender, e);
                }
                encontrado = false;
            }
            else
            {
                btnAperturaCaja_Click(sender,e); 
            }
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cboxDevice.Items.Add(filterInfo.Name);
            cboxDevice.SelectedIndex = 0;
            IniciarScanner(); //Enciende la camara para capturar codigo QR
            btnOnScanner.Enabled = false; //Deshabilito el botón On Scanner
            
        }
        private void CrearDirectorios()  //Meotod que se encarga de crear las carpetas para guardar los tickets de venta
        {
            string CarpetaControlVentas = PathA + "ControlVentas";
            string CarpetaAnio = CarpetaControlVentas + "\\" + DateTime.Now.Year;
            string CarpetaMes = CarpetaAnio + "\\" + obtenerNombreMesNumero(DateTime.Now.Month);

            // DirectoryInfo Principal = Directory.CreateDirectory(RutaDirectoryPrincipal);
            if (!Directory.Exists(PathA)) ///Solo si no existen la carpeta con el año actual, entonces se crean
            {
                DirectoryInfo Ventas = Directory.CreateDirectory(CarpetaControlVentas);
                if (!Directory.Exists(CarpetaAnio)) ///Solo si no existen la carpeta con el Mes actual, entonces se crean
                {
                    DirectoryInfo Anio = Directory.CreateDirectory(CarpetaAnio);
                    if (!Directory.Exists(CarpetaMes)) ///Solo si no existen la carpeta con el Mes actual, entonces se crean
                    {
                        DirectoryInfo Mes = Directory.CreateDirectory(CarpetaMes);
                    }

                }
            }
            else
            {
                if (!Directory.Exists(CarpetaAnio)) ///Solo si no existen la carpeta con el Mes actual, entonces se crean
                {
                    DirectoryInfo Anio = Directory.CreateDirectory(CarpetaAnio);
                }
                if (!Directory.Exists(CarpetaMes)) ///Solo si no existen la carpeta con el Mes actual, entonces se crean
                {
                    DirectoryInfo Mes = Directory.CreateDirectory(CarpetaMes);
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
                        lblNombreOperador.Text = ArchivoExcel.GetCellValueAsString(iRow, 5) + " " + ArchivoExcel.GetCellValueAsString(iRow, 6);
                    }
                    iRow++;
                }


            }
            else
            {
                lblNombreOperador.Text = "Operador: -----------";
            }
        }

        private void btnOnScanner_Click(object sender, EventArgs e)
        {

            IniciarScanner();
            btnOnScanner.Enabled = false; //Deshabilito el botón On Scanner
            btnOffScanner.Enabled = true; //habilito el boton Off Scanner
            txtEfectivo.Focus();
        }

        private void btnOffScanner_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (captureDevice.IsRunning)
                captureDevice.Stop();
            pboxCamara.Image = Properties.Resources.Scanner;  //Regreso a la imagen anterior
            btnOnScanner.Enabled = true; //habilito el botón On Scanner
            btnOffScanner.Enabled = false; //Deshabilito el boton Off Scanner
            SeInicioCamara = false;
            GuardarEstadoCamara(SeInicioCamara); //Mando el estado de la Camara 
        }
        private void IniciarScanner()
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[cboxDevice.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();
            txtEfectivo.Focus();
            SeInicioCamara = true;
            GuardarEstadoCamara(SeInicioCamara); //Mando el estado de la Camara 
        }
        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pboxCamara.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (pboxCamara.Image != null)
                {
                    BarcodeReader barcodeReader = new BarcodeReader();
                    Result resultado = barcodeReader.Decode((Bitmap)pboxCamara.Image);

                    if (resultado != null)
                    {

                        AgregarProductoToListView(resultado.ToString()); //El resultado obtenido del QR lo mando al metodo que se encargará de agregar el producto a la lista de venta
                        CodigoProduct = resultado.ToString();
                        timer1.Stop();
                        if (captureDevice.IsRunning)
                            captureDevice.Stop();
                        pboxCamara.Image = Properties.Resources.Scanner;  //Regreso a la imagen anterior

                        btnOnScanner_Click(sender, e);
                        btnOffScanner.Enabled = true; //Habilito el boton Off Scanner

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Detalles: " + ex.Message + "\nVuelva a encender la cámara", "INFORME ESTADO DE CÁMARA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOffScanner_Click(sender,e);
            }
            
        }

        private bool BuscarIDProducto(string rutaArchivo, string codigo) //Metodo que devuelve verdadero si encontro el IDproducto en el archivo Excel Inventario
        {

            SLDocument ArchivoExcel = new SLDocument(rutaArchivo);
            int iRow = 2;

            while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
            {
                if (codigo == ArchivoExcel.GetCellValueAsString(iRow, 1)) //Recorro el archivo y pregunto si existe el IDProducto 
                {
                    encontrado = true;
                }
                iRow++;
            }
            return encontrado;
        }
        private void MostrarInventarioAListViewExistentes(string rutaArchivoCompleta, string codigo)
        {
            double precio;
            SLDocument ArchivoExcel = new SLDocument(rutaArchivoCompleta);
            int iRow = 2, cant;


            while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
            {
                if (codigo == ArchivoExcel.GetCellValueAsString(iRow, 1)) //Recorro el archivo y pregunto si existe el IDProducto 
                {
                    Fila = iRow;  //Obtengo la fila del producto que se va a extraer
                }
                iRow++;
            }
            for (int i = 0; i < lstViewVenta.Items.Count; i++) //Recorro la lista de productos vendidos y busco el producto que ya existe para obtener la posición de la fila 
            {
                if (codigo == lstViewVenta.Items[i].SubItems[0].Text)
                {
                    FilItem = i;
                    encontradoItem = true;
                }
            }
            if (encontradoItem) // Si existe el producto en la lista entonces actualizo la cantidad y el importe
            {
                cant = int.Parse(lstViewVenta.Items[FilItem].SubItems[1].Text);
                lstViewVenta.Items[FilItem].SubItems[1].Text = Convert.ToString(cant + 1);
                precio = ArchivoExcel.GetCellValueAsDouble(Fila, 4); //Obtengo el precio original
                lblImporte.Text = precio.ToString("C");
                lstViewVenta.Items[FilItem].SubItems[3].Text = (precio * (cant + 1)).ToString("C");
                encontradoItem = false;
            }
            else
            {
                //si no existe el producto entonces agrego uno producto nuevo
                //Capturando los valores de acuerdo a la posicion de la fila y los guardo en variables
                string Codigo = ArchivoExcel.GetCellValueAsString(Fila, 1);
                int Cantidad = 1;
                string Descripcion = ArchivoExcel.GetCellValueAsString(Fila, 3);
                double Precio = ArchivoExcel.GetCellValueAsDouble(Fila, 4);
                lblImporte.Text = Precio.ToString("C");

                //Muestro el Producto encontrado en el archivo Excel en la lista del Usuario
                ListViewItem fila = new ListViewItem(Codigo);
                fila.SubItems.Add(Cantidad.ToString());
                fila.SubItems.Add(Descripcion.ToString());
                precio = Convert.ToDouble(Precio.ToString());
                fila.SubItems.Add(precio.ToString("C"));
                lstViewVenta.Items.Add(fila);
            }
        }
        //Ejecuto las llamas a los Metodos de IForm

        public void DatosProducto(string codigop, int nuevacantidad, double importep)
        {
            ActualizarCantidadProducto(codigop, nuevacantidad, importep);
            CalcularTotalVendido(); //Vuelvo a calcular el importe de cada producto que esta en la lista
        }


        /// //************************************

        private void ActualizarCantidadProducto(string CodigoP, int NuevaCantidad, double ImporteP)
        {

            for (int i = 0; i < lstViewVenta.Items.Count; i++) //Recorro la lista de productos vendidos y busco el producto que ya existe para obtener la posición de la fila 
            {
                if (CodigoP == lstViewVenta.Items[i].SubItems[0].Text)
                {
                    FilItem = i;
                    encontradoItem = true;
                }
            }
            if (encontradoItem) // Si existe el producto en la lista entonces actualizo la cantidad y el importe
            {

                lstViewVenta.Items[FilItem].SubItems[1].Text = Convert.ToString(NuevaCantidad);

                lstViewVenta.Items[FilItem].SubItems[3].Text = (ImporteP * NuevaCantidad).ToString("C");
                lblImporte.Text = (ImporteP * NuevaCantidad).ToString("C");
                encontradoItem = false;
            }
            txtEfectivo.Focus();
        }
        private void CalcularTotalVendido() //Metodo que recorre la lista de productos scanneados y va sumando su importe
        {
            double sumar = 0;
            for (int i = 0; i < lstViewVenta.Items.Count; i++)
            {
                sumar += double.Parse(lstViewVenta.Items[i].SubItems[3].Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
            }
            if (sumar > 0)
            {
                lblTotalVenta.Text = sumar.ToString("C");
                lblTotalLetras.Text = Convert.ToDecimal(sumar).NumeroALetras() + " M.N.";
            }
            else
            {
                btnMasDUnProducto.Enabled = false;
                btnCancelarVenta.Enabled = false;
                lblImporte.Text = "$ 00.00";
                lblTotalVenta.Text = "$ 00.00";
                lblCambio.Text = "$ 00.00";
                lblTotalLetras.Text = "----------------------------------------------------";
            }

        }
        private void AgregarProductoToListView(string codigo) //Metodo que se encarga de llenar la lista de productos vendidos
        {
            string rutaArchivoCompleta = PathA + "Inventario.xlsx";
            if (File.Exists(rutaArchivoCompleta))
            {
                //El archivo existe, entonces busco el ID de producto en el inventario
                if (BuscarIDProducto(rutaArchivoCompleta, codigo)) 
                {
                    MostrarInventarioAListViewExistentes(rutaArchivoCompleta, codigo); //Muestro en el ListView lo que hay almacenado en el archivo Excel Inventario
                    CalcularTotalVendido();
                    playSimpleSound(); //Producir un sonido en tiempo de ejecución
                    
                    if (!btnMasDUnProducto.Enabled && !btnCancelarVenta.Enabled)  //Se activará el botón Agregar cantidad despues de Scannear el QR Producto
                    {
                        btnMasDUnProducto.Enabled = true;
                        btnCancelarVenta.Enabled = true;
                    }
                    encontrado = false;
                }
                else 
                {
                    MessageBox.Show("¡El código de producto NO existe en el inventario...!", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            else
            {
                MessageBox.Show("El archivo no existe... no se encontro la siguiente ubicación: " + rutaArchivoCompleta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.scannerbeep); //Recupero el audio desde los recursos del sistema
            simpleSound.Play();
        }

        private void txtEfectivo_KeyPress(object sender, KeyPressEventArgs e) //Interceptar la tecla pulsada
        {
            double totalApagar = double.Parse(lblTotalVenta.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
            TextBox textbox = (TextBox)sender; // Convierto el sender a TextBox
            solo_numeros(ref textbox, e); // Llamamos a nuestro método
            if (e.KeyChar == Convert.ToChar(13))
            {
                //Se pulso enter
                e.Handled = true;
                if (totalApagar != 0)
                {
                    DevolverCambio(sender);
                }
                else
                {
                    MessageBox.Show("No se han agregado productos...", "Registro de venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEfectivo.Focus();
                }

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
        private void DevolverCambio(object sender)
        {
            if (txtEfectivo.Text != "")
            {
                double efectivo = double.Parse(txtEfectivo.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US")); //Quitar el singo de pesos $
                double totalApagar = double.Parse(lblTotalVenta.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));

                if (efectivo >= totalApagar)
                {
                    double Cambio = efectivo - totalApagar;
                    lblCambio.Text = Cambio.ToString("C");
                    btnCerrarVenta.Focus();
                }
                else
                {
                    MessageBox.Show("El EFECTIVO debe ser mayor o igual al TOTAL A PAGAR", "Registro de venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtEfectivo.Focus();
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese una cantidad...", "Registro de venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtEfectivo.Focus();
            }


        }
        private void txtEfectivo_Leave(object sender, EventArgs e)
        {
            double precio;
            if (txtEfectivo.Text == "")
            {
                txtEfectivo.Text = "$ 0.00";
                txtEfectivo.ForeColor = Color.Silver;
            }
            else
            {
                precio = Convert.ToDouble(txtEfectivo.Text);
                txtEfectivo.Text = precio.ToString("C");
            }
        }

        private void txtEfectivo_Enter(object sender, EventArgs e)
        {
            if (txtEfectivo.Text != "")
            {
                txtEfectivo.Text = "";
                txtEfectivo.ForeColor = Color.Black;

            }
        }
        public long DevuelveNotaVentaNoRepetido() //Devuelve in ID de Nota venta que no existe en el control de ventas
        {
            string CarpetaAnio = PathA + "ControlVentas" + "\\" + DateTime.Now.Year;
            string CarpetaMes = CarpetaAnio + "\\" + obtenerNombreMesNumero(DateTime.Now.Month);
            string rutaArchivoCompleta = CarpetaMes + "\\" + DateTime.Now.DayOfWeek + "_" + DateTime.Now.Day + ".xlsx"; //Nombre del archivo Excel NombreDIA_NumeroDia.xlsx
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
                NumNotaVenta = dato + 1;
            }
            else
            {
                NumNotaVenta = 1;
            }


            return NumNotaVenta;
        }
        private void btnCerrarVenta_Click(object sender, EventArgs e) //metodo del control Guardar venta
        {
            long NoVenta = DevuelveNotaVentaNoRepetido();
            if (lblTotalVenta.Text != "$ 00.00")
            {
                DialogResult r = MessageBox.Show("¿Esta seguro de guardar la venta?", "Cerrar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {

                    AgregarProductosVendidos(NoVenta); //meotod que se encarga de agregar los productos vendidos en un archivo excel
                    MostrarTicket(NoVenta); //Meotodo en cargado de mostrar un ticket de venta
                    ActualizarInventario(); //Metodo que se encarga de actualizar el inventario, despues de una venta
                    lblImporte.Text = "$ 00.00";
                    lblTotalVenta.Text = "$ 00.00";
                    lblCambio.Text = "$ 00.00";
                    lblTotalLetras.Text = "----------------------------------------------------";
                    btnMasDUnProducto.Enabled = false;
                    btnCancelarVenta.Enabled = false;
                    lstViewVenta.Items.Clear();
                    txtEfectivo.Focus();

                }
            }
            else
            {
                MessageBox.Show("No hay productos agregados...", "Cerrar venta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtEfectivo.Focus();
            }
        }
       
        private void ActualizarInventario() //Meotodo que se encarga de restar los productos vendidos en el inventario existentes
        {
            string rutaArchivoInventarioExistentes = PathA + "Inventario.xlsx";
            string rutaArchivoInventarioAgotados = PathA + "InventarioAgotados.xlsx";
            try
            {
                
                int iRow = 1;
                double NItems,NumItems;
               
                for (int i = 0; i < lstViewVenta.Items.Count; i++) //Recorro la lista de productos vendidos
                {
                    SLDocument s2 = new SLDocument(rutaArchivoInventarioExistentes);
                    NItems = Convert.ToDouble(lstViewVenta.Items[i].SubItems[1].Text); //N° Items
                    while (!string.IsNullOrEmpty(s2.GetCellValueAsString(iRow, 1))) //Recorro el inventario del archivo Excel
                    {
                        if (lstViewVenta.Items[i].SubItems[0].Text == s2.GetCellValueAsString(iRow, 1)) //Recorro el archivo y pregunto si es igual el codigo de producto de listview con el IDProducto inventario 
                        {
                        Fila = iRow;  //Obtengo la fila a donde que se va a modificar
                        }
                        iRow++;
                    }
                    NumItems = s2.GetCellValueAsDouble(Fila, 2) - NItems;
                    if (NumItems > 0) //Pregunto si hay almenos 1 numItems de un articulo en inventario, entonces actualizo la cantidad
                    {
                        s2.SetCellValue(Fila, 2, NumItems); //Solo se actualiza el Num de Items, restando la cantidad actual - la cantidad vendida
                        s2.SaveAs(rutaArchivoInventarioExistentes);
                    }
                    else //Si ya no hay numItems de un articulo entonces lo quito del inventario y lo agrego al archivo Excel InventarioAgotados
                    {
                        //Eliminar producto de la lista de Existentes
                        QuitarproductoDeExistentes(lstViewVenta.Items[i].SubItems[0].Text, rutaArchivoInventarioExistentes);
                        //Agregar producto a la lista de productos agotados
                        CrearExcelInventarioAgotados CEIA = new CrearExcelInventarioAgotados(lstViewVenta.Items[i].SubItems[0].Text,NumItems, lstViewVenta.Items[i].SubItems[2].Text,rutaArchivoInventarioAgotados);
                        if (File.Exists(rutaArchivoInventarioAgotados))
                        {
                            CEIA.AddProductToExcelIA();
                        }
                        else
                        {
                            //Si no existe el archivo .xlsx entonces se crea por primera vez
                            CEIA.CrearExcelIA();
                        }
                    }
                    iRow = 1; //Inicializo contador de filas

                }
               
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private void QuitarproductoDeExistentes(string Codigo,string rutaArchivoCompleta) ///Metodo que se encarga de quitar el producto de inventario existentes
        {
            try
            {
                SLDocument s2 = new SLDocument(rutaArchivoCompleta);
                int iRow = 1;
                while (!string.IsNullOrEmpty(s2.GetCellValueAsString(iRow, 1)))
                {
                    if (Codigo == s2.GetCellValueAsString(iRow, 1)) //Recorro el archivo y pregunto si existe el IDProducto 
                    {
                        Fila = iRow;  //Obtengo la fila a donde que se va a modificar
                    }
                    iRow++;
                }
                s2.DeleteRow(Fila, 1);
                s2.SaveAs(rutaArchivoCompleta);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       private void AgregarProductosVendidos(long NotaVenta) //Metodo que se encarga de agregar los productos vendidos en un Archivo Excel NombreDia_NumeroDia.xlsx
        {
            
            string CarpetaAnio = PathA + "ControlVentas" + "\\" + DateTime.Now.Year;
            string CarpetaMes = CarpetaAnio + "\\" + obtenerNombreMesNumero(DateTime.Now.Month);
            string rutaArchivoCompleta = CarpetaMes + "\\" + DateTime.Now.DayOfWeek + "_" + DateTime.Now.Day + ".xlsx"; //Nombre del archivo Excel NombreDIA_NumeroDia.xlsx
            CrearExcelControlVenta CECV = new CrearExcelControlVenta(rutaArchivoCompleta, NotaVenta,lstViewVenta, DateTime.Now.ToShortDateString(), DateTime.Now.ToString("hh:mm"), lblNombreOperador.Text);
            if (File.Exists(rutaArchivoCompleta))
            {
                CECV.AddToExcelCV();
            }
            else
            {
                //Si no existe el archivo .xlsx entonces se crea por primera vez
                CECV.CrearExcelCV();
            }
        }
        private void ObtenerDatosTienda() //Metodo que se encarga de Obtener los datos de la tienda
        {
            string rutaArchivoCompleta = PathA + "InfoTienda.xlsx";

            if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe
            {
                SLDocument ArchivoExcel = new SLDocument(rutaArchivoCompleta);
                lblNombreTienda.Text = ArchivoExcel.GetCellValueAsString(2, 1);
                lblTelTienda.Text = ArchivoExcel.GetCellValueAsString(2, 5);

            }
            else
            {
                lblNombreTienda.Text = "---------------";
                lblTelTienda.Text = "-------------------";
            }
        }
        private void MostrarTicket(long NotaVenta) //Metodo que muestra el ticket de venta
        {
           
            ObtenerDatosTienda();
            FormTicket formT = new FormTicket(lblNombreTienda.Text, lblTelTienda.Text, lblNombreOperador.Text, lstViewVenta,txtEfectivo.Text,lblCambio.Text, NotaVenta); //Paso como parametro el objeto del control ListView con los productos agregados
            formT.Show(this);
        }
        private void btnBorrarProducto_Click(object sender, EventArgs e) //Quita un articulo seleccionado de la lista
        {
            if (lstViewVenta.SelectedItems.Count > 0)
            {
                var message = MessageBox.Show("¿Desea eliminar el producto seleccionado?","Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (message == DialogResult.Yes)
                {
                    for (int i = 0; i < lstViewVenta.Items.Count; i++)
                    {
                        if (lstViewVenta.Items[i].Selected)
                        {
                            lstViewVenta.Items[i].Remove();
                            i--;
                        }
                    }
                }
                CalcularTotalVendido(); //Vuelvo a calcular el importe de cada producto que esta en la lista
            }
            else
            {
                MessageBox.Show("Debes seleccionar un producto", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            txtEfectivo.Focus();
        }
        private bool BuscarCodigoTotalxDia(string rutaArchivo) //Metodo que devuelve verdadero si encontro el ID11111111 (CodigoTotalxDia)
        {
            try
            {

            SLDocument ArchivoExcel = new SLDocument(rutaArchivo);
            int iRow = 2;
            while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 2)))
            {
                if (CodigoTotalxDia == ArchivoExcel.GetCellValueAsString(iRow, 2)) //Recorro el archivo y pregunto si existe el IDProducto 
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

        private void btnAperturaCaja_Click(object sender, EventArgs e) //Metodo que se encarga de Abrir la caja, agregando una cantidad inicial
        {
            string rutaArchivoCompleta = PathA + "AperturasDeCaja.xlsx";
            if (File.Exists(rutaArchivoCompleta))
            {
                if (BuscarFechaApertura(rutaArchivoCompleta, DateTime.Now.ToShortDateString()))
                {
                    DialogResult r2 = MessageBox.Show("La apertura ya existe, ¿Desea actualizar el saldo inicial de caja?", "APERTURA DE CAJA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r2 == DialogResult.Yes)
                    {
                        FormApertura formAC = new FormApertura(lblNombreOperador.Text);
                        formAC.Show(this);
                    }
                }
                else
                {
                    FormApertura formAC = new FormApertura(lblNombreOperador.Text);
                    formAC.Show(this);
                }
            }
            else
            {
                FormApertura formAC2 = new FormApertura(lblNombreOperador.Text);
                formAC2.Show(this);
            }
                
             
        }

        private void btnCorteCaja_Click(object sender, EventArgs e)
        {
            string CarpetaAnio = PathA + "ControlVentas" + "\\" + DateTime.Now.Year;
            string CarpetaMes = CarpetaAnio + "\\" + obtenerNombreMesNumero(DateTime.Now.Month);
            string rutaArchivo = CarpetaMes + "\\" + DateTime.Now.DayOfWeek + "_" + DateTime.Now.Day + ".xlsx"; //Nombre del archivo Excel NombreDIA_NumeroDia.xlsx
           
            DialogResult r2 = MessageBox.Show("¿Esta seguro de continuar?", "CORTE DE CAJA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r2 == DialogResult.Yes)
            {
                if (BuscarCodigoTotalxDia(rutaArchivo)) //Pregunto si existe el CodigoTotalxDia
                {
                    MessageBox.Show("¡EL corte de caja ya existe!","CORTE DE CAJA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    encontrado = false;
                }
                else
                {
                    SumarTotalVendidoPorDia(rutaArchivo);
                    lstViewVenta.Items.Clear(); //Limpiamos el ListView
                    lblImporte.Text = "$ 00.00";
                    lblTotalVenta.Text = "$ 00.00";
                    lblCambio.Text = "$ 00.00";
                    lblTotalLetras.Text = "----------------------------------------------------";
                    txtEfectivo.Focus();
                    btnMasDUnProducto.Enabled = false;
                    btnCancelarVenta.Enabled = false;
                }
               
            }
        }
        private void SumarTotalVendidoPorDia(string rutaArchivoCompleta) //Metodo que se encarga de calcular el total vendido en un dia 
        {  
            if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe
            {
                try
                {
                    SLDocument s2 = new SLDocument(rutaArchivoCompleta);
                    int iRow = 2;
                    while (!string.IsNullOrEmpty(s2.GetCellValueAsString(iRow, 1)))
                    {
                        TotalItems += Convert.ToDouble(s2.GetCellValueAsString(iRow, 3));  //Acumula el total de articulos vendidos por dia
                        TotalVendido += s2.GetCellValueAsDouble(iRow, 6); //Acumula el total de importe ganado por dia
                        iRow++;
                    }
                    s2.SetCellValue(iRow, 2, CodigoTotalxDia); //codigo de total
                    s2.SetCellValue(iRow, 3, TotalItems); //Total Articulos
                    s2.SetCellValue(iRow, 4, "TOTAL ="); //Descripción
                    s2.SetCellValue(iRow, 6, TotalVendido ); //Total importe vendido
                    s2.SetCellValue(iRow, 7, DateTime.Now.ToShortDateString()); //Fecha de corte
                    s2.SetCellValue(iRow, 8, DateTime.Now.ToString("hh:mm")); //Hora de corte
                    s2.SetCellValue(iRow, 9, lblNombreOperador.Text); //Aquien realizo el corte
                    s2.SaveAs(rutaArchivoCompleta);
                    MessageBox.Show("¡Corte de caja cerrada con éxito!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnMasDUnProducto_Click(object sender, EventArgs e) //Control botón para agregar más de una cantidad de articulos
        {
            FormMasD1Producto formMas = new FormMasD1Producto(CodigoProduct)
            {
                contrato = this
            };
            formMas.Show(this);
        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Esta seguro de cancelar la venta?", "Cancelar venta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                lstViewVenta.Items.Clear(); //Limpiamos el ListView
                lblImporte.Text = "$ 00.00";
                lblTotalVenta.Text = "$ 00.00";
                lblCambio.Text = "$ 00.00";
                lblTotalLetras.Text = "----------------------------------------------------";
                txtEfectivo.Focus();
                btnMasDUnProducto.Enabled = false;
                btnCancelarVenta.Enabled = false;
            }
               
        }

        private void GuardarEstadoCamara(bool CamaraActiva) //Metodo que guarda el estado de la camara en un archivo de texto, para depues poder obtenerlo
        {

            if (File.Exists(Pathtxt))
            {
                try
                {
                    StreamWriter flujoSalida = File.CreateText(Pathtxt);
                    if (CamaraActiva)
                    {
                        flujoSalida.WriteLine("1\n- No borrar o cambiar el valor  1\n- NO ELIMINAR EL ARCHIVO!");
                    }
                    else
                    {
                        flujoSalida.WriteLine("0\n- No borrar o cambiar el valor  0\n- NO ELIMINAR EL ARCHIVO!");
                    }
                    flujoSalida.Dispose();
                    flujoSalida.Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show("Detalles: " + ex.Message + "\nVuelva a encender la cámara", "INFORME ESTADO DE CÁMARA", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                using (FileStream fs = File.Create(Pathtxt)) ///Si no existe el archivo se crea
                {
                    if (CamaraActiva)
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes("1\n- No borrar o cambiar el valor  1\n- NO ELIMINAR EL ARCHIVO!");
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                    else
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes("0\n- No borrar o cambiar el valor  1\n- NO ELIMINAR EL ARCHIVO!");
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }


                }
            }
        }

    }
}
