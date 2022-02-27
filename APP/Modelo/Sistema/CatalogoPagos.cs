using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Sistema
{
    public class CatalogoPagos
    {
        Mapping.Sistema.MappingPago _Mapping;
        List<Entidades.Sistema.Pago> _Pagos;
        private static CatalogoPagos _Instancia;
        public static CatalogoPagos ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoPagos();
            return _Instancia;
        }

        private CatalogoPagos()
        {
            _Mapping = Mapping.Sistema.MappingPago.ObtenerInstancia();
            _Pagos = new List<Entidades.Sistema.Pago>();
            _Pagos = _Mapping.Recuperar();

        }

        public void Agregar(Entidades.Sistema.Pago oPago)
        {
            _Mapping.AgregarPago(oPago);
            _Pagos.Add(oPago);
        }
        public List<Entidades.Sistema.Pago> Listar()
        {
            return _Pagos;
        }
    }
}
