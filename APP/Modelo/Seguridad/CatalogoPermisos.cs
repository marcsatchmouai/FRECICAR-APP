using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Modelo.Seguridad
{
    class CatalogoPermisos
    {
        private static CatalogoPermisos _Instancia;
        private List<Entidades.Seguridad.Permiso> _Permisos;

        private CatalogoPermisos()
        {
            this._Permisos = Mapping.Seguridad.MappingPermisos.RecuperarPermisos();
        }

        public static CatalogoPermisos ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoPermisos();
            return _Instancia;
        }

        public ReadOnlyCollection<Entidades.Seguridad.Permiso> RecuperarPermisos()
        {
            return this._Permisos.AsReadOnly();
        }
    }
}
