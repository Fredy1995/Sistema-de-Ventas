using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaRegistradoa
{
    class TotalEnCaja
    {
        private double Cantidad;
        string rutaArchivoCompleta,Fecha;
        private int Fila;
        public TotalEnCaja(double Cantidad,string Fecha,string rutaArchivoCompleta)
        {
            this.Cantidad = Cantidad;
            this.Fecha = Fecha;
            this.rutaArchivoCompleta = rutaArchivoCompleta;
        }

        public void AddTotalCajaToExcel() //Metodo que se encarga de agregar el total que hay en caja en el archivo Excel AperturasDeCaja
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
                s2.SetCellValue(Fila, 6, Cantidad);
                s2.SaveAs(rutaArchivoCompleta);
              
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
