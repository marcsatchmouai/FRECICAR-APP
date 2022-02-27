using System;
using System.Data.SqlClient;

namespace Controladora.Seguridad
{
    public class ControladoraCasoDeUsoCerrarSesion
    {
        private static ControladoraCasoDeUsoCerrarSesion _Instancia;
        
        public static ControladoraCasoDeUsoCerrarSesion ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraCasoDeUsoCerrarSesion();
            return _Instancia;
        }
        
        private ControladoraCasoDeUsoCerrarSesion()
        {
           
        }
        
        public void CerrarSesion(Entidades.Seguridad.Usuario usuario)
        {
            try
            {
                Entidades.Auditoria.AuditoriaInicioSesion auditoria = new Entidades.Auditoria.AuditoriaInicioSesion();
                auditoria.Equipo = Environment.MachineName;
                auditoria.FechaHora = DateTime.Now;
                auditoria.Operacion = Entidades.Auditoria.AuditoriaInicioSesion.TipoLog.Egreso;
                auditoria.Usuario = usuario.NombreUsuario;
                Modelo.Auditoria.CatalogoLogInLogOut.ObtenerInstancia().Registrar(auditoria);
                Entidades.Seguridad.Usuario usu = (Entidades.Seguridad.Usuario)Modelo.Seguridad.Facade.ObtenerInstancia().Buscar("Usuario",usuario.NombreUsuario);
                usu.Activo = false;
                Modelo.Seguridad.Facade.ObtenerInstancia().Modificar(usu);
                Utilidades.AppHandler.GuardarValorDeAppConfig("GoodClose", "true");

            }
            catch(Exception ex)
            {
                Utilidades.EventManager.RegistarErrores(ex);
            }
        }
    }
}
