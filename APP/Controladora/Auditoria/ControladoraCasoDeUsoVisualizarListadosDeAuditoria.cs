using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Controladora.Auditoria
{
    public class ControladoraCasoDeUsoVisualizarListadosDeAuditoria
    {
        private static ControladoraCasoDeUsoVisualizarListadosDeAuditoria _Instancia;
        public static ControladoraCasoDeUsoVisualizarListadosDeAuditoria ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraCasoDeUsoVisualizarListadosDeAuditoria();
            return _Instancia;
        }
        private ControladoraCasoDeUsoVisualizarListadosDeAuditoria()
        { }
        public ReadOnlyCollection<Entidades.Auditoria.AuditoriaInicioSesion> RecuperarListadosIngresosEgresos()
        {
            return Modelo.Auditoria.CatalogoLogInLogOut.ObtenerInstancia().RecuperarIngresosYEgresos();
        }

        public ReadOnlyCollection<Entidades.Auditoria.AuditoriaInicioSesion> FiltrarLogInOut(string criterio)
        {
            return Modelo.Auditoria.CatalogoLogInLogOut.ObtenerInstancia().Filtrar(criterio);
        }

        public void Actualizar()
        {
            Modelo.Auditoria.CatalogoLogInLogOut.ObtenerInstancia().Actualizar();
        }
    }
}
