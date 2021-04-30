using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaRegistradoa
{
    class CrearExcelInventarioAgotados
    {
        private string rutaArchivoCompleta = "";
        private double NumItems;
        private int Fila;
        private string Codigo, Descripcion;
        public CrearExcelInventarioAgotados(string Codigo, double NumItems, string Descripcion, string rutaArchivoCompleta)
        {
            this.Codigo = Codigo;
            this.NumItems = NumItems;
            this.Descripcion = Descripcion;
            this.rutaArchivoCompleta = rutaArchivoCompleta;
        }
        public void CrearExcelIA() //Metodo para agregar los articulos que estan agotados por PRIMERA VEZ, es decir, que su N° Items = 0
        {
            try
            {
                //creamos el objeto SLDocument el cual creara el excel
                SLDocument sl = new SLDocument();

                //creamos las celdas en diagonal
                //utilizando la función setcellvalue pueden navegar sobre el documento
                //primer parametro es la fila el segundo la columna y el tercero el dato de la celda
                //for (int i = 1; i <= 10; ++i) sl.SetCellValue(i, i, "patito " + i);
                sl.SetCellValue(1, 1, "Código");
                sl.SetCellValue(1, 2, "N° Items");
                sl.SetCellValue(1, 3, "Descripción");

                sl.SetCellValue(2, 1, Codigo);
                sl.SetCellValue(2, 2, NumItems);
                sl.SetCellValue(2, 3, Descripcion);
                //Guardar como, y aqui ponemos la ruta de nuestro archivo
                sl.SaveAs(rutaArchivoCompleta);
            }
            catch (Exception ex)
            {

                MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void AddProductToExcelIA() //Metodo para agregar los articulos agotados, el Excel ya existe con almenos 1 articulo
        {

            try
            {
                SLDocument s2 = new SLDocument(rutaArchivoCompleta);
                int iRow = 1;
                while (!string.IsNullOrEmpty(s2.GetCellValueAsString(iRow, 1)))
                {
                    iRow++;
                }
                s2.SetCellValue(iRow, 1, Codigo);
                s2.SetCellValue(iRow, 2, NumItems);
                s2.SetCellValue(iRow, 3, Descripcion);
                s2.SaveAs(rutaArchivoCompleta);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void DeleteProductoToExcelIA() //Metodo para eliminar el articulo de la lista de productos agotados
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
    }
}
