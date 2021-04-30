using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CajaRegistradora;
using SpreadsheetLight;
using System.Text.RegularExpressions;
using System.IO;

namespace CajaRegistradoa
{
    public partial class FormDatosTienda : Form
    {
        private string PathA = @"C:\DataBaseSV\Archivos\"; //Directorio para Archivos
        public FormDatosTienda()
        {
            InitializeComponent();
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "Ej: Mi tienda S.A DE C.V")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.DimGray;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "Ej: Mi tienda S.A DE C.V";
                txtNombre.ForeColor = Color.Silver;
            }
        }

        private void txtSlogan_Enter(object sender, EventArgs e)
        {
            if (txtSlogan.Text == "Ej: ¡Vender producto de calidad!")
            {
                txtSlogan.Text = "";
                txtSlogan.ForeColor = Color.DimGray;
            }
        }

        private void txtSlogan_Leave(object sender, EventArgs e)
        {
            if (txtSlogan.Text == "")
            {
                txtSlogan.Text = "Ej: ¡Vender producto de calidad!";
                txtSlogan.ForeColor = Color.Silver;
            }
        }

        private void txtDireccion_Enter(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "################")
            {
                txtDireccion.Text = "";
                txtDireccion.ForeColor = Color.DimGray;
            }
        }

        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "")
            {
                txtDireccion.Text = "################";
                txtDireccion.ForeColor = Color.Silver;
            }
        }

        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "(##) ##-##-##-##-##")
            {
                txtTelefono.Text = "";
                txtTelefono.ForeColor = Color.DimGray;
            }
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "")
            {
                txtTelefono.Text = "(##) ##-##-##-##-##";
                txtTelefono.ForeColor = Color.Silver;
            }
        }

        private void txtEmail_Enter(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Mitienda@gmail.com" || txtEmail.Text == "Dirección no valida")
            {
                txtEmail.Text = "";
                txtEmail.ForeColor = Color.DimGray;
            }
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
           
            if (txtEmail.Text != "")
            {
                if (ComprobarFormatoEmail(txtEmail.Text) == false)
                {
                    txtEmail.Text = "Dirección no valida";
                    txtEmail.ForeColor = Color.Red;
                }
                else
                {
                    txtEmail.ForeColor = Color.DimGray;
                }
            }
            else
            {
                txtEmail.Text = "Mitienda@gmail.com";
                txtEmail.ForeColor = Color.Silver;
            }
                

        }

        private void txtPaginaWeb_Enter(object sender, EventArgs e)
        {
            if (txtPaginaWeb.Text == "Ej: www.mitienda.com")
            {
                txtPaginaWeb.Text = "";
                txtPaginaWeb.ForeColor = Color.DimGray;
            }
        }

        private void txtPaginaWeb_Leave(object sender, EventArgs e)
        {
            if (txtPaginaWeb.Text == "")
            {
                txtPaginaWeb.Text = "Ej: www.mitienda.com";
                txtPaginaWeb.ForeColor = Color.Silver;
            }
        }

        private void txtCodigoPostal_Enter(object sender, EventArgs e)
        {
            if (txtCodigoPostal.Text == "#####")
            {
                txtCodigoPostal.Text = "";
                txtCodigoPostal.ForeColor = Color.DimGray;
            }
        }

        private void txtCodigoPostal_Leave(object sender, EventArgs e)
        {
            if (txtCodigoPostal.Text == "")
            {
                txtCodigoPostal.Text = "#####";
                txtCodigoPostal.ForeColor = Color.Silver;
            }
        }
        public static bool ComprobarFormatoEmail(string sEmailAComprobar) //Código  que comprueba el formato del e-mail introducido
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void FormDatosTienda_Load(object sender, EventArgs e)
        {
            //Al entrar, inicializo los textbox con los datos existentes en el Excel
            string rutaArchivoCompleta = PathA + "InfoTienda.xlsx";
           
            if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe
            {
                SLDocument ArchivoExcel = new SLDocument(rutaArchivoCompleta);
                int iRow = 2;
                while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                {
                    if (ArchivoExcel.GetCellValueAsString(iRow, 1) != "Ej: Mi tienda S.A DE C.V")
                    {
                        txtNombre.Text = ArchivoExcel.GetCellValueAsString(iRow, 1);
                        txtNombre.ForeColor = Color.DimGray;
                        txtNombre.Font = new Font(txtNombre.Font, FontStyle.Bold);
                    }
                    if (ArchivoExcel.GetCellValueAsString(iRow, 2) != "Ej: ¡Vender producto de calidad!")
                    {
                        txtSlogan.Text = ArchivoExcel.GetCellValueAsString(iRow, 2);
                        txtSlogan.ForeColor = Color.DimGray;
                        txtSlogan.Font = new Font(txtNombre.Font, FontStyle.Bold);
                    }
                    if (ArchivoExcel.GetCellValueAsString(iRow, 3) != "################")
                    {
                        txtDireccion.Text = ArchivoExcel.GetCellValueAsString(iRow, 3);
                        txtDireccion.ForeColor = Color.DimGray;
                        txtDireccion.Font = new Font(txtNombre.Font, FontStyle.Bold);
                    }
                    if (ArchivoExcel.GetCellValueAsString(iRow, 4) != "#####")
                    {
                        txtCodigoPostal.Text = ArchivoExcel.GetCellValueAsString(iRow, 4);
                        txtCodigoPostal.ForeColor = Color.DimGray;
                        txtCodigoPostal.Font = new Font(txtNombre.Font, FontStyle.Bold);
                    }
                    if (ArchivoExcel.GetCellValueAsString(iRow, 5) != "(##) ##-##-##-##-##")
                    {
                        txtTelefono.Text = ArchivoExcel.GetCellValueAsString(iRow, 5);
                        txtTelefono.ForeColor = Color.DimGray;
                        txtTelefono.Font = new Font(txtNombre.Font, FontStyle.Bold);
                    }
                    if (ArchivoExcel.GetCellValueAsString(iRow, 6) != "Mitienda@gmail.com")
                    {
                        txtEmail.Text = ArchivoExcel.GetCellValueAsString(iRow, 6);
                        txtEmail.ForeColor = Color.DimGray;
                        txtEmail.Font = new Font(txtNombre.Font, FontStyle.Bold);
                    }
                    if (ArchivoExcel.GetCellValueAsString(iRow, 7) != "Ej: www.mitienda.com")
                    {
                        txtPaginaWeb.Text = ArchivoExcel.GetCellValueAsString(iRow, 7);
                        txtPaginaWeb.ForeColor = Color.DimGray;
                        txtPaginaWeb.Font = new Font(txtNombre.Font, FontStyle.Bold);
                    }
                    iRow++;
                }

            }
            
        }

        private void btnActualizar_Click(object sender, EventArgs e) //botón para actualizar la información de la tienda
        {
          
            string rutaArchivoCompleta = PathA + "InfoTienda.xlsx";
            try
            {
                //creamos el objeto SLDocument el cual creara el excel
                SLDocument sl = new SLDocument();

                //creamos las celdas en diagonal
                //utilizando la función setcellvalue pueden navegar sobre el documento
                //primer parametro es la fila el segundo la columna y el tercero el dato de la celda
                //for (int i = 1; i <= 10; ++i) sl.SetCellValue(i, i, "patito " + i);
                sl.SetCellValue(1, 1, "Nombre");
                sl.SetCellValue(1, 2, "Slogan");
                sl.SetCellValue(1, 3, "Direccion");
                sl.SetCellValue(1, 4, "Codigo postal");
                sl.SetCellValue(1, 5, "Telefono");
                sl.SetCellValue(1, 6, "Email");
                sl.SetCellValue(1, 7, "Pagina web");
             
                sl.SetCellValue(2, 1, txtNombre.Text);
                sl.SetCellValue(2, 2, txtSlogan.Text);
                sl.SetCellValue(2, 3, txtDireccion.Text);
                sl.SetCellValue(2, 4, txtCodigoPostal.Text);
                sl.SetCellValue(2, 5, txtTelefono.Text);
                sl.SetCellValue(2, 6, txtEmail.Text);
                sl.SetCellValue(2, 7, txtPaginaWeb.Text);
 
                //Guardar como, y aqui ponemos la ruta de nuestro archivo
                sl.SaveAs(rutaArchivoCompleta);
                MessageBox.Show("¡Datos Actualizados correctamente!");
                CambiarColoresTextbox();
            }
            catch (Exception ex)
            {
                MessageBox.Show("¡Algo salio mal :(!: " + ex.Message);
            }
        }
        public void CambiarColoresTextbox()
        {
           if(txtNombre.Text != "Ej: Mi tienda S.A DE C.V")
            {
                txtNombre.ForeColor = Color.DimGray;
                txtNombre.Font = new Font(txtNombre.Font,FontStyle.Bold);
            }
            if (txtSlogan.Text != "Ej: ¡Vender producto de calidad!")
            {
                txtSlogan.ForeColor = Color.DimGray;
                txtSlogan.Font = new Font(txtNombre.Font, FontStyle.Bold);
            }
            if(txtDireccion.Text != "################")
            {
                txtDireccion.ForeColor = Color.DimGray;
                txtDireccion.Font = new Font(txtNombre.Font, FontStyle.Bold);
            }
           if(txtCodigoPostal.Text != "#####")
            {
                txtCodigoPostal.ForeColor = Color.DimGray;
                txtCodigoPostal.Font = new Font(txtNombre.Font, FontStyle.Bold);
            }
           if(txtTelefono.Text != "(##) ##-##-##-##-##")
            {
                txtTelefono.ForeColor = Color.DimGray;
                txtTelefono.Font = new Font(txtNombre.Font, FontStyle.Bold);
            }
           if(txtEmail.Text != "Mitienda@gmail.com")
            {
                txtEmail.ForeColor = Color.DimGray;
                txtEmail.Font = new Font(txtNombre.Font, FontStyle.Bold);
            }
           if(txtPaginaWeb.Text != "Ej: www.mitienda.com")
            {
                txtPaginaWeb.ForeColor = Color.DimGray;
                txtPaginaWeb.Font = new Font(txtNombre.Font, FontStyle.Bold);
            }
        }
        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)  //Solo puede introducir números
        {
            VerificarTextbox(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            VerificarTextbox(e);
        }
        public void VerificarTextbox(KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
