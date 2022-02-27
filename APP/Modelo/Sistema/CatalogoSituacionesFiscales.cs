using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Sistema
{
    public class CatalogoSituacionesFiscales
    {
        List<Entidades.Sistema.SituacionFiscal> _SituacionesFiscales;
        private static CatalogoSituacionesFiscales _Instancia;
        private Mapping.Sistema.MappingSituacionFiscal _Mapping;
        public static CatalogoSituacionesFiscales ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoSituacionesFiscales();
            return _Instancia;
        }

        private CatalogoSituacionesFiscales()
        {
            _Mapping = Mapping.Sistema.MappingSituacionFiscal.ObtenerInstancia();
            _SituacionesFiscales = new List<Entidades.Sistema.SituacionFiscal>();
            _SituacionesFiscales = _Mapping.ListarSituacionesFiscales();
        }

        public void Agregar(Entidades.Sistema.SituacionFiscal SituacionFiscal)
        {
            _SituacionesFiscales.Add(SituacionFiscal);
            _Mapping.Agregar(SituacionFiscal);
        }

        public void Modificar(Entidades.Sistema.SituacionFiscal SituacionFiscal)
        {
            _SituacionesFiscales.Add(SituacionFiscal);
            _SituacionesFiscales.Remove(SituacionFiscal);
            _Mapping.Modificar(SituacionFiscal);
        }

        public void Eliminar(Entidades.Sistema.SituacionFiscal SituacionFiscal)
        {
            _SituacionesFiscales.Remove(SituacionFiscal);
            _Mapping.Eliminar(SituacionFiscal);
        }

        public List<Entidades.Sistema.SituacionFiscal> Recuperar()
        {
            return _SituacionesFiscales.ToList();
        }
    }
}
