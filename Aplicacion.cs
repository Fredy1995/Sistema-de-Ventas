using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CajaRegistradora;
using Microsoft.VisualBasic.ApplicationServices;
namespace CajaRegistradoa
{
    class Aplicacion : WindowsFormsApplicationBase
    {
        protected override void OnCreateSplashScreen()
        {
            base.OnCreateSplashScreen();
            //Pantalla de presentación
            this.SplashScreen = new FormPantallaPresentación(); ;
            this.MinimumSplashScreenDisplayTime = 3000;
            this.IsSingleInstance = true;
        }
        protected override void OnCreateMainForm()
        {
            base.OnCreateMainForm();
            this.MainForm = new FormLogin();
            //Argumentos en la linea de ordenes
            if (this.CommandLineArgs.Count > 0)
            {
                if (this.CommandLineArgs[0] == "/max" || this.CommandLineArgs[0] == "-max")
                    this.MainForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
        }
    }
}
