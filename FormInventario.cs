using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpreadsheetLight;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using System.Media;
using System.Globalization;

namespace CajaRegistradoa
{
    public partial class FormInventario : Form
    {
        /// <summary> Teclas permitidas en el TextBox Precio Unitario de cada producto
        ///(char)46 pulsan .
        ///(char)8 pulsan Borrar
        ///(char)13 pulsan enter
        ///(char)37 pulsan Izquierda
        ///(char)38 pulsan Arriba
        ///(char)39 pulsan Derecha
        ///(char)40 pulsan Abajo
        ///(char)48 - 57  pulsan Los números del 0 al 9
        /// </summary>
        public List<int> valores_permitidos = new List<int>() { 8, 13, 37, 38, 39, 40, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 46 };
        private string PathA = @"C:\DataBaseSV\Archivos\"; //Directorio para Archivos
        private string Pathtxt = @"C:\DataBaseSV\StatusCamara.txt"; //Archivo de texto
        private int Fila;
        private bool SeInicioCamara,encontrado;
        private double precio;
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        public FormInventario()
        {
            InitializeComponent();
        }

        private void FormInventario_Load(object sender, EventArgs e)
        {
            CargarinformacionTienda();
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cboxDevice.Items.Add(filterInfo.Name);
            cboxDevice.SelectedIndex = 0;
            IniciarScanner(); //Enciende la camara para capturar codigo QR
            btnOnScanner.Enabled = false; //Deshabilito el botón On Scanner
            MostrarInventarioAListViewExistentes(); //Cargo la informacion de productos existentes
            MostrarInventarioListViewAgotados(); //Carga la información de productos agotados
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

        private void txtDescProductoAgragar_Enter(object sender, EventArgs e)
        {
            if (txtDescProductoAgragar.Text == "Agregar descripción...")
            {
                txtDescProductoAgragar.Text = "";
                txtDescProductoAgragar.ForeColor = Color.Black;
            }
        }

        private void txtDescProductoAgragar_Leave(object sender, EventArgs e)
        {
            if (txtDescProductoAgragar.Text == "")
            {
                txtDescProductoAgragar.Text = "Agregar descripción...";
                txtDescProductoAgragar.ForeColor = Color.Silver;
            }
        }

        private void txtNumItemsAgregar_Enter(object sender, EventArgs e)
        {
            if (txtNumItemsAgregar.Text != "")
            {
                txtNumItemsAgregar.Text = "";
                txtNumItemsAgregar.ForeColor = Color.Black;
            }
        }

        private void txtNumItemsAgregar_Leave(object sender, EventArgs e)
        {
            if (txtNumItemsAgregar.Text == "")
            {
                txtNumItemsAgregar.Text = "00";
                txtNumItemsAgregar.ForeColor = Color.Silver;
            }
           
        }

        private void txtPrecioUnitarioAgregar_Enter(object sender, EventArgs e)
        {
            if (txtPrecioUnitarioAgregar.Text != "")
            {
                txtPrecioUnitarioAgregar.Text = "";
                txtPrecioUnitarioAgregar.ForeColor = Color.Black;
               
            }
        }

        private void txtPrecioUnitarioAgregar_Leave(object sender, EventArgs e)
        {
            if (txtPrecioUnitarioAgregar.Text == "")
            {
                txtPrecioUnitarioAgregar.Text = "$ 0.00";
                txtPrecioUnitarioAgregar.ForeColor = Color.Silver;
            }
            else
            {  
                precio = double.Parse(txtPrecioUnitarioAgregar.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
                txtPrecioUnitarioAgregar.Text = precio.ToString("C"); //Agrego el $
            }
        }

        private void txtDescProductoActualizar_Enter(object sender, EventArgs e)
        {
            if (txtDescProductoActualizar.Text != "")
            {
                txtDescProductoActualizar.Text = "";
                txtDescProductoActualizar.ForeColor = Color.Black;
            }
        }

        private void txtDescProductoActualizar_Leave(object sender, EventArgs e)
        {
            if (txtDescProductoActualizar.Text == "")
            {
                txtDescProductoActualizar.Text = "Agregar descripción...";
                txtDescProductoActualizar.ForeColor = Color.Silver;
            }
        }

        private void txtNumItemsActualizar_Enter(object sender, EventArgs e)
        {
            if (txtNumItemsActualizar.Text != "")
            {
                txtNumItemsActualizar.Text = "";
                txtNumItemsActualizar.ForeColor = Color.Black;
            }
        }

        private void txtNumItemsActualizar_Leave(object sender, EventArgs e)
        {
            if (txtNumItemsActualizar.Text == "")
            {
                txtNumItemsActualizar.Text = "00";
                txtNumItemsActualizar.ForeColor = Color.Silver;
            }
        }

        private void txtPrecioUnitarioActualizar_Enter(object sender, EventArgs e)
        {
            if (txtPrecioUnitarioActualizar.Text != "")
            {
                txtPrecioUnitarioActualizar.Text = "";
                txtPrecioUnitarioActualizar.ForeColor = Color.Black;
            }
        }

        private void txtPrecioUnitarioActualizar_Leave(object sender, EventArgs e)
        {
            if (txtPrecioUnitarioActualizar.Text == "")
            {
                txtPrecioUnitarioActualizar.Text = "$ 0.00";
                txtPrecioUnitarioActualizar.ForeColor = Color.Silver;
            }
            else
            {
                precio = double.Parse(txtPrecioUnitarioActualizar.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
                txtPrecioUnitarioActualizar.Text = precio.ToString("C");
            }
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

        private void txtNumItemsAgregar_KeyPress(object sender, KeyPressEventArgs e) //Solo introducir números
        {
            VerificarTextbox(e);
        }

        private void txtPrecioUnitarioAgregar_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textbox = (TextBox)sender; // Convierto el sender a TextBox
            solo_numeros(ref textbox, e); // Llamamos a nuestro método
        }

        private void txtNumItemsActualizar_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerificarTextbox(e);
        }

        private void txtPrecioUnitarioActualizar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnOnScanner_Click(object sender, EventArgs e)
        {
            txtCodigoAgregar.Text = "";
            txtNumItemsAgregar.Text = "00";
            txtPrecioUnitarioAgregar.Text = "$ 0.00";
            IniciarScanner();
            btnOnScanner.Enabled = false; //Deshabilito el botón On Scanner
            btnOffScanner.Enabled = true; //habilito el boton Off Scanner
            txtDescProductoAgragar.Focus();
        }
        private void IniciarScanner()
        {
            captureDevice = new VideoCaptureDevice(filterInfoCollection[cboxDevice.SelectedIndex].MonikerString);
            captureDevice.NewFrame += CaptureDevice_NewFrame;
            captureDevice.Start();
            timer1.Start();
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
                        txtCodigoAgregar.Text = resultado.ToString();
                        playSimpleSound(); //Producir un sonido en tiempo de ejecución
                        timer1.Stop();
                        if (captureDevice.IsRunning)
                            captureDevice.Stop();
                        pboxCamara.Image = Properties.Resources.Scanner;  //Regreso a la imagen anterior
                        btnOnScanner.Enabled = true; //habilito el botón On Scanner
                        btnOffScanner.Enabled = false; //Deshabilito el boton Off Scanner
                        SeInicioCamara = false;
                        GuardarEstadoCamara(SeInicioCamara); //Mando el estado de la Camara
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Detalles: " + ex.Message + "\nVuelva a encender la cámara", "INFORME ESTADO DE CÁMARA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOffScanner_Click(sender, e);
            }
           
        }
        private void playSimpleSound()
        {
            SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.scannerbeep); //Recupero el audio desde los recursos del sistema
            simpleSound.Play();
        }
        private void btnOffScanner_Click(object sender, EventArgs e)
        {
            timer1.Stop(); //Aqui no se si quitarlo o dejarlo asi
            if (captureDevice.IsRunning)
                captureDevice.Stop();
                pboxCamara.Image = Properties.Resources.Scanner;  //Regreso a la imagen anterior
                btnOnScanner.Enabled = true; //habilito el botón On Scanner
                btnOffScanner.Enabled = false; //Deshabilito el boton Off Scanner
                SeInicioCamara = false;
                GuardarEstadoCamara(SeInicioCamara); //Mando el estado de la Camara 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            btnOnScanner.Enabled = false; //Deshabilito el botón On Scanner
            btnOffScanner.Enabled = true; //habilito el boton Off Scanner
            AgregarAInventario(); //Metodo para agregar los datos del producto al inventario Excel
            txtCodigoAgregar.Text = "";
            txtDescProductoAgragar.Text = "Agregar descripción...";
            txtDescProductoAgragar.ForeColor = Color.Silver;
            txtNumItemsAgregar.Text = "00";
            txtNumItemsAgregar.ForeColor = Color.Silver;
            txtPrecioUnitarioAgregar.Text = "$ 0.00";
            txtPrecioUnitarioAgregar.ForeColor = Color.Silver;
            txtDescProductoAgragar.Focus();
            IniciarScanner();
        }
        
        private void MostrarInventarioListViewAgotados()  //Metodo que se encarga de cargar los datos de Excel InventarioAgotados a un control ListView 
        {
            lstViewAgotados.Items.Clear();
            string rutaArchivoInventarioAgotados = PathA + "InventarioAgotados.xlsx";
            if (File.Exists(rutaArchivoInventarioAgotados)) //Pregrunto si el archivo existe
            {
                SLDocument ArchivoExcelAgotados = new SLDocument(rutaArchivoInventarioAgotados);
                int iRow = 2;
                if (!string.IsNullOrEmpty(ArchivoExcelAgotados.GetCellValueAsString(iRow, 1)))
                {
                    while (!string.IsNullOrEmpty(ArchivoExcelAgotados.GetCellValueAsString(iRow, 1)))
                    {

                        //Capturando los valores
                        string Codigo = ArchivoExcelAgotados.GetCellValueAsString(iRow, 1);
                        double NumItems = ArchivoExcelAgotados.GetCellValueAsDouble(iRow, 2);
                        string Descripcion = ArchivoExcelAgotados.GetCellValueAsString(iRow, 3);

                        ListViewItem fila = new ListViewItem(Codigo);
                        fila.SubItems.Add(NumItems.ToString());
                        fila.SubItems.Add(Descripcion.ToString());
                        lstViewAgotados.Items.Add(fila);
                        iRow++;

                    }
                }
            }
        }
        private void MostrarInventarioAListViewExistentes() //Metodo que se encarga de cargar los datos de Excel Inventario a un control ListView 
        {
            lstViewExistentes.Items.Clear();
           
            string rutaArchivoCompleta = PathA + "Inventario.xlsx";
            if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe
            {
                SLDocument ArchivoExcel = new SLDocument(rutaArchivoCompleta);
                int iRow = 2;
                if(!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                {
                while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                {

                    //Capturando los valores
                    string Codigo = ArchivoExcel.GetCellValueAsString(iRow, 1);
                    double NumItems = ArchivoExcel.GetCellValueAsDouble(iRow, 2);
                    string Descripcion = ArchivoExcel.GetCellValueAsString(iRow, 3);
                    double Precio = ArchivoExcel.GetCellValueAsDouble(iRow, 4);
                    ListViewItem fila = new ListViewItem(Codigo);
                    fila.SubItems.Add(NumItems.ToString());
                    fila.SubItems.Add(Descripcion.ToString());
                    precio = Convert.ToDouble(Precio.ToString());
                    fila.SubItems.Add(precio.ToString("C"));
                    lstViewExistentes.Items.Add(fila);
                    iRow++;
                  
                }
                    //Como si hay datos en el archivo Excel Inventario entonces Habilito los controles
                    btnActualizar.Enabled = true;
                    btnBorrar.Enabled = true;
                }
                else
                {
                    //Como No hay datos en el archivo Excel Inventario entonces Deshabilito los controles
                    btnActualizar.Enabled = false;
                    btnBorrar.Enabled = false;
                }

            }
        }
        
        private bool BuscarIDProducto(string rutaArchivo) //Metodo que devuelve verdadero si encontro el IDproducto en el archivo Excel Inventario
        {
            
            SLDocument ArchivoExcel = new SLDocument(rutaArchivo);
            int iRow = 2;
            while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
            {
                if (txtCodigoAgregar.Text == ArchivoExcel.GetCellValueAsString(iRow, 1)) //Recorro el archivo y pregunto si existe el IDProducto 
                {
                    encontrado = true;
                }
                iRow++;
            }
            return encontrado;
        }
        private void QuitarproductoDeAgotados(string Codigo, string rutaArchivoCompleta) ///Metodo que se encarga de quitar el producto de inventario agotados
        {
            if (File.Exists(rutaArchivoCompleta))//Pregunto si existe el archivo InventarioAgotados.xlsx, de lo contrario, no pasa nada
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
                            encontrado = true;
                        }
                        iRow++;
                    }
                    if (encontrado) //Si encontrado es verdadero entonces guardo los cambios, de lo contrario no pasa nada
                    {
                        s2.DeleteRow(Fila, 1);
                        s2.SaveAs(rutaArchivoCompleta);
                    }
                    encontrado = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
          
        }
        private void AgregarAInventario()//Metodo para agregar los datos del producto al archivo Excel
        {
            string rutaArchivoCompleta = PathA + "Inventario.xlsx";
            string rutaArchivoInventarioAgotados = PathA + "InventarioAgotados.xlsx";
            
            if (txtCodigoAgregar.Text != "" && txtNumItemsAgregar.Text != "" && txtNumItemsAgregar.Text != "00" && txtDescProductoAgragar.Text != "Agregar descripción..." && txtDescProductoAgragar.Text !="" && txtPrecioUnitarioAgregar.Text != "" && txtPrecioUnitarioAgregar.Text != "$ 0.00")
            {
                double precio = double.Parse(txtPrecioUnitarioAgregar.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US")); //Quitar el singo de pesos $
                CrearExcelInventario CEI = new CrearExcelInventario(txtCodigoAgregar.Text, Convert.ToDouble(txtNumItemsAgregar.Text), txtDescProductoAgragar.Text, precio, rutaArchivoCompleta);
                if (File.Exists(rutaArchivoCompleta))
                {
                    //El archivo existe, entonces agrego el nuevo producto al archivo Excel
                    if (!BuscarIDProducto(rutaArchivoCompleta)) //Si no se encontro el IDProducto entonces lo convierto a verdadero para agregarlo al Inventario
                    {
                        CEI.AddProductToExcel();
                        MostrarInventarioAListViewExistentes(); //Muestro en el ListView lo que hay almacenado en el archivo Excel Inventario
                    }
                    else //Si el IDProducto existe en el inventario entonces mando un msj para indicar al usuario que el Id ya existe
                    {
                        MessageBox.Show("¡El código de producto ya existe en el inventario actual!", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                   
                }
                else
                {
                    //Si no existe el archivo Inventario.xlsx entonces se crea por primera vez
                    CEI.CrearExcelI();
                    MostrarInventarioAListViewExistentes(); //Muestro en el ListView lo que hay almacenado en el archivo Excel Inventario
                }
                QuitarproductoDeAgotados(txtCodigoAgregar.Text, rutaArchivoInventarioAgotados); ///Metodo que se encarga de quitar el producto de inventario agotados
                MostrarInventarioListViewAgotados(); //Carga la información de productos agotados
            }
            else
            {
                MessageBox.Show("¡Es necesario llenar todos los campos!", "Campos vacios", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lstViewExistentes_MouseDoubleClick(object sender, MouseEventArgs e)  //Selecciona los elementos de la lista y los agrega a los textboxs
        {
            ListViewItem item = lstViewExistentes.GetItemAt(e.X, e.Y);

            if (item != null)
            {
                //Acción Actualizar
                txtCodigoActualizar.Text = item.Text;
                txtDescProductoActualizar.Text = item.SubItems[2].Text;
                txtNumItemsActualizar.Text = item.SubItems[1].Text;
                txtPrecioUnitarioActualizar.Text = item.SubItems[3].Text;
                //Accción Borrar
                txtCodigoBorrar.Text = item.Text;
                txtDescProductoBorrar.Text = item.SubItems[2].Text;
               
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarProducto();
            txtCodigoActualizar.Text = "";
            txtDescProductoActualizar.Text = "Agregar descripción...";
            txtDescProductoActualizar.ForeColor = Color.Silver;
            txtNumItemsActualizar.Text = "00";
            txtNumItemsActualizar.ForeColor = Color.Silver;
            txtPrecioUnitarioActualizar.Text = "$ 0.00";
            txtPrecioUnitarioActualizar.ForeColor = Color.Silver;
            txtCodigoBorrar.Text = "";
            txtDescProductoBorrar.Text = "";
        }
        private void ActualizarProducto()
        {
            string rutaArchivoCompleta = PathA + "Inventario.xlsx";
            
            if (txtCodigoActualizar.Text != "" && txtNumItemsActualizar.Text != "00" && txtNumItemsActualizar.Text != "" && txtDescProductoActualizar.Text != "Agregar descripción..." && txtDescProductoActualizar.Text != "" && txtPrecioUnitarioActualizar.Text != "$ 0.00" && txtPrecioUnitarioActualizar.Text != "")
            {
                double precio = double.Parse(txtPrecioUnitarioActualizar.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
                CrearExcelInventario CEI = new CrearExcelInventario(txtCodigoActualizar.Text, Convert.ToDouble(txtNumItemsActualizar.Text), txtDescProductoActualizar.Text, precio, rutaArchivoCompleta);
                if (File.Exists(rutaArchivoCompleta))
                {
                    CEI.UpdateProductToExcel();
                    MostrarInventarioAListViewExistentes(); //Muestro en el ListView lo que hay almacenado en el archivo Excel Inventario
                  
                }
               
            }
            else
            {
                if(txtCodigoActualizar.Text != "")
                {
                    MessageBox.Show("¡Es necesario llenar todos los campos!", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("¡Es necesario seleccionar un elemento de la lista de productos en existencia!", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Esta seguro de eliminar el producto?", "Borrar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                BorrarProducto();
                txtCodigoActualizar.Text = "";
                txtDescProductoActualizar.Text = "Agregar descripción...";
                txtDescProductoActualizar.ForeColor = Color.Silver;
                txtNumItemsActualizar.Text = "00";
                txtNumItemsActualizar.ForeColor = Color.Silver;
                txtPrecioUnitarioActualizar.Text = "$ 0.00";
                txtPrecioUnitarioActualizar.ForeColor = Color.Silver;
                txtCodigoBorrar.Text = "";
                txtDescProductoBorrar.Text = "";
            }
               
        }

        private void BorrarProducto()
        {
            string rutaArchivoCompleta = PathA + "Inventario.xlsx";
            double precio = double.Parse(txtPrecioUnitarioActualizar.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));

            CrearExcelInventario CEI = new CrearExcelInventario(txtCodigoBorrar.Text, Convert.ToDouble(txtNumItemsActualizar.Text), txtDescProductoBorrar.Text, precio, rutaArchivoCompleta);
            if (txtCodigoBorrar.Text != "" && txtDescProductoBorrar.Text != "Agregar descripción...")
            {
                if (File.Exists(rutaArchivoCompleta))
                {
                    CEI.DeleteProductoToExcel();
                    MostrarInventarioAListViewExistentes(); //Muestro en el ListView lo que hay almacenado en el archivo Excel Inventario

                }

            }
            else
            {
                MessageBox.Show("¡Es necesario seleccionar un elemento de la lista de productos en existencia!", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
