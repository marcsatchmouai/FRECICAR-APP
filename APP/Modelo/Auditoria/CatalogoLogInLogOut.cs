using System.Collections.Generic;
using System.Linq;

namespace Modelo.Auditoria
{
    public class CatalogoLogInLogOut
    {
        private List<Entidades.Auditoria.AuditoriaInicioSesion> _ColeccionAuditoriaLogInLogOut;

        private static CatalogoLogInLogOut _Instancia;

        public static CatalogoLogInLogOut ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoLogInLogOut();
            return _Instancia;
        }
        
        public CatalogoLogInLogOut()
        {
            _ColeccionAuditoriaLogInLogOut = new List<Entidades.Auditoria.AuditoriaInicioSesion>();
        }

        public void Registrar(Entidades.Auditoria.AuditoriaInicioSesion oAudit)
        {
            Mapping.Auditoria.MappingAuditoriaLog.Registrar(oAudit);
            _ColeccionAuditoriaLogInLogOut.Add(oAudit);
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Auditoria.AuditoriaInicioSesion> RecuperarIngresosYEgresos()
        {
            _ColeccionAuditoriaLogInLogOut = null;
            _ColeccionAuditoriaLogInLogOut =Mapping.Auditoria.MappingAuditoriaLog.RecuperarRegistrosIngresosEgresos();
            return _ColeccionAuditoriaLogInLogOut.OrderByDescending(fecha => fecha.FechaHora).ToList().AsReadOnly();
        }

        public System.Collections.ObjectModel.ReadOnlyCollection<Entidades.Auditoria.AuditoriaInicioSesion> Filtrar(string criterio)
        {
            return _ColeccionAuditoriaLogInLogOut.FindAll(delegate(Entidades.Auditoria.AuditoriaInicioSesion aud) { return aud.Usuario.ToLower().Contains(criterio.ToLower()) || aud.Equipo.ToLower() == criterio.ToLower() || aud.FechaHora.ToString().ToLower().Contains(criterio.ToLower()); }).AsReadOnly();
        }

        public void Actualizar()
        {
            _ColeccionAuditoriaLogInLogOut = null;
            _ColeccionAuditoriaLogInLogOut = Mapping.Auditoria.MappingAuditoriaLog.RecuperarRegistrosIngresosEgresos();
        }
    }
}
