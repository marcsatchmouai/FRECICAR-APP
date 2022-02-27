using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace Controladora.Seguridad
{
    public class ControladoraCasoDeUsoGestionarPerfiles
    {
        public delegate void ActualizarCambios();
        public event ActualizarCambios AldetectarCambio;
        private static ControladoraCasoDeUsoGestionarPerfiles _Instancia;

        public static ControladoraCasoDeUsoGestionarPerfiles ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraCasoDeUsoGestionarPerfiles();
            return ControladoraCasoDeUsoGestionarPerfiles._Instancia;
        }

        private ControladoraCasoDeUsoGestionarPerfiles()
        {
        }

        void ControladoraCasoDeUsoGestionarPerfiles_RepositorioSeActualizo()
        {
            if (AldetectarCambio != null) AldetectarCambio();
        }
        
        public object AgregarPerfil(Entidades.Seguridad.Perfil perfil)
        {
            bool operacion = false;
            if (Modelo.Seguridad.Facade.ObtenerInstancia().Buscar("Perfil",perfil.Grupo.Nombre) == null)
            {
                operacion = Modelo.Seguridad.Facade.ObtenerInstancia().Agregar(perfil);
            }
            else operacion = false;
            return operacion;
        }

        public object EliminarPerfil(Entidades.Seguridad.Perfil perfil)
        {
            bool operacion = false;
            if (perfil.Grupo.Nombre != Utilidades.AppHandler.ObtenerStringDeAppConfig("SuperGroup"))
            {
                operacion = Modelo.Seguridad.Facade.ObtenerInstancia().Eliminar(perfil);
            }
            return operacion;
        }

        public object ModificarPerfil(Entidades.Seguridad.Perfil perfil)
        {
            bool operacion = false;
            if (perfil.Grupo.Nombre != Utilidades.AppHandler.ObtenerStringDeAppConfig("SuperGroup"))
            {
                operacion = Modelo.Seguridad.Facade.ObtenerInstancia().Modificar(perfil);
            }
            return operacion; 
        }

        public ReadOnlyCollection<Entidades.Seguridad.Perfil> ConsultarPerfiles()
        {
            return (ReadOnlyCollection<Entidades.Seguridad.Perfil>)Modelo.Seguridad.Facade.ObtenerInstancia().Recuperar("Perfil");
        }

        public ReadOnlyCollection<Entidades.Seguridad.Perfil> FiltrarPerfiles(string stringBusqueda)
        {
             return (ReadOnlyCollection<Entidades.Seguridad.Perfil>) Modelo.Seguridad.Facade.ObtenerInstancia().Filtrar("Perfil",stringBusqueda);
        }

        public ReadOnlyCollection<Entidades.Seguridad.Grupo> ConsultarGruposSinSuperGroup()
        {
            ReadOnlyCollection<Entidades.Seguridad.Grupo> grupos = (ReadOnlyCollection<Entidades.Seguridad.Grupo>)Modelo.Seguridad.Facade.ObtenerInstancia().Recuperar("Grupo");
                
            return  grupos.SkipWhile(grupo => grupo.Nombre == Utilidades.AppHandler.ObtenerStringDeAppConfig("SuperGroup")).ToList().AsReadOnly();
        }
        
        public ReadOnlyCollection<Entidades.Seguridad.Formulario> ConsultarFormularios()
        {
            return (ReadOnlyCollection<Entidades.Seguridad.Formulario>) Modelo.Seguridad.Facade.ObtenerInstancia().Recuperar("Formulario");
        }

        public ReadOnlyCollection<Entidades.Seguridad.Permiso> ConsultarPermisos()
        {
            return (ReadOnlyCollection<Entidades.Seguridad.Permiso>) Modelo.Seguridad.Facade.ObtenerInstancia().Recuperar("Permiso");
        }

        public Entidades.Seguridad.Perfil BuscarPerfil(Entidades.Seguridad.Perfil perfil)
        {
            return (Entidades.Seguridad.Perfil) Modelo.Seguridad.Facade.ObtenerInstancia().Buscar("Perfil",perfil.Grupo.Nombre);
        }
    }
}
