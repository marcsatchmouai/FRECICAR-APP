using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Sistema
{
    public class CatalogoProductos
    {
        Mapping.Sistema.MappingProducto _Mapping;
        List<Entidades.Sistema.Producto> _Productos;
        private static CatalogoProductos _Instancia;
        public static CatalogoProductos ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoProductos();
            return _Instancia;
        }

        private CatalogoProductos()
        {
            _Mapping = Mapping.Sistema.MappingProducto.ObtenerInstancia();
            _Productos = new List<Entidades.Sistema.Producto>();
            _Productos = _Mapping.ListarProductos();
        }

        public void Agregar(Entidades.Sistema.Producto Producto)
        {
            _Mapping.AgregarProducto(Producto);
            _Productos.Add(Producto);
        }

        public void Eliminar(Entidades.Sistema.Producto Producto)
        {
            _Mapping.EliminarProducto(Producto);
            _Productos.Remove(Producto);
        }

        public void Modificar(Entidades.Sistema.Producto Producto)
        {
            _Mapping.ModificarProducto(Producto);
            _Productos.Remove(Producto);
            _Productos.Add(Producto);
        }

        public List<Entidades.Sistema.Producto> RecuperarProductos()
        {
            return _Productos;
        }

    }
}
