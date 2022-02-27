using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Sistema
{
    public class CatalogoProvincias
    {
        List<Entidades.Sistema.Provincia> _Provincias;
        private static CatalogoProvincias _Instancia;
        public static CatalogoProvincias ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoProvincias();
            return _Instancia;
        }

        CatalogoProvincias()
        {
            _Provincias = new List<Entidades.Sistema.Provincia>();
            _Provincias = Mapping.Sistema.MappingProvincia.ObtenerInstancia().ListarProvincias();
        }

        public List<Entidades.Sistema.Provincia> RecuperarProvincias()
        {
            return _Provincias;
        }
    }
}
