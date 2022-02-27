using System;
using System.Collections.ObjectModel;

namespace Controladora.Seguridad
{
    public class ControladoraCasoDeUsoGestionarUsuarios
    {
        private static ControladoraCasoDeUsoGestionarUsuarios _Instancia;
        public delegate void ActualizarCambios();
        public  event ActualizarCambios AldetectarCambio;
        
        public static ControladoraCasoDeUsoGestionarUsuarios ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraCasoDeUsoGestionarUsuarios();
            return ControladoraCasoDeUsoGestionarUsuarios._Instancia;
        }

        private ControladoraCasoDeUsoGestionarUsuarios()
        {
        }

        void ControladoraCasoDeUsoGestionarUsuarios_RepositorioSeActualizo()
        {
            if (AldetectarCambio != null) AldetectarCambio();
        }
	
	    public bool ResetearContraseña(string usuarioMail)
        {
            Utilidades.EncriptacionHandler handler = new Utilidades.EncriptacionHandler(new Utilidades.EncriptacionHash(Utilidades.EncriptacionHash.TipoAlgoritmo.SHA512));
            Entidades.Seguridad.Usuario oUsuario = (Entidades.Seguridad.Usuario) Modelo.Seguridad.Facade.ObtenerInstancia().Buscar("Usuario",usuarioMail);
            if (oUsuario != null)
            {
                if (oUsuario.NombreUsuario != Utilidades.AppHandler.ObtenerStringDeAppConfig("SuperUser"))
                {
                    string nuevaPass = Utilidades.GenerarPassword.CrearContraseñaAleatoria(8);
                    string nuevaPassEncriptada = handler.Encriptar(nuevaPass);
                    oUsuario.CambiarClave(oUsuario.Clave, nuevaPassEncriptada);
                    if (Modelo.Seguridad.Facade.ObtenerInstancia().Modificar(oUsuario))
                    {
                        string mensaje = "Se ha reseteado su contraseña \n Usuario: " + oUsuario.NombreUsuario + "\n Nueva Contraseña: " + nuevaPass;
                        string asunto = "Contraseña Reseteada";
                        return Utilidades.MailSender.EnviarMail(oUsuario.Email, mensaje, asunto);
                    }
                    else return false;
                }
                else return false;
            }
            else
            {
                return false;
            }
        }
	
        public bool AgregarUsuario(Entidades.Seguridad.Usuario oUsuario)
        {
            Utilidades.EncriptacionHandler handler = new Utilidades.EncriptacionHandler(new Utilidades.EncriptacionHash(Utilidades.EncriptacionHash.TipoAlgoritmo.SHA512));
            bool operacion = false;
            try
            {
                if (Modelo.Seguridad.Facade.ObtenerInstancia().Buscar("Usuario",oUsuario.NombreUsuario) == null)
                {
                    string clave = Utilidades.GenerarPassword.CrearContraseñaAleatoria(8);
                    string claveNueva = handler.Encriptar(clave); ; 
                    oUsuario.CambiarClave(null, claveNueva);
                    Utilidades.MailSender.EnviarMail(oUsuario.Email, clave, "Su clave");
                    operacion = Modelo.Seguridad.Facade.ObtenerInstancia().Agregar(oUsuario);
                    
                }
            }
            catch (Exception error)
            {
                Utilidades.EventManager.RegistarErrores(error);
                operacion = false;
            }
            return operacion;
        }

        public bool ModificarUsuario(Entidades.Seguridad.Usuario oUsuario)
        {
            bool operacion = false;
            try
            {
                operacion = Modelo.Seguridad.Facade.ObtenerInstancia().Modificar(oUsuario);
            }
            catch (Exception error)
            {
                Utilidades.EventManager.RegistarErrores(error);
                operacion = false;
            }
            return operacion;
        }
        
        public bool EliminarUsuario(Entidades.Seguridad.Usuario oUsuario)
        {
            bool operacion = false;
            try
            {
                if (oUsuario.NombreUsuario != Utilidades.AppHandler.ObtenerStringDeAppConfig("SuperUser"))
                {
                    operacion = Modelo.Seguridad.Facade.ObtenerInstancia().Eliminar(oUsuario);
                }
                else operacion = false;
            }
            catch (Exception error)
            {
                Utilidades.EventManager.RegistarErrores(error);
                return operacion;
            }
            return operacion;
        }

        public ReadOnlyCollection<Entidades.Seguridad.Usuario> FiltrarUsuarios(string stringbusqueda)
        {
            return (ReadOnlyCollection<Entidades.Seguridad.Usuario>)Modelo.Seguridad.Facade.ObtenerInstancia().Filtrar("Usuario",stringbusqueda);
        }
        
        public object ConsultarUsuarios()
        {
            try
            {
                return Modelo.Seguridad.Facade.ObtenerInstancia().Recuperar("Usuario");
            }
            catch (Exception error)
            {
                Utilidades.EventManager.RegistarErrores(error);
                return error;
            }
        }

        public object ConsultarGrupos()
        {
            try
            {
                return Modelo.Seguridad.Facade.ObtenerInstancia().Recuperar("Grupo");
            }
            catch (Exception error)
            {
                Utilidades.EventManager.RegistarErrores(error);
                return error;
            }
        }

        public Entidades.Seguridad.Usuario BuscarUsuario(Entidades.Seguridad.Usuario usuario)
        {
            return (Entidades.Seguridad.Usuario)Modelo.Seguridad.Facade.ObtenerInstancia().Buscar("Usuario",usuario.NombreUsuario);
        }
    }
}
