using System;
using System.Collections.ObjectModel;
using System.Configuration;

namespace Controladora.Seguridad
{
    public class ControladoraCasoDeUsoGestionarGrupos
    {
        public delegate void ActualizarCambios();
        public event ActualizarCambios AldetectarCambio;
        private static ControladoraCasoDeUsoGestionarGrupos _Instancia;

        public static ControladoraCasoDeUsoGestionarGrupos ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraCasoDeUsoGestionarGrupos();
            return ControladoraCasoDeUsoGestionarGrupos._Instancia;
        }

        private ControladoraCasoDeUsoGestionarGrupos()
        {
        }

        void ControladoraCasoDeUsoGestionarGrupos_RepositorioSeActualizo()
        {
            if (AldetectarCambio != null) AldetectarCambio();
        }

        public ReadOnlyCollection<Entidades.Seguridad.Grupo> FiltrarGrupos(string stringbusqueda)
        {
            return (ReadOnlyCollection<Entidades.Seguridad.Grupo>)Modelo.Seguridad.Facade.ObtenerInstancia().Filtrar("Grupo",stringbusqueda);
        }
        
        public object AgregarGrupo(Entidades.Seguridad.Grupo grupo)
        {
            if (Modelo.Seguridad.Facade.ObtenerInstancia().Buscar("Grupo",grupo.Nombre) == null)
            {
                Modelo.Seguridad.Facade.ObtenerInstancia().Agregar(grupo);
                return true;
            }
            else return false;
        }

        public object ModificarGrupo(Entidades.Seguridad.Grupo grupo)
        {
            bool operacion = false;
            try
            {
                if (grupo.Nombre != ConfigurationManager.AppSettings["SuperGroup"].ToString())
                {
                    operacion = Modelo.Seguridad.Facade.ObtenerInstancia().Modificar(grupo);
                }
                else operacion = false; 
                return operacion;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public object EliminarGrupo(Entidades.Seguridad.Grupo grupo)
        {
            bool operacion = false;
            try
            {
                if (grupo.Nombre != ConfigurationManager.AppSettings["SuperGroup"].ToString() && Modelo.Seguridad.Facade.ObtenerInstancia().BusquedaCompuesta("Usuario",grupo) == false && Modelo.Seguridad.Facade.ObtenerInstancia().BusquedaCompuesta("Grupo",grupo) == false )
                {
                    operacion = Modelo.Seguridad.Facade.ObtenerInstancia().Eliminar(grupo);
                }
                else operacion = false;
                return operacion;
            }
            catch (Exception ex)
            {
                return ex;
            } 
        }

        public ReadOnlyCollection<Entidades.Seguridad.Grupo> ConsultarGrupos()
        {
            return (ReadOnlyCollection<Entidades.Seguridad.Grupo>) Modelo.Seguridad.Facade.ObtenerInstancia().Recuperar("Grupo");
        }
    }
}
