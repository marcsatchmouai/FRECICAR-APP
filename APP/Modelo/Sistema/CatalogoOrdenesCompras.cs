using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Sistema
{
    public class CatalogoOrdenesCompras
    {
        private Mapping.Sistema.MappingOrdenCompra _MappingOrdenCompra;
        private List<Entidades.Sistema.OrdenCompra> _OrdenCompra;
        private static CatalogoOrdenesCompras _Instancia;
        public static CatalogoOrdenesCompras ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoOrdenesCompras();
            return _Instancia;
        }

        public CatalogoOrdenesCompras()
        {
            _MappingOrdenCompra = Mapping.Sistema.MappingOrdenCompra.ObtenerInstancia();
            _OrdenCompra = new List<Entidades.Sistema.OrdenCompra>();
            _OrdenCompra = _MappingOrdenCompra.ListarOrdenesCompras();
        }

        public void AgregarOrdenCompra(Entidades.Sistema.OrdenCompra OrdenCompra)
        {
            _MappingOrdenCompra.AgregarOrdenCompra(OrdenCompra);
            _OrdenCompra.Add(OrdenCompra);
        }

        public void ModificarOrdenCompra(Entidades.Sistema.OrdenCompra OrdenCompra)
        {
            _MappingOrdenCompra.ModificarOrdenCompra(OrdenCompra);
            _OrdenCompra.Remove(OrdenCompra);
            _OrdenCompra.Add(OrdenCompra);
        }

        public void EliminarOrdenCompra(Entidades.Sistema.OrdenCompra OrdenCompra)
        {
            _MappingOrdenCompra.EliminarOrdenCompra(OrdenCompra);
            _OrdenCompra.Remove(OrdenCompra);
        }

        public List<Entidades.Sistema.OrdenCompra> RecuperarOrdenCompra()
        {
            return _OrdenCompra;
        }
    }
}
