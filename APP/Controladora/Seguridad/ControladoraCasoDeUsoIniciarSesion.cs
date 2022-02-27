using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Controladora.Seguridad
{
    public class ControladoraCasoDeUsoIniciarSesion
    {
        private static ControladoraCasoDeUsoIniciarSesion _Instancia;
        public delegate void ActualizarCambios();
        public event ActualizarCambios AldetectarCambio;
        
        public static ControladoraCasoDeUsoIniciarSesion ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraCasoDeUsoIniciarSesion();
            return _Instancia;
        }
        
        private ControladoraCasoDeUsoIniciarSesion()
        {
        }

        private void ControladoraCasoDeUsoIniciarSesion_RepositorioSeActualizo()
        {
            if (AldetectarCambio != null) AldetectarCambio();
        }
        
        public object IniciarSesion(string nombreUsuario, string clave)
        {
            object operacion = null;
            try
            {
                Entidades.Seguridad.Usuario oUsuario = (Entidades.Seguridad.Usuario)Modelo.Seguridad.Facade.ObtenerInstancia().Buscar("Usuario",nombreUsuario);
                Utilidades.EncriptacionHandler handler = new Utilidades.EncriptacionHandler(new Utilidades.EncriptacionHash(Utilidades.EncriptacionHash.TipoAlgoritmo.SHA512));

                string claveEncriptada = handler.Encriptar(clave);

                byte[] toBytes = System.Text.Encoding.ASCII.GetBytes(claveEncriptada);

                //QFSN9BxS

                if (oUsuario.Clave == claveEncriptada)
                {
                    if (oUsuario.Habilitado == false)
                    {
                        operacion = Entidades.Seguridad.TipoAutenticacion.UsuarioNoHabilitado;
                    }
                    else if (oUsuario.Grupos.Count == 0)
                    {
                        operacion = Entidades.Seguridad.TipoAutenticacion.UsuarioSinGrupo;
                    }
                    else
                    {
                        oUsuario.Activo = true;
                        Modelo.Seguridad.Facade.ObtenerInstancia().Modificar(oUsuario);
                        Entidades.Auditoria.AuditoriaInicioSesion oAudit = new Entidades.Auditoria.AuditoriaInicioSesion();
                        oAudit.Operacion = Entidades.Auditoria.AuditoriaInicioSesion.TipoLog.Ingreso;
                        oAudit.Equipo = Environment.MachineName;
                        oAudit.FechaHora = DateTime.Now;
                        oAudit.Usuario = oUsuario.NombreUsuario;
                        Modelo.Auditoria.CatalogoLogInLogOut.ObtenerInstancia().Registrar(oAudit);
                        Utilidades.AppHandler.GuardarValorDeAppConfig("LastUserLogged",oUsuario.NombreUsuario);
                        Utilidades.AppHandler.GuardarValorDeAppConfig("LastUserLoggedDateTime",oAudit.FechaHora.ToString());
                        Utilidades.AppHandler.GuardarValorDeAppConfig("GoodClose","false");
                        return oUsuario;
                    }
                }
                else
                {
                    operacion = Entidades.Seguridad.TipoAutenticacion.PasswordErroneo;
                }
                if (oUsuario.Activo == true)
                {
                    operacion = Entidades.Seguridad.TipoAutenticacion.UsuarioYaLogueado;
                }
            }
            catch (NullReferenceException)
            {
                operacion = Entidades.Seguridad.TipoAutenticacion.UsuarioDesconocido;
            }
            catch (SqlException ex)
            {
                operacion = ex;
            }
            catch (Exception ex)
            {
                operacion = ex;
            }
            return operacion;
        }
        
        public object RecuperarPerfilesUsuario(Entidades.Seguridad.Usuario oUsuario)
        {
            try
            {   
                return Modelo.Seguridad.Facade.ObtenerInstancia().RecuperarPerfilesGrupos(oUsuario);
            }
            catch (Exception error)
            {
                Utilidades.EventManager.RegistarErrores(error);
                return error;
            }
        }
    }
}
