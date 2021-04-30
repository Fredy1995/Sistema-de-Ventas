using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpreadsheetLight;
using System.Windows.Forms;
using System.IO;

namespace CajaRegistradoa
{

    class CrearExcelUsuarios
    {
        private string rutaArchivoCompleta = "";
        private double Id;
        private string Nombre,Apaterno,Amaterno,Edad,Fnacimiento,User,Pass,FRegistro;
        public CrearExcelUsuarios(double Id, string User, string Pass, string FRegistro, string Nombre,string Apaterno,string Amaterno,string Edad,string Fnacimiento,string rutaArchivoCompleta)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Apaterno = Apaterno;
            this.Amaterno = Amaterno;
            this.Edad = Edad;
            this.Fnacimiento = Fnacimiento;
            this.User = User;
            this.Pass = Pass;
            this.FRegistro = FRegistro;
            this.rutaArchivoCompleta = rutaArchivoCompleta;
        }
        public void CrearExcelU()
        {
            try
            {
                //creamos el objeto SLDocument el cual creara el excel
                SLDocument sl = new SLDocument();

                //creamos las celdas en diagonal
                //utilizando la función setcellvalue pueden navegar sobre el documento
                //primer parametro es la fila el segundo la columna y el tercero el dato de la celda
                //for (int i = 1; i <= 10; ++i) sl.SetCellValue(i, i, "patito " + i);
                sl.SetCellValue(1, 1, "Id");
                sl.SetCellValue(1, 2, "Usuario");
                sl.SetCellValue(1, 3, "Password");
                sl.SetCellValue(1, 4, "Fecha Registro");
                sl.SetCellValue(1, 5, "Nombre");
                sl.SetCellValue(1, 6, "A.Paterno");
                sl.SetCellValue(1, 7, "A.Materno");
                sl.SetCellValue(1, 8, "Edad");
                sl.SetCellValue(1, 9, "F.Nacimiento");
                sl.SetCellValue(2, 1, Id);
                sl.SetCellValue(2, 2, User);
                sl.SetCellValue(2, 3, Pass);
                sl.SetCellValue(2, 4, FRegistro);
                sl.SetCellValue(2, 5, Nombre);
                sl.SetCellValue(2, 6, Apaterno);
                sl.SetCellValue(2, 7, Amaterno);
                sl.SetCellValue(2, 8, Edad);
                sl.SetCellValue(2, 9, Fnacimiento);
                //Guardar como, y aqui ponemos la ruta de nuestro archivo
                sl.SaveAs(rutaArchivoCompleta);
                MessageBox.Show("¡Usuario agregado correctamente!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void AddUserToExcel()
        {

            try
            {
                 SLDocument s2 = new SLDocument(rutaArchivoCompleta);
                int iRow = 1;
                while (!string.IsNullOrEmpty(s2.GetCellValueAsString(iRow, 1)))
                {
                    iRow++;
                }
                s2.SetCellValue(iRow, 1, Id);
                s2.SetCellValue(iRow, 2, User);
                s2.SetCellValue(iRow, 3, Pass);
                s2.SetCellValue(iRow, 4, FRegistro);
                s2.SetCellValue(iRow, 5, Nombre);
                s2.SetCellValue(iRow, 6, Apaterno);
                s2.SetCellValue(iRow, 7, Amaterno);
                s2.SetCellValue(iRow, 8, Edad);
                s2.SetCellValue(iRow, 9, Fnacimiento);
                s2.SaveAs(rutaArchivoCompleta);
                MessageBox.Show("¡Usuario agregado correctamente!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Algo salió mal :(!" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
