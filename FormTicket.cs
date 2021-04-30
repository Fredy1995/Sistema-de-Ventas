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
    public partial class FormTicket : Form
    {
     
        private ListView ListaProductos;
        private string Efectivo, Cambio,NameOperador,TelTienda,NameTienda;
        private string RutaDirectoryTickets = @"C:\DataBaseSV\Tickets"; //directorio principal Tickets
        private long NoVenta;
        private int timeLeft = 10; //Segundos
        public FormTicket(string NameTienda,string TelTienda,string NameOperador,ListView ListaProductos,string Efectivo, string Cambio,long NoVenta)
        {
            InitializeComponent();
            this.NameTienda = NameTienda;
            this.TelTienda = TelTienda;
            this.NameOperador = NameOperador;
            this.ListaProductos = ListaProductos;
            this.Efectivo = Efectivo;
            this.Cambio = Cambio;
            this.NoVenta = NoVenta;

        }

        private void FormTicket_Load(object sender, EventArgs e)
        {
            btnCerrar.Focus();
            CrearDirectorios();
            Mostrarticket();
            timer1.Start();
        }
        private string obtenerNombreMesNumero(int numeroMes)
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
        private void CrearDirectorios()  //Meotod que se encarga de crear las carpetas para guardar los tickets de venta
        {
            string CarpetaAnio = RutaDirectoryTickets + "\\"+ DateTime.Now.Year;
            string CarpetaMes = CarpetaAnio+"\\"+ obtenerNombreMesNumero(DateTime.Now.Month);
            string CarpetaDia = CarpetaMes + "\\" + DateTime.Now.DayOfWeek + "_" + DateTime.Now.Day;

            // DirectoryInfo Principal = Directory.CreateDirectory(RutaDirectoryPrincipal);
            if (!Directory.Exists(CarpetaAnio)) ///Solo si no existen la carpeta con el año actual, entonces se crean
            {
                    DirectoryInfo Anio = Directory.CreateDirectory(CarpetaAnio);
                    if (!Directory.Exists(CarpetaMes)) ///Solo si no existen la carpeta con el Mes actual, entonces se crean
                    {
                    DirectoryInfo Mes = Directory.CreateDirectory(CarpetaMes);
                        if (!Directory.Exists(CarpetaDia)) ///Solo si no existen la carpeta con el Mes actual, entonces se crean
                        {
                         DirectoryInfo Dia = Directory.CreateDirectory(CarpetaDia);
                        }
                    }
            }
            else
            {
                if (!Directory.Exists(CarpetaMes)) ///Solo si no existen la carpeta con el Mes actual, entonces se crean
                {
                    DirectoryInfo Mes = Directory.CreateDirectory(CarpetaMes);
                }
                if (!Directory.Exists(CarpetaDia)) //Pregunto si existe la carpeta del dia actual, si no existe lo vuelvo true para crearla
                {
                    DirectoryInfo Dia = Directory.CreateDirectory(CarpetaDia);
                }
            }
            
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                lblTemporizador.Text = Convert.ToString(timeLeft);
                timeLeft--;
            }
            else
            {
                timer1.Stop();
                this.Close(); //Cerrar el formulario despues de cierto tiempo
            }
           
        }

        private void Mostrarticket()
        {
            
            int Cantidad, ArtVendidos = 0; ;
            double PUnit, Importe, sumar = 0;
           
            listDatos.Items.Add("\t\""+NameTienda.ToUpper()+"\"");
            listDatos.Items.Add("TEL: "+TelTienda);
            listDatos.Items.Add("Nota de vta: " +  NoVenta.ToString("D8"));
            listDatos.Items.Add("Fecha: " + DateTime.Now.ToShortDateString() + "\t  Hora: "+ DateTime.Now.ToString("hh:mm")); ;
            listDatos.Items.Add("Atendido por: "+NameOperador);
            listDatos.Items.Add("Cantidad\tDescripción del producto");
            listDatos.Items.Add("\t\tPrecio Unit.\tImporte");
           listDatos.Items.Add("------------------------------------------------------------");
            for (int i = 0; i < ListaProductos.Items.Count; i++) //Recorro la lista de productos vendidos y los imprimo en el formulario ticket
            {
                Cantidad = int.Parse(ListaProductos.Items[i].SubItems[1].Text);
                ArtVendidos += Cantidad;
                Importe = double.Parse(ListaProductos.Items[i].SubItems[3].Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
                sumar += double.Parse(ListaProductos.Items[i].SubItems[3].Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
                PUnit = Importe / Cantidad;
                listDatos.Items.Add(ListaProductos.Items[i].SubItems[1].Text + "\t" + ListaProductos.Items[i].SubItems[2].Text);
                listDatos.Items.Add("\t\t"+ PUnit.ToString("C")+"\t\t"+ ListaProductos.Items[i].SubItems[3].Text);
            }
            listDatos.Items.Add("------------------------------------------------------------");
            listDatos.Items.Add("Total:\t\t\t\t"+ sumar.ToString("C"));
            listDatos.Items.Add("Efectivo:\t\t\t\t"+Efectivo);
            listDatos.Items.Add("");
            listDatos.Items.Add("Cambio:\t\t\t\t"+Cambio);
            listDatos.Items.Add("------------------------------------------------------------");
            listDatos.Items.Add("Artículos vendidos:\t\t\t"+ArtVendidos);
            listDatos.Items.Add(Convert.ToDecimal(sumar).NumeroALetras().ToLower() + " M.N.");
            listDatos.Items.Add("------------------------------------------------------------");
            listDatos.Items.Add("\t  ¡EXCELENTE VENTA!");
            ImprimirTicketTXT();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImprimirTicketTXT() //Metodo que se encarga de imprimir los datos del ticket en un archivo txt
        {
            string CarpetaAnio = RutaDirectoryTickets + "\\" + DateTime.Now.Year;
            string CarpetaMes = CarpetaAnio + "\\" + obtenerNombreMesNumero(DateTime.Now.Month);
            string CarpetaDia = CarpetaMes + "\\" + DateTime.Now.DayOfWeek + "_" + DateTime.Now.Day;
           
            int Cantidad, ArtVendidos = 0; ;
            double PUnit, Importe, sumar = 0;
         
            string NameTxt = CarpetaDia+"\\Nota"+NoVenta.ToString("D8") + ".txt";
            if (File.Exists(NameTxt)) //Si existe el archivo lo reemplaza 
            {
                StreamWriter flujoSalida = File.CreateText(NameTxt);

                flujoSalida.WriteLine("\t\"" + NameTienda.ToUpper() + "\"");
                flujoSalida.WriteLine("TEL: " + TelTienda);
                flujoSalida.WriteLine("Nota de vta: " + NoVenta.ToString("D8")); ;
                flujoSalida.WriteLine("Fecha: " + DateTime.Now.ToShortDateString() + "\t  Hora: " + DateTime.Now.ToString("hh:mm")); ;
                flujoSalida.WriteLine("Atendido por: " + NameOperador);
                flujoSalida.WriteLine("Cantidad\tDescripción del producto");
                flujoSalida.WriteLine("\t\tPrecio Unit.\tImporte");
                flujoSalida.WriteLine("------------------------------------------------------------");
                for (int i = 0; i < ListaProductos.Items.Count; i++) //Recorro la lista de productos vendidos y los imprimo en el formulario ticket
                {
                    Cantidad = int.Parse(ListaProductos.Items[i].SubItems[1].Text);
                    ArtVendidos += Cantidad;
                    Importe = double.Parse(ListaProductos.Items[i].SubItems[3].Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
                    sumar += double.Parse(ListaProductos.Items[i].SubItems[3].Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
                    PUnit = Importe / Cantidad;
                    flujoSalida.WriteLine(ListaProductos.Items[i].SubItems[1].Text + "\t" + ListaProductos.Items[i].SubItems[2].Text);
                    flujoSalida.WriteLine("\t\t" + PUnit.ToString("C") + "\t\t" + ListaProductos.Items[i].SubItems[3].Text);
                }
                flujoSalida.WriteLine("------------------------------------------------------------");
                flujoSalida.WriteLine("Total:\t\t\t\t" + sumar.ToString("C"));
                flujoSalida.WriteLine("Efectivo:\t\t\t" + Efectivo);
                flujoSalida.WriteLine("");
                flujoSalida.WriteLine("Cambio:\t\t\t\t" + Cambio);
                flujoSalida.WriteLine("------------------------------------------------------------");
                flujoSalida.WriteLine("Artículos vendidos:\t\t" + ArtVendidos);
                flujoSalida.WriteLine(Convert.ToDecimal(sumar).NumeroALetras().ToLower() + " M.N.");
                flujoSalida.WriteLine("------------------------------------------------------------");
                flujoSalida.WriteLine("\t  ¡EXCELENTE VENTA!");
                flujoSalida.Close();
            }
            else
            {       //Si no  existe el archivo entonces se crea
                StreamWriter flujoSalida = File.CreateText(NameTxt);

                flujoSalida.WriteLine("\t\"" + NameTienda.ToUpper() + "\"");
                flujoSalida.WriteLine("TEL: " + TelTienda);
                flujoSalida.WriteLine("Nota de vta: " + NoVenta.ToString("D8")); ;
                flujoSalida.WriteLine("Fecha: " + DateTime.Now.ToShortDateString() + "\t  Hora: " + DateTime.Now.ToString("hh:mm")); ;
                flujoSalida.WriteLine("Atendido por: " + NameOperador);
                flujoSalida.WriteLine("Cantidad\tDescripción del producto");
                flujoSalida.WriteLine("\t\tPrecio Unit.\tImporte");
                flujoSalida.WriteLine("------------------------------------------------------------");
                for (int i = 0; i < ListaProductos.Items.Count; i++) //Recorro la lista de productos vendidos y los imprimo en el formulario ticket
                {
                    Cantidad = int.Parse(ListaProductos.Items[i].SubItems[1].Text);
                    ArtVendidos += Cantidad;
                    Importe = double.Parse(ListaProductos.Items[i].SubItems[3].Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
                    sumar += double.Parse(ListaProductos.Items[i].SubItems[3].Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US"));
                    PUnit = Importe / Cantidad;
                    flujoSalida.WriteLine(ListaProductos.Items[i].SubItems[1].Text + "\t" + ListaProductos.Items[i].SubItems[2].Text);
                    flujoSalida.WriteLine("\t\t" + PUnit.ToString("C") + "\t\t" + ListaProductos.Items[i].SubItems[3].Text);
                }
                flujoSalida.WriteLine("------------------------------------------------------------");
                flujoSalida.WriteLine("Total:\t\t\t\t" + sumar.ToString("C"));
                flujoSalida.WriteLine("Efectivo:\t\t\t" + Efectivo);
                flujoSalida.WriteLine("");
                flujoSalida.WriteLine("Cambio:\t\t\t\t" + Cambio);
                flujoSalida.WriteLine("------------------------------------------------------------");
                flujoSalida.WriteLine("Artículos vendidos:\t\t" + ArtVendidos);
                flujoSalida.WriteLine(Convert.ToDecimal(sumar).NumeroALetras().ToLower() + " M.N.");
                flujoSalida.WriteLine("------------------------------------------------------------");
                flujoSalida.WriteLine("\t  ¡EXCELENTE VENTA!");
                flujoSalida.Close();

            }

        }
    }
}
