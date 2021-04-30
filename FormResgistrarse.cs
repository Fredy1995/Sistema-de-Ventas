using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO;
using System.Drawing.Imaging;
using SpreadsheetLight;

namespace CajaRegistradoa
{
    public partial class FormResgistrarse : Form
    {
        private string PathF = @"C:\DataBaseSV\Fotos\"; //Directorio para foto
        private string PathA = @"C:\DataBaseSV\Archivos\"; //Directorio para Archivos
        private string Pathtxt = @"C:\DataBaseSV\StatusCamara.txt"; //Archivo de texto 
        private bool  SeInicioCamara,Capturofoto;
        public bool HayDispositivos;
        private FilterInfoCollection MisDispositivos;
        private VideoCaptureDevice MiWebCam;
        private double Id;
        public FormResgistrarse()
        {
            InitializeComponent();
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "---------------------------------------------")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.DimGray;
            }
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "")
            {
                txtNombre.Text = "---------------------------------------------";
                txtNombre.ForeColor = Color.Silver;
            }
        }

        private void txtPaterno_Enter(object sender, EventArgs e)
        {
            if (txtPaterno.Text == "Paterno")
            {
                txtPaterno.Text = "";
                txtPaterno.ForeColor = Color.DimGray;
            }
        }

       

        private void txtPaterno_Leave(object sender, EventArgs e)
        {
            if (txtPaterno.Text == "")
            {
                txtPaterno.Text = "Paterno";
                txtPaterno.ForeColor = Color.Silver;
            }
        }
        private void txtMaterno_Enter(object sender, EventArgs e)
        {
            if (txtMaterno.Text == "Materno")
            {
                txtMaterno.Text = "";
                txtMaterno.ForeColor = Color.DimGray;
            }
        }
        private void txtMaterno_Leave(object sender, EventArgs e)
        {
            if (txtMaterno.Text == "")
            {
                txtMaterno.Text = "Materno";
                txtMaterno.ForeColor = Color.Silver;
            }
        }

       

       

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "User name")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "User name";
                txtUsuario.ForeColor = Color.Silver;
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Password")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.DimGray;
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = false;
                txtContraseña.ForeColor = Color.DimGray;
            }
             

               
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "Password";
                txtContraseña.UseSystemPasswordChar = false;
                txtContraseña.ForeColor = Color.Silver;
            }
            else
            {

                txtContraseña.UseSystemPasswordChar = true;
                txtContraseña.ForeColor = Color.DimGray;
            }
                
            
        }

        public static int CalcularEdad(DateTime fechaNacimiento)
        {
            // Obtiene la fecha actual:
            DateTime fechaActual = DateTime.Today;

            // Comprueba que la se haya introducido una fecha válida; si 
            // la fecha de nacimiento es mayor a la fecha actual se muestra mensaje 
            // de advertencia:
            if (fechaNacimiento > fechaActual)
            {
                
                MessageBox.Show("La fecha de nacimiento es mayor que la actual.");
                return -1;
            }
            else
            {
                int edad = fechaActual.Year - fechaNacimiento.Year;

                // Comprueba que el mes de la fecha de nacimiento es mayor 
                // que el mes de la fecha actual:
                if (fechaNacimiento.Month > fechaActual.Month)
                {
                    --edad;
                }

                return edad;
            }
        }

        private void Capturando(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap imagen = (Bitmap)eventArgs.Frame.Clone();
            pbFoto.Image = imagen;
        }
        public void CargaDispositivos()
        {
            MisDispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (MisDispositivos.Count > 0)
            {
                HayDispositivos = true;
                for (int i = 0; i < MisDispositivos.Count; i++)
                {
                    cbDispositivos.Items.Add(MisDispositivos[i].Name.ToString());
                    cbDispositivos.Text = MisDispositivos[0].Name.ToString();
                }
            }
            else
            {
                HayDispositivos = false;
            }
        }
        private void FormResgistrarse_Load(object sender, EventArgs e)
        {
          
                CargaDispositivos(); //Cargo los dispositivos de camara
                lblFecha.Text = DateTime.Today.Date.ToString("d");
                txtNombre.Focus();
                txtID.Text = Convert.ToString(DevuelveIDNoRepetido());
          
           
              
        }
        public double DevuelveIDNoRepetido()
        {
            Random rnd = new Random();
            string rutaArchivoCompleta = PathA + "Usuarios.xlsx";
            Id = rnd.Next(100000, 200001);
           
            if (File.Exists(rutaArchivoCompleta)) //Pregrunto si el archivo existe
            {
                SLDocument ArchivoExcel = new SLDocument(rutaArchivoCompleta);
                int iRow = 2;

                while (!string.IsNullOrEmpty(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                {
                    
                    if (Id == Convert.ToDouble(ArchivoExcel.GetCellValueAsString(iRow, 1)))
                    {
                        Id = rnd.Next(100000, 200001);
                        iRow = 1;
                    }
                    iRow++;
                }
                
            }

           
             return Id;
        }

        private void dFecha_Leave(object sender, EventArgs e)
        {
            DateTime fechanacimiento = dFecha.Value;
            txtEdad.Text = Convert.ToString(CalcularEdad(fechanacimiento));
        }
        public void CerrarWebCam()
        {
         
                if (MiWebCam != null & MiWebCam.IsRunning)
                {
                    MiWebCam.SignalToStop();
                    MiWebCam = null;
                }
           
        }
     
        public void btnCapturar_Click(object sender, EventArgs e)
        {
            if (btnCapturar.Enabled)
            {
                MiWebCam.SignalToStop(); //Detener la camara
                MiWebCam = null;
                pbFoto.Image = pbFoto.Image;
                 btnCapturar.Enabled = false;
                 btnEncender.Enabled = true;
                SeInicioCamara = false;
                btnGuardar.Enabled = true;
                Capturofoto = true;
                GuardarEstadoCamara(SeInicioCamara); //Mando el estado de la Camara

            }
            
        }
      

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string rutaArchivoCompleta = PathA + "Usuarios.xlsx";
              DateTime fechanacimiento = dFecha.Value;
            string Fnacimiento = fechanacimiento.Date.ToString("d"),FRegistro = DateTime.Today.Date.ToString("d");
           
            CrearExcelUsuarios CEU = new CrearExcelUsuarios(Id, txtUsuario.Text, txtContraseña.Text, FRegistro, txtNombre.Text, txtPaterno.Text, txtMaterno.Text, txtEdad.Text, Fnacimiento, rutaArchivoCompleta);
            if (txtNombre.Text != "---------------------------------------------" && txtPaterno.Text != "Paterno" && txtMaterno.Text != "Materno" && txtEdad.Text != "" && txtUsuario.Text != "User name" && txtContraseña.Text != "Password" && Capturofoto)
            {
                if (File.Exists(rutaArchivoCompleta))
                {
                    //El archivo existe, entonces agrego el nuevo usuario al archivo Excel

                    CEU.AddUserToExcel();
                    //Guardo foto con nombre de ID correspondiente
                    pbFoto.Image.Save(PathF + Id + ".jpg", ImageFormat.Jpeg);
                    //LimpiarTextbox
                    txtNombre.Text = "";
                    txtPaterno.Text = "";
                    txtMaterno.Text = "";
                    txtID.Text = "";
                    txtEdad.Text = "";
                    txtUsuario.Text = "";
                    txtContraseña.Text = "";
                    dFecha.Value = new DateTime(1985, 01, 01);
                    //pbFoto.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Imagenes/WebCam.jfif");
                    pbFoto.Image = Properties.Resources.WebCam;
                    btnGuardar.Enabled = false;
                }
                else
                {
                    //Si no existe el archivo Usuarios.xlsx entonces se crea por primera vez
                  
                    CEU.CrearExcelU();
                    //Guardo foto con nombre de ID correspondiente
                    pbFoto.Image.Save(PathF + Id +".jpg", ImageFormat.Jpeg);
                    //LimpiarTextbox
                    txtNombre.Text = "";
                    txtPaterno.Text = "";
                    txtMaterno.Text = "";
                    txtID.Text = "";
                    txtEdad.Text = "";
                    txtUsuario.Text = "";
                    txtContraseña.Text = "";
                    dFecha.Value = new DateTime(1985, 01, 01);
                    //pbFoto.Image = Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "/Imagenes/WebCam.jfif");
                    pbFoto.Image = Properties.Resources.WebCam;
                    btnGuardar.Enabled = false;
                }
                Capturofoto = false;

            }
            else
            {
                MessageBox.Show("¡Es necesario llenar todos los campos! "); 
            }
           
             
        }

     
        private void cbDispositivos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SeInicioCamara)
            {
                if (cbDispositivos.SelectedIndex > -1)
                {
                    CerrarWebCam();
                    btnEncender.Enabled = true;
                   
                }
            }
           
        }
       /* public bool EstadoCamara()
        {
            return SeInicioCamara;
        }*/

      

        private void btnEncender_Click(object sender, EventArgs e)
        {
           
                int i = cbDispositivos.SelectedIndex;
                string NombreVideo = MisDispositivos[i].MonikerString;
                MiWebCam = new VideoCaptureDevice(NombreVideo);
                MiWebCam.NewFrame += new NewFrameEventHandler(Capturando);
                MiWebCam.Start();
            
                btnCapturar.Enabled = true;
                btnEncender.Enabled = false;
                SeInicioCamara = true;
                btnGuardar.Enabled = false; //Si esta activa la camara entonces el boton Guardar estara deshabilitado, hasta que se tome una captura

            GuardarEstadoCamara(SeInicioCamara); //Mando el estado de la Camara 
        }
       private void GuardarEstadoCamara(bool CamaraActiva) //Metodo que guarda el estado de la camara en un archivo de texto, para depues poder obtenerlo
        {
            
            if (File.Exists(Pathtxt))
            {
                StreamWriter flujoSalida = File.CreateText(Pathtxt);
                if (CamaraActiva)
                {
                    flujoSalida.WriteLine("1\n- No borrar o cambiar el valor  1\n- NO ELIMINAR EL ARCHIVO!");
                }
                else
                {
                    flujoSalida.WriteLine("0\n- No borrar o cambiar el valor  0\n- NO ELIMINAR EL ARCHIVO!");
                }
              
                flujoSalida.Close();
            }
            else
            {
                using (FileStream fs = File.Create(Pathtxt)) ///Si no existe el archivo se crea
                {
                    if (CamaraActiva)
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes("1\n- No borrar o cambiar el valor  1\n- NO ELIMINAR EL ARCHIVO!");
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                    else
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes("0\n- No borrar o cambiar el valor  1\n- NO ELIMINAR EL ARCHIVO!");
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                       
                   
                }
            }
        }

    }
}
