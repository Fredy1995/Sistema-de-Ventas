using CajaRegistradora;
using SpreadsheetLight;
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

namespace CajaRegistradoa
{
    public partial class FormPerfil : Form
    {
        private string PathA = @"C:\DataBaseSV\Archivos\"; //Directorio para Archivos
        private string PathF = @"C:\DataBaseSV\Fotos\"; //Directorio para Fotografias
        private double IdUsuario;
        public FormPerfil(double iduser)
        {
            InitializeComponent();
            this.IdUsuario = iduser;
        }

        private void FormPerfil_Load(object sender, EventArgs e)
        {
            Cargardatos();
        }
        private void Cargardatos()
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
                        txtNombreApellidos.Text = ArchivoExcel.GetCellValueAsString(iRow,5) +" "+ ArchivoExcel.GetCellValueAsString(iRow,6)+" "+ ArchivoExcel.GetCellValueAsString(iRow, 7);
                        txtFnacimiento.Text = ArchivoExcel.GetCellValueAsString(iRow, 9);
                        txtEdad.Text = ArchivoExcel.GetCellValueAsString(iRow, 8);
                        txtFRegistro.Text = ArchivoExcel.GetCellValueAsString(iRow, 4);
                        txtIDUser.Text = ArchivoExcel.GetCellValueAsString(iRow, 1);
                        txtNombreUsuario.Text = ArchivoExcel.GetCellValueAsString(iRow, 2);
                         pbFotoperfil.Image = Image.FromFile(PathF+IdUsuario+".jpg");
                    }
                    iRow++;
                }
               

            }
        }
    }
}
