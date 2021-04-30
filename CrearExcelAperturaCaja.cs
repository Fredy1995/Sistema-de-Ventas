using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaRegistradoa
{
    class CrearExcelAperturaCaja
    {
        private double Cantidad;
        private long NoApertura;
        private string Fecha, Hora, Operador,rutaArchivoCompleta;
        private int Fila;
        public CrearExcelAperturaCaja(long NoApertura,double Cantidad,string Fecha, string Hora,string Operador,string rutaArchivoCompleta)
        {
            this.NoApertura = NoApertura;
            this.Cantidad = Cantidad;
            this.Fecha = Fecha;
            this.Hora = Hora;
            this.Operador = Operador;
            this.rutaArchivoCompleta = rutaArchivoCompleta;
        }
        public void CrearExcelAC()
        {
            try
            {
                //creamos el objeto SLDocument el cual creara el excel
                SLDocument sl = new SLDocument();

                //creamos las celdas en diagonal
                //utilizando la función setcellvalue pueden navegar sobre el documento
                //primer parametro es la fila el segundo la columna y el tercero el dato de la celda
                //for (int i = 1; i <= 10; ++i) sl.SetCellValue(i, i, "patito " + i);
                sl.SetCellValue(1, 1, "N° Apertura");
                sl.SetCellValue(1, 2, "Cantidad");
                sl.SetCellValue(1, 3, "Fecha");
                sl.SetCellValue(1, 4, "Hora");
                sl.SetCellValue(1, 5, "Operador");
                sl.SetCellValue(1, 6, "TotalEnCaja");

                sl.SetCellValue(2, 1, NoApertura.ToString("D8"));
                sl.SetCellValue(2, 2, Cantidad);
                sl.SetCellValue(2, 3, Fecha);
                sl.SetCellValue(2, 4, Hora);
                sl.SetCellValue(2, 5, Operador);

                //Guardar como, y aqui ponemos la ruta de nuestro archivo
                sl.SaveAs(rutaArchivoCompleta);
                MessageBox.Show("¡Apertura agregada con éxito!");
            }
            catch (Exception ex)
            {

                MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AddAperturaToExcel()
        {

            try
            {
                SLDocument s2 = new SLDocument(rutaArchivoCompleta);
                int iRow = 1;
                while (!string.IsNullOrEmpty(s2.GetCellValueAsString(iRow, 1)))
                {
                    iRow++;
                }
                s2.SetCellValue(iRow, 1, NoApertura.ToString("D8"));
                s2.SetCellValue(iRow, 2, Cantidad);
                s2.SetCellValue(iRow, 3, Fecha);
                s2.SetCellValue(iRow, 4, Hora);
                s2.SetCellValue(iRow, 5, Operador);
                s2.SaveAs(rutaArchivoCompleta);
                //Guardar como, y aqui ponemos la ruta de nuestro archivo
                MessageBox.Show("¡Apertura agregada con éxito!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UpdateAperturaExcel() //Solo va actualizar en la fecha de hoy
        {

            try
            {
                SLDocument s2 = new SLDocument(rutaArchivoCompleta);
                int iRow = 1;
                while (!string.IsNullOrEmpty(s2.GetCellValueAsString(iRow, 1)))
                {
                    if (Fecha == s2.GetCellValueAsString(iRow, 3)) //Recorro el archivo y pregunto si existe la misma fecha de apertura 
                    {
                        Fila = iRow;  //Obtengo la fila a donde que se va a modificar
                    }
                    iRow++;
                }
                s2.SetCellValue(Fila, 2, Cantidad);
                s2.SetCellValue(Fila, 4, Hora);
                s2.SetCellValue(Fila, 5, Operador);

                s2.SaveAs(rutaArchivoCompleta);
                MessageBox.Show("¡Apertura agregada con éxito!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
