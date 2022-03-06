using System;

namespace Controladora.Seguridad
{
    public static class ControladoraCasoDeUsoCambiarClave
    {
        public static object CambiarClave(Entidades.Seguridad.Usuario oUsuario, string claveVieja, string claveNueva)
        {
            try
            {
                Utilidades.EncriptacionHandler handler = new Utilidades.EncriptacionHandler(new Utilidades.EncriptacionHash(Utilidades.EncriptacionHash.TipoAlgoritmo.SHA512));

                string claveViejaEncriptada = handler.Encriptar(claveVieja);
                string claveNuevaEncriptada = handler.Encriptar(claveNueva);
                if (oUsuario.CambiarClave(claveViejaEncriptada, claveNuevaEncriptada))
                {
                    if (Modelo.Seguridad.Facade.ObtenerInstancia().Modificar(Modelo.Seguridad.Facade.ObtenerInstancia().Buscar("Usuario", oUsuario.NombreUsuario)))
                        return true;
                    else return false;
                }
                else return false;
            }
            catch(Exception ex)
            {
                Utilidades.EventManager.RegistarErrores(ex);
                return ex;
            }
        }

        public static string VerificarUsuario()
        {
            return Utilidades.AppHandler.ObtenerStringDeAppConfig("SuperUser");
        }
    }
}
