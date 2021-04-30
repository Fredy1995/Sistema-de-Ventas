using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaRegistradoa
{
    class CrearExcelSalidasEfectivo
    {
        private double Cantidad;
        private string Concepto, Fecha, Hora, Operador, rutaArchivoCompleta;
        private int Fila;
        private long NoSalida;
        public CrearExcelSalidasEfectivo(long NoSalida,double Cantidad,string Concepto, string Fecha,string Hora,string Operador,string rutaArchivoCompleta)
        {
            this.NoSalida = NoSalida;
            this.Cantidad = Cantidad;
            this.Concepto = Concepto;
            this.Fecha = Fecha;
            this.Hora = Hora;
            this.Operador = Operador;
            this.rutaArchivoCompleta = rutaArchivoCompleta;
        }
        public void CrearExcelSE()
        {
            try
            {
                //creamos el objeto SLDocument el cual creara el excel
                SLDocument sl = new SLDocument();

                //creamos las celdas en diagonal
                //utilizando la función setcellvalue pueden navegar sobre el documento
                //primer parametro es la fila el segundo la columna y el tercero el dato de la celda
                //for (int i = 1; i <= 10; ++i) sl.SetCellValue(i, i, "patito " + i);
                sl.SetCellValue(1, 1, "N° Salida");
                sl.SetCellValue(1, 2, "Cantidad");
                sl.SetCellValue(1, 3, "Concepto");
                sl.SetCellValue(1, 4, "Fecha");
                sl.SetCellValue(1, 5, "Hora");
                sl.SetCellValue(1, 6, "Operador");

                sl.SetCellValue(2, 1, NoSalida.ToString("D8")); ;
                sl.SetCellValue(2, 2, Cantidad);
                sl.SetCellValue(2, 3, Concepto);
                sl.SetCellValue(2, 4, Fecha);
                sl.SetCellValue(2, 5, Hora);
                sl.SetCellValue(2, 6, Operador);
                //Guardar como, y aqui ponemos la ruta de nuestro archivo
                sl.SaveAs(rutaArchivoCompleta);
                MessageBox.Show("¡OPERACIÓN EXITOSA!, Usted a retirado: " +Cantidad.ToString("C")+ " correctamente.");
            }
            catch (Exception ex)
            {

                MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void AddProductToExcel()
        {

            try
            {
                SLDocument s2 = new SLDocument(rutaArchivoCompleta);
                int iRow = 1;
                while (!string.IsNullOrEmpty(s2.GetCellValueAsString(iRow, 1)))
                {
                    iRow++;
                }
                s2.SetCellValue(iRow, 1, NoSalida.ToString("D8"));
                s2.SetCellValue(iRow, 2, Cantidad);
                s2.SetCellValue(iRow, 3, Concepto);
                s2.SetCellValue(iRow, 4, Fecha);
                s2.SetCellValue(iRow, 5, Hora);
                s2.SetCellValue(iRow, 6, Operador);

                s2.SaveAs(rutaArchivoCompleta);
                MessageBox.Show("¡OPERACIÓN EXITOSA!, Usted a retirado: " + Cantidad.ToString("C") + " correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
