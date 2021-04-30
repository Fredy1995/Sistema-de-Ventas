using CajaRegistradora;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaRegistradoa
{
    public partial class FormPrincipal : Form
    {
        
        private string Pathtxt = @"C:\DataBaseSV\StatusCamara.txt"; //Archivo de texto
        private double IdUsuario;
        public FormPrincipal(double iduser)
        {
            InitializeComponent();
            this.IdUsuario = iduser;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            playExclamation();
            string NameForm = "CerrarSesion";
            AbrirFormularios(NameForm);     
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
           
            if (panelVertical.Width == 80)
            {
                panelVertical.Width = 232;
            }
            else
            {
                panelVertical.Width = 80;
            }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHoraActiva.Text = "Hora: "+ DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void AbrirFormMiPerfil(object FormPerfil)  //Metodo para mostrar el Formulario Perfil dentro del panel principal
        {
            if (this.pnlContenidoPrincipal.Controls.Count > 0)
                this.pnlContenidoPrincipal.Controls.RemoveAt(0);
            Form frmPerfil = FormPerfil as Form;
            frmPerfil.TopLevel = false;
            frmPerfil.Dock = DockStyle.Fill;
            this.pnlContenidoPrincipal.Controls.Add(frmPerfil);
            this.pnlContenidoPrincipal.Tag = frmPerfil;
            frmPerfil.Show();
            //Habilitar y deshabilitar controles
            btnPerfil.Enabled = false;
            btnPuntoVenta.Enabled = true;
            btnInventario.Enabled = true;
            btnVentas.Enabled = true;
            btnEnCaja.Enabled = true;
            btnCodigosQR.Enabled = true;
        }
        private void btnPerfil_Click(object sender, EventArgs e)
        {
            string NameForm = "Perfil";
            AbrirFormularios(NameForm);
        }
        private void AbrirFormPuntoVenta(object FormPuntoVenta)  
        {
            if (this.pnlContenidoPrincipal.Controls.Count > 0)
                this.pnlContenidoPrincipal.Controls.RemoveAt(0);
            Form frmPV = FormPuntoVenta as Form;
            frmPV.TopLevel = false;
            frmPV.Dock = DockStyle.Fill;
            this.pnlContenidoPrincipal.Controls.Add(frmPV);
            this.pnlContenidoPrincipal.Tag = frmPV;
            frmPV.Show();
            //Habilitar y deshabilitar controles
            btnPerfil.Enabled = true;
            btnPuntoVenta.Enabled = false;
            btnInventario.Enabled = true;
            btnVentas.Enabled = true;
            btnEnCaja.Enabled = true;
            btnCodigosQR.Enabled = true;

        }
        private void btnPuntoVenta_Click(object sender, EventArgs e)
        {
            string NameForm = "PuntoVenta";
            AbrirFormularios(NameForm);
        }
        private void AbrirFormInventario(object FormInventario)
        {
            if (this.pnlContenidoPrincipal.Controls.Count > 0)
                this.pnlContenidoPrincipal.Controls.RemoveAt(0);
            Form frmI = FormInventario as Form;
            frmI.TopLevel = false;
            frmI.Dock = DockStyle.Fill;
            this.pnlContenidoPrincipal.Controls.Add(frmI);
            this.pnlContenidoPrincipal.Tag = frmI;
            frmI.Show();
            //Habilitar y deshabilitar controles
            btnPerfil.Enabled = true;
            btnPuntoVenta.Enabled = true;
            btnInventario.Enabled = false;
            btnVentas.Enabled = true;
            btnEnCaja.Enabled = true;
            btnCodigosQR.Enabled = true;
        }
        private void btnInventario_Click(object sender, EventArgs e)
        {

            string NameForm = "Inventario";
            AbrirFormularios(NameForm);

        }
        public void playExclamation() //Sonido de Exclamation
        {
            SystemSounds.Question.Play();
        }
        //Metodo para abrir formularios
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
                    flujoEntrada.Dispose();
                    flujoEntrada.Close();
                    MessageBox.Show("Puede hacerlo dando clic en OFF", "¡Olvidó a pagar la camara!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    flujoEntrada.Dispose();
                    flujoEntrada.Close();
                    if (NameForm == "Perfil")
                    {
                        AbrirFormMiPerfil(new FormPerfil(IdUsuario));
                       
                    }
                    else if (NameForm == "PuntoVenta")
                    {
                        AbrirFormPuntoVenta(new FormPuntoVenta(IdUsuario));
                        
                    }
                    else if (NameForm == "Inventario")
                    {
                        AbrirFormInventario(new FormInventario());
                        
                    }
                    else if (NameForm == "EnCaja")
                    {
                        AbrirFormEnCaja(new FormCaja(IdUsuario));

                    }
                    else if (NameForm == "CodigosQR")
                    {
                        AbrirFormCodigosQR(new FormQR());
                       
                    }
                    else if (NameForm == "CerrarSesion")
                    {
                       
                        DialogResult r = MessageBox.Show("¿Esta seguro de salir?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            FormLogin Login = new FormLogin();
                            Login.Show();
                            this.Close();
                        }
                       
                    }


                }

                //flujoEntrada.Close();


            }
            else
            {
                if (NameForm == "Perfil")
                {
                    AbrirFormMiPerfil(new FormPerfil(IdUsuario));
                }
                else if (NameForm == "PuntoVenta")
                {
                    AbrirFormPuntoVenta(new FormPuntoVenta(IdUsuario));
                }
                else if (NameForm == "Inventario")
                {
                    AbrirFormInventario(new FormInventario());

                }
                else if (NameForm == "EnCaja")
                {
                    AbrirFormEnCaja(new FormCaja(IdUsuario));

                }
                else if (NameForm == "CodigosQR")
                {
                    AbrirFormCodigosQR(new FormQR());
                }
                else if (NameForm == "CerrarSesion")
                {
                    
                    DialogResult r = MessageBox.Show("¿Esta seguro de salir?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        FormLogin Login = new FormLogin();
                        Login.Show();
                        this.Close();
                    }
                }

            }
        }
        private void AbrirFormCodigosQR(object FormQR)
        {
            if (this.pnlContenidoPrincipal.Controls.Count > 0)
                this.pnlContenidoPrincipal.Controls.RemoveAt(0);
            Form frmQR = FormQR as Form;
            frmQR.TopLevel = false;
            frmQR.Dock = DockStyle.Fill;
            this.pnlContenidoPrincipal.Controls.Add(frmQR);
            this.pnlContenidoPrincipal.Tag = frmQR;
            frmQR.Show();
            //Habilitar y deshabilitar controles
            btnPerfil.Enabled = true;
            btnPuntoVenta.Enabled = true;
            btnInventario.Enabled = true;
            btnVentas.Enabled = true;
            btnEnCaja.Enabled = true;
            btnCodigosQR.Enabled = false;
        }
        private void btnCodigosQR_Click(object sender, EventArgs e)
        {
            string NameForm = "CodigosQR";
            AbrirFormularios(NameForm);
        }
        private void AbrirFormEnCaja(object FormCaja)
        {
            if (this.pnlContenidoPrincipal.Controls.Count > 0)
                this.pnlContenidoPrincipal.Controls.RemoveAt(0);
            Form frmCaja = FormCaja as Form;
            frmCaja.TopLevel = false;
            frmCaja.Dock = DockStyle.Fill;
            this.pnlContenidoPrincipal.Controls.Add(frmCaja);
            this.pnlContenidoPrincipal.Tag = frmCaja;
            frmCaja.Show();
            //Habilitar y deshabilitar controles
            btnPerfil.Enabled = true;
            btnPuntoVenta.Enabled = true;
            btnInventario.Enabled = true;
            btnVentas.Enabled = true;
            btnEnCaja.Enabled = false;
            btnCodigosQR.Enabled = true;
        }
        private void btnEnCaja_Click(object sender, EventArgs e)
        {
            string NameForm = "EnCaja";
            AbrirFormularios(NameForm);
        }
    }
}
