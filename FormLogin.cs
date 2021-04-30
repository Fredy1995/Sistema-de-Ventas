using CajaRegistradoa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpreadsheetLight;
using System.IO;
using System.Threading;




namespace CajaRegistradora
{
    public partial class FormLogin : Form
    {
        private string RutaDirectoryPrincipal = @"C:\DataBaseSV"; //Creamos el directorio de Datos de todo el sistema
        private string RutaDirectoryArchivos = @"C:\DataBaseSV\Archivos";
        private string RutaDirectoryFotos = @"C:\DataBaseSV\Fotos";
        private string RutaDirectoryTickets = @"C:\DataBaseSV\Tickets";
        private string PathA = @"C:\DataBaseSV\Archivos\"; //Directorio para Archivos
        private bool encontrado;
        private double IdUser;
        Loading loading;
        public FormLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void button1_Click(object sender, EventArgs e)
        {
            string rutaArchivo = RutaDirectoryPrincipal + "\\StatusCamara.txt";
            BorrarStatusCamaratxt(rutaArchivo); //ELimino el archivo TXT del status de camara
            Application.Exit();

        }

       private void BorrarStatusCamaratxt(string RutaArchivo) //Metodo que se encarga de eliminar el archivo de Estado de camara txt
        {
            try
            { 
                if (File.Exists(RutaArchivo)) //Pregunto si existe, de lo contrario no hace nada
                {
                    File.Delete(RutaArchivo); // Se Elimina el archivo
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al borrar archivo: {0}" + e.ToString(), "ERROR DE ARCHIVO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
            

            if (!Directory.Exists(RutaDirectoryPrincipal)) // Solo si no existe la carpeta se crea
            {

                DirectoryInfo Principal = Directory.CreateDirectory(RutaDirectoryPrincipal);
                if (!Directory.Exists(RutaDirectoryArchivos) && !Directory.Exists(RutaDirectoryFotos) && !Directory.Exists(RutaDirectoryTickets)) ///Solo si no existen las dos carpetas se crean
                {
                    DirectoryInfo Archivos = Directory.CreateDirectory(RutaDirectoryArchivos);
                    DirectoryInfo Fotos = Directory.CreateDirectory(RutaDirectoryFotos);
                    DirectoryInfo Tickets = Directory.CreateDirectory(RutaDirectoryTickets);
                }
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if(txtUsername.Text == "User name")
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.DarkCyan;
                lblAsteriscoUser.Visible = false;
            }
            else
            {
                txtUsername.ForeColor = Color.DarkCyan;
            }
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                txtUsername.Text = "User name";
                txtUsername.ForeColor = Color.Silver;
               
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text != "")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.DarkCyan;
                lblArteriscoPass.Visible = false;
            }
            else
            {
               
                txtPassword.ForeColor = Color.DarkCyan;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Silver;
                //txtPassword.UseSystemPasswordChar = false;
                
            }
            else
            {
                //txtPassword.UseSystemPasswordChar = true;
                txtPassword.ForeColor = Color.DarkCyan;
            }
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

       
        private void btnAjustes_Click(object sender, EventArgs e)
        {
           
            FormAjustes MenuAjustes = new FormAjustes();
            MenuAjustes.Show();
            this.Visible = false;
            MenuAjustes.btnRegistrarse_Click(sender,e); //Ejecutamos el control boton ajustes del form login
            
        }
        /*
         //Minimizar
this.WindowState= FormWindowState.Minimized;

//Maximizar
this.WindowState= FormWindowState.Maximized;

//Restaurar
this.WindowState= FormWindowState.Normal;


//Cerrar formulario activo
this.Close();


//Salir completamente de la aplicación
Application.Exit();
         
         */
        public void TiempoEspera()
        {
            Thread.Sleep(3000);
        }
        private async void btnAcceder_Click(object sender, EventArgs e)  //Metodo asincrono para acceder a pantalla principal
        {
            if(txtUsername.Text != "User name" && txtPassword.Text != "Password")
            {
                string rutaArchivoCompleta = PathA + "Usuarios.xlsx";
               
               
                //Ingreso User name y Password  
                lblAsteriscoUser.Visible = false;
                txtUsername.ForeColor = Color.Silver;
                lblArteriscoPass.Visible = false;
                txtPassword.ForeColor = Color.Silver;
                if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe
                {
                    SLDocument ArchivoExcel = new SLDocument(rutaArchivoCompleta);
                    int iRow = 2;
                    while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                    {
                        if(txtUsername.Text == ArchivoExcel.GetCellValueAsString(iRow, 2) && txtPassword.Text == ArchivoExcel.GetCellValueAsString(iRow, 3)) //Recorro el archivo y pregunto si existen las credenciales
                        {
                            encontrado = true;
                            IdUser = ArchivoExcel.GetCellValueAsDouble(iRow,1); //Obtengo el Id de Usuario
                        }
                       
                        iRow++;
                    }
                    //Verificar si las credenciales son correctas
                    if (encontrado)
                    {
                        loading = new Loading();
                        FormPrincipal frmprincipal = new FormPrincipal(IdUser); //Paso como parametro al Id de usuario al formulario principal
                        
                        //frmprincipal.WindowState = FormWindowState.Maximized;
                        loading.Show(); // Mostrar el loading
                        Task oTask = new Task(TiempoEspera);
                        oTask.Start(); // Se ejecuta el metodo asincrono
                        await oTask;
                        if (loading != null)
                        {
                            loading.Close();
                            frmprincipal.Show();
                            this.Visible = false;
                            frmprincipal.btnPerfil_Click(sender,e);
                        } //Ocultar el loading
                       
                    }
                    else
                    {
                        MessageBox.Show("¡El usuario o contraseña son incorrectos!");

                    }


                }
                else
                {
          
                    MessageBox.Show("¡Lo sentimos... No hay usuarios registrados!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.Text = "User name";
                    txtPassword.Text = "Password";
                    txtPassword.UseSystemPasswordChar = false;
                }



            }
            else if (txtUsername.Text == "User name" && txtPassword.Text == "Password")
            {
                lblAsteriscoUser.Visible = true;
                txtUsername.ForeColor = Color.Red;
                lblArteriscoPass.Visible = true;
                txtPassword.ForeColor = Color.Red;
            }
            else if(txtUsername.Text == "User name" && txtPassword.Text != "Password")
            {
                lblAsteriscoUser.Visible = true;
                txtUsername.ForeColor = Color.Red;
                lblArteriscoPass.Visible = false;
              
            }
            else if (txtUsername.Text != "User name" && txtPassword.Text == "Password")
            {
                lblAsteriscoUser.Visible = false;
                lblArteriscoPass.Visible = true;
                txtPassword.ForeColor = Color.Red;
            }
            else if (txtUsername.Text == "" && txtPassword.Text == "Password")
            {
                lblAsteriscoUser.Visible = true;
                txtUsername.ForeColor = Color.Red;
                lblArteriscoPass.Visible = true;
                txtPassword.ForeColor = Color.Red;
            }
            else if (txtUsername.Text == "User name" && txtPassword.Text == "")
            {
                lblAsteriscoUser.Visible = true;
                txtUsername.ForeColor = Color.Red;
                lblArteriscoPass.Visible = true;
                txtPassword.ForeColor = Color.Red;
            }

        }

        private void pbOjo_Click(object sender, EventArgs e)
        {
         //   pboxCamara.Image = Properties.Resources.Scanner;  //Regreso a la imagen anterior
            if (txtPassword.UseSystemPasswordChar)
            {
                pbOjo.Image = CajaRegistradoa.Properties.Resources.PassOcultar;
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                pbOjo.Image = CajaRegistradoa.Properties.Resources.PassVer;
                txtPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
