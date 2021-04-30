using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaRegistradoa
{
    class CrearExcelControlVenta
    {
        private string rutaArchivoCompleta;
        private double PrecioUnit,Importe;
        private int Cantidad;
        private string Fecha, Hora, NameOperador;
        private long NoVenta;
        private ListView ListaProductos;
        public CrearExcelControlVenta(string rutaArchivoCompleta, long NoVenta,ListView ListaProductos,string Fecha,string Hora, string NameOperador)
        {
            this.NoVenta = NoVenta;
            this.ListaProductos = ListaProductos;
            this.NameOperador = NameOperador;
            this.rutaArchivoCompleta = rutaArchivoCompleta;
            this.Fecha = Fecha;
            this.Hora = Hora;
        }
        public void CrearExcelCV()
        {
          
            try
            {
                //creamos el objeto SLDocument el cual creara el excel
                SLDocument sl = new SLDocument();

                //creamos las celdas en diagonal
                //utilizando la función setcellvalue pueden navegar sobre el documento
                //primer parametro es la fila el segundo la columna y el tercero el dato de la celda
                //for (int i = 1; i <= 10; ++i) sl.SetCellValue(i, i, "patito " + i);
                sl.SetCellValue(1, 1, "Nota");
                sl.SetCellValue(1, 2, "Código");
                sl.SetCellValue(1, 3, "Cantidad");
                sl.SetCellValue(1, 4, "Descripción del producto");
                sl.SetCellValue(1, 5, "Precio Unit.");
                sl.SetCellValue(1, 6, "Importe");
                sl.SetCellValue(1, 7, "Fecha");
                sl.SetCellValue(1, 8, "Hora");
                sl.SetCellValue(1, 9, "Atendido por");

               

                for (int i = 0; i < ListaProductos.Items.Count; i++)
                {
                    sl.SetCellValue(i + 2, 1, NoVenta.ToString("D8"));
                    sl.SetCellValue(i + 2, 2, ListaProductos.Items[i].SubItems[0].Text); //codigo
                    Cantidad = int.Parse(ListaProductos.Items[i].SubItems[1].Text);
                    sl.SetCellValue(i + 2, 3, ListaProductos.Items[i].SubItems[1].Text); //Cantidad
                    sl.SetCellValue(i + 2, 4, ListaProductos.Items[i].SubItems[2].Text); //Descripcion
                    Importe = double.Parse(ListaProductos.Items[i].SubItems[3].Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US")); //Importe
                    PrecioUnit = Importe / Cantidad;
                    sl.SetCellValue(i + 2, 5, PrecioUnit);
                    sl.SetCellValue(i + 2, 6, Importe);
                    sl.SetCellValue(i + 2, 7, Fecha);
                    sl.SetCellValue(i + 2, 8, Hora);
                    sl.SetCellValue(i + 2, 9, NameOperador);

                }
                
                //Guardar como, y aqui ponemos la ruta de nuestro archivo
                sl.SaveAs(rutaArchivoCompleta);
               
            }
            catch (Exception ex)
            {

                MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void AddToExcelCV()
        {

            try
            {
                SLDocument s2 = new SLDocument(rutaArchivoCompleta);
                int iRow = 1;
                while (!string.IsNullOrEmpty(s2.GetCellValueAsString(iRow, 1)))
                {
                    iRow++;
                }
               
                for (int i = 0; i < ListaProductos.Items.Count; i++)
                {
                    s2.SetCellValue(i + iRow, 1, NoVenta.ToString("D8"));
                    s2.SetCellValue(i + iRow, 2, ListaProductos.Items[i].SubItems[0].Text); //codigo
                    Cantidad = int.Parse(ListaProductos.Items[i].SubItems[1].Text);
                    s2.SetCellValue(i + iRow, 3, ListaProductos.Items[i].SubItems[1].Text); //Cantidad
                    s2.SetCellValue(i + iRow, 4, ListaProductos.Items[i].SubItems[2].Text); //Descripcion
                    Importe = double.Parse(ListaProductos.Items[i].SubItems[3].Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-US")); //Importe
                    PrecioUnit = Importe / Cantidad;
                    s2.SetCellValue(i + iRow, 5, PrecioUnit);
                    s2.SetCellValue(i + iRow, 6, Importe);
                    s2.SetCellValue(i + iRow, 7, Fecha);
                    s2.SetCellValue(i + iRow, 8, Hora);
                    s2.SetCellValue(i + iRow, 9, NameOperador);
                }

               

                s2.SaveAs(rutaArchivoCompleta);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
