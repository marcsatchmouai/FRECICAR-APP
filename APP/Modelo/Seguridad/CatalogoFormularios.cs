using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Modelo.Seguridad
{
    class CatalogoFormularios
    {
        private static CatalogoFormularios _Instancia;
        private List<Entidades.Seguridad.Formulario> _Formularios;
        
        private CatalogoFormularios()
        {
            this._Formularios = Mapping.Seguridad.MappingFormularios.RecuperarFormularios();
        }

        public static CatalogoFormularios ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoFormularios();
            return _Instancia;
        }
        
        public ReadOnlyCollection<Entidades.Seguridad.Formulario> RecuperarPermisos()
        {
            return this._Formularios.AsReadOnly();
        }
    }
}
