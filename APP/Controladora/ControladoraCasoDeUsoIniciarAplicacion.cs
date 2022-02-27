using System;
using System.Configuration;

namespace Controladora
{
    public static class ControladoraCasoDeUsoIniciarAplicacion
    {
        public static void EncriptarCS()
        {
         //   Utilidades.;
        }
        
        public static void DesencriptarCS()
        {
         //   Utilidades.Encriptacion.DesencriptarConnectionStrings();
        }
        
        public static void EncriptarAPP()
        {
          //  Utilidades.Encriptacion.EncriptarAppSettings();
        }
        
        public static void DesencriptarAPP()
        {
           // Utilidades.Encriptacion.DesencriptarAppSettings();
        }
        
        public static string ObtenerEncryptionString()
        {
            return ConfigurationManager.AppSettings["EncryptionString"].ToString(); 
        }
        
        public static bool VerificarCierreSesionCorrecto()
        {
            bool operacion = false;
            bool CierreCorrecto = Convert.ToBoolean(Utilidades.AppHandler.ObtenerStringDeAppConfig("GoodClose"));
            if (CierreCorrecto) operacion = true;
            else
            {
                string usuario = Utilidades.AppHandler.ObtenerStringDeAppConfig("LastUserLogged");
                string fechaHora = Utilidades.AppHandler.ObtenerStringDeAppConfig("LastUserLoggedDateTime");
                Entidades.Auditoria.AuditoriaInicioSesion oAudit = new Entidades.Auditoria.AuditoriaInicioSesion();
                if (fechaHora == "") fechaHora = DateTime.Now.ToString();
                if (usuario == "") usuario = "_";
                oAudit.Usuario = usuario;
                oAudit.FechaHora = Convert.ToDateTime(fechaHora);
                oAudit.Equipo = Environment.MachineName;
                oAudit.Operacion = Entidades.Auditoria.AuditoriaInicioSesion.TipoLog.Erroneo;
                Entidades.Seguridad.Usuario usuarioYaLogueado =(Entidades.Seguridad.Usuario) Modelo.Seguridad.Facade.ObtenerInstancia().Buscar("Usuario",usuario);
                usuarioYaLogueado.Activo = false;
                Modelo.Seguridad.Facade.ObtenerInstancia().Modificar(usuarioYaLogueado);
                Modelo.Auditoria.CatalogoLogInLogOut.ObtenerInstancia().Registrar(oAudit);
                operacion = false;
            }
            return operacion;
        }
    }
}
