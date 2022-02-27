using System;
using System.Configuration;
namespace Controladora.Seguridad
{
	public class ControladoraCasoDeUsoConfigurarMail
	{
        private static ControladoraCasoDeUsoConfigurarMail _Instancia = null;
        private Entidades.Seguridad.DatosCorreo _DatosCorreo = null;

        public static ControladoraCasoDeUsoConfigurarMail ObtenerInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new ControladoraCasoDeUsoConfigurarMail();
            }
            return _Instancia;
        }
        
        public Entidades.Seguridad.DatosCorreo DatosCorreo
        {
            get { return _DatosCorreo; }
        }

        public Entidades.Seguridad.DatosCorreo RecuperarDatosCorreo()
        {
            Entidades.Seguridad.DatosCorreo oDatosCorreo = new Entidades.Seguridad.DatosCorreo();
            oDatosCorreo.DireccionMail = Utilidades.AppHandler.ObtenerStringDeAppConfig("MailAddress");
            oDatosCorreo.Smtp = Utilidades.AppHandler.ObtenerStringDeAppConfig("SMTP");
            oDatosCorreo.PuertoSmtp = Convert.ToInt32(Utilidades.AppHandler.ObtenerStringDeAppConfig("SMTPPORT"));
            oDatosCorreo.UsaCredencialesDefault = Convert.ToBoolean(Utilidades.AppHandler.ObtenerStringDeAppConfig("UseDefaultCredentials"));
            oDatosCorreo.Usuario = Utilidades.AppHandler.ObtenerStringDeAppConfig("Usuario").ToString();
            oDatosCorreo.Clave = Utilidades.AppHandler.ObtenerStringDeAppConfig("Clave");
            oDatosCorreo.SSL = Convert.ToBoolean(Utilidades.AppHandler.ObtenerStringDeAppConfig("EnableSSL"));
            oDatosCorreo.NombreEmisor = Utilidades.AppHandler.ObtenerStringDeAppConfig("NombreEmisor");
            return oDatosCorreo;
        }

        public bool ProbarDatos(Entidades.Seguridad.DatosCorreo oDatosCorreo)
        {  
            return Utilidades.MailSender.EnviarMail(oDatosCorreo.DireccionMail,"Prueba de Configuracion Exitosa","Prueba de Configuracion de SMTP", oDatosCorreo.Usuario, oDatosCorreo.NombreEmisor, oDatosCorreo.DireccionMail, oDatosCorreo.Clave, oDatosCorreo.Smtp, oDatosCorreo.PuertoSmtp, oDatosCorreo.SSL, oDatosCorreo.UsaCredencialesDefault);
        }

        public bool ModificarDatosCorreo(Entidades.Seguridad.DatosCorreo oDatosCorreo)
        {
            if (ProbarDatos(oDatosCorreo))
            {
                return GuardarDatos(oDatosCorreo);   
            }
            else return false;
        }

        private bool GuardarDatos(Entidades.Seguridad.DatosCorreo oDatosCorreo)
        {
            try
            {
            Utilidades.AppHandler.GuardarValorDeAppConfig("MailAddress",oDatosCorreo.DireccionMail);
            Utilidades.AppHandler.GuardarValorDeAppConfig("Clave",oDatosCorreo.Clave);
            Utilidades.AppHandler.GuardarValorDeAppConfig("NombreEmisor",oDatosCorreo.NombreEmisor);
            Utilidades.AppHandler.GuardarValorDeAppConfig("SMTPPORT",oDatosCorreo.PuertoSmtp.ToString());
            Utilidades.AppHandler.GuardarValorDeAppConfig("SMTP",oDatosCorreo.Smtp);
            Utilidades.AppHandler.GuardarValorDeAppConfig("EnableSSL",oDatosCorreo.SSL.ToString());
            Utilidades.AppHandler.GuardarValorDeAppConfig("UseDefaultCredentials",oDatosCorreo.UsaCredencialesDefault.ToString());
            Utilidades.AppHandler.GuardarValorDeAppConfig("Usuario",oDatosCorreo.Usuario);
            return true;
            }  
            catch(Exception ex)
            {
                Utilidades.EventManager.RegistarErrores(ex);
                return false;
            }
        }
        
        public bool VerificarCorreo()
        {
            if (_DatosCorreo != null) return true;
            else return false;
        }

    }
}
