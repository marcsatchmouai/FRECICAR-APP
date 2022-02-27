using System;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    class App : ApplicationContext
    {
        private enum Comando
        {
            Encriptar, Desencriptar
        }

        private ResourceManager resmgr;
        
        private bool VerificarArgumentosLineasDeComando()
        {
            bool ArgumentoCorrecto = false;
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                if (args[1] == Controladora.ControladoraCasoDeUsoIniciarAplicacion.ObtenerEncryptionString() && args.Length >= 3)
                {
                    for (int i = 2; i < args.Length; i++)
                    {
                        if (args[i] == Comando.Encriptar.ToString())
                        {
                            Controladora.ControladoraCasoDeUsoIniciarAplicacion.EncriptarAPP();
                            Controladora.ControladoraCasoDeUsoIniciarAplicacion.EncriptarCS();
                            ArgumentoCorrecto = true;
                        }
                        else if (args[i] == Comando.Desencriptar.ToString())
                        {
                            Controladora.ControladoraCasoDeUsoIniciarAplicacion.DesencriptarAPP();
                            Controladora.ControladoraCasoDeUsoIniciarAplicacion.DesencriptarCS();
                            ArgumentoCorrecto = true; 
                        }
                    }
                }
                else ArgumentoCorrecto = true;
            }
            else
            {
                ArgumentoCorrecto = false;
            }
            return ArgumentoCorrecto;
        }

        private bool VerificarSiAplicacionEstaEjecutando()
        {
            string processName = Process.GetCurrentProcess().ProcessName;
            Process[] instances = Process.GetProcessesByName(processName);
            if (instances.Length > 1)
            {
                return true;
            }
            else return false;
        }

        private void VerificarParametrosInicio()
        {
            bool FirstRun = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["FirstRun"]);
            string idioma = System.Configuration.ConfigurationManager.AppSettings["CurrentLanguage"].ToString();
            System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfoByIetfLanguageTag(idioma);
            if (FirstRun)
            {
            //    Parametros.FormParametros oFormParametros = new Parametros.FormParametros();
            //    oFormParametros.Show();
            }
            else
            {
                if (!Controladora.ControladoraCasoDeUsoIniciarAplicacion.VerificarCierreSesionCorrecto()) MessageBox.Show("El sistema no se ha cerrado correctamente, verifique los registros de auditoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Seguridad.FormLogin oFormLogon = new Seguridad.FormLogin();
                oFormLogon.Show();
            }
        }

        public App()
        {
            resmgr = new ResourceManager("PlasticosRefine.App", typeof(Program).Assembly);
            if (VerificarSiAplicacionEstaEjecutando()) Environment.Exit(0);
            if (VerificarArgumentosLineasDeComando()) Environment.Exit(0);
            VerificarParametrosInicio();
            InicializarCatalogos();
        }

        private  void InicializarCatalogos()
        {
            Task.Run(() => Correr());
        }

        private void Correr()
        {
            Controladora.Sistema.ControladoraPago.ObtenerInstancia().Listar();
        }
    }
}
