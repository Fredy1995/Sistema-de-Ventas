using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CajaRegistradora;
using System.IO;

namespace CajaRegistradoa
{
    public partial class FormAjustes : Form
    {
        private string Pathtxt = @"C:\DataBaseSV\StatusCamara.txt"; //Archivo de texto

        public  FormAjustes()
        {
          
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void PBoxMenu_Click(object sender, EventArgs e)
        {
            if(MenuVertical.Width == 75)
            {
                MenuVertical.Width = 200;
            }
            else
            {
                MenuVertical.Width = 75;
            }
        }
     
        private void panelContenedor_MouseDown(object sender, MouseEventArgs e)
        {
          
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
       
        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            string NameForm = "Regresar";
            AbrirFormularios(NameForm);
        }
        //*********************Botones del menu *******************************
        private void AbrirFormDatosTienda(object FormDatosTienda)
        {

            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form frmDT = FormDatosTienda as Form;
            frmDT.TopLevel = false;
            frmDT.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(frmDT);
            this.panelContenedor.Tag = frmDT;
            frmDT.Show();
            //Deshabilitar o habilitar controles
            btnDatosEmpresa.Enabled = false;
            btnRegistrarse.Enabled = true;
            btnRecuperarPass.Enabled = true;
            btnAcerca.Enabled = true;

        }
        private void AbrirFormularios(string NameForm)
        {
            if (File.Exists(Pathtxt))
            {
                //lee el archivo línea por línea
                StreamReader flujoEntrada = File.OpenText(Pathtxt);
                string linea;
                linea = flujoEntrada.ReadLine();
                if (linea == "1")
                {
                    MessageBox.Show("Puede hacerlo dando clic en Capturar", "¡Olvidó a pagar la camara!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if(NameForm == "DatosEmpresa")
                    {
                        AbrirFormDatosTienda(new FormDatosTienda());
                    }else if (NameForm == "RecuperarPass")
                    {
                        AbrirFormPassword(new FormPassword());
                    }
                    else if (NameForm == "AcercaD")
                    {
                        AbrirFormAcercaDe(new FormAcercaDe());
                    }
                    else if (NameForm == "Regresar")
                    {
                        FormLogin Login = new FormLogin();
                        Login.Show();
                        this.Close();
                    }

                }

                flujoEntrada.Close();


            }
            else
            {
                if (NameForm == "DatosEmpresa")
                {
                    AbrirFormDatosTienda(new FormDatosTienda());
                }
                else if (NameForm == "RecuperarPass")
                {
                    AbrirFormPassword(new FormPassword());
                }
                else if (NameForm == "AcercaD")
                {
                    AbrirFormAcercaDe(new FormAcercaDe());
                }
                else if (NameForm == "Regresar")
                {
                    FormLogin Login = new FormLogin();
                    Login.Show();
                    this.Close();
                }
            }
        }
        private void btnDatosEmpresa_Click(object sender, EventArgs e)
        {
            string NameForm = "DatosEmpresa";
            AbrirFormularios(NameForm);
        }
        
        private void AbrirFormRegistrar(object FormResgistrarse)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form frmDT = FormResgistrarse as Form;
            frmDT.TopLevel = false;
            frmDT.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(frmDT);
            this.panelContenedor.Tag = frmDT;
            frmDT.Show();
        }
        public void btnRegistrarse_Click(object sender, EventArgs e)
        {
           AbrirFormRegistrar(new FormResgistrarse());
            btnDatosEmpresa.Enabled = true;
            btnRegistrarse.Enabled = false;
            btnRecuperarPass.Enabled = true;
            btnAcerca.Enabled = true;
           
        }

        private void AbrirFormPassword(object FormPassword)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form frmDT = FormPassword as Form;
            frmDT.TopLevel = false;
            frmDT.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(frmDT);
            this.panelContenedor.Tag = frmDT;
            frmDT.Show();
            //Deshabilitar o habilitar controles
            btnDatosEmpresa.Enabled = true;
            btnRegistrarse.Enabled = true;
            btnRecuperarPass.Enabled = false;
            btnAcerca.Enabled = true;
        }
        private void btnRecuperarPass_Click(object sender, EventArgs e)
        {
            string NameForm = "RecuperarPass";
            AbrirFormularios(NameForm);
        }
        private void AbrirFormAcercaDe(object FormAcercaDe)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form frmDT = FormAcercaDe as Form;
            frmDT.TopLevel = false;
            frmDT.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(frmDT);
            this.panelContenedor.Tag = frmDT;
            frmDT.Show();
            //Deshabilitar o habilitar controles
            btnDatosEmpresa.Enabled = true;
            btnRegistrarse.Enabled = true;
            btnRecuperarPass.Enabled = true;
            btnAcerca.Enabled = false;
        }
        
        public void btnAcerca_Click(object sender, EventArgs e)
        {
            string NameForm = "AcercaD";
            AbrirFormularios(NameForm);
        }

        private void FormAjustes_Load(object sender, EventArgs e)
        {
          

        }
        //*********************Botones fin *******************************
    }
}
