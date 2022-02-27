using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Sistema
{
    public class CatalogoVentas
    {
        Mapping.Sistema.MappingVenta _Mapping;
        List<Entidades.Sistema.Venta> _Ventas;
        private static CatalogoVentas _Instancia;
        public static CatalogoVentas ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoVentas();
            return _Instancia;
        }

        private CatalogoVentas()
        {
            _Mapping = Mapping.Sistema.MappingVenta.ObtenerInstancia();
            _Ventas = new List<Entidades.Sistema.Venta>();
            _Ventas = _Mapping.ListarVentas();
        }

        public void Agregar(Entidades.Sistema.Venta Venta)
        {
            _Mapping.AgregarVenta(Venta);
            _Ventas.Add(Venta);
        }

        public void Eliminar(Entidades.Sistema.Venta Venta)
        {
            _Mapping.EliminarVenta(Venta);
            _Ventas.Remove(Venta);
        }

        public void Modificar(Entidades.Sistema.Venta Venta)
        {
            _Mapping.ModificarVenta(Venta);
            _Ventas.Remove(Venta);
            _Ventas.Add(Venta);
        }

        public List<Entidades.Sistema.Venta> RecuperarVentas()
        {
            return _Ventas;
        }
    }
}
