


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Sistema
{
    public class ControladoraProducto
    {
        private Modelo.Sistema.CatalogoProductos _Modelo;
        private static Controladora.Sistema.ControladoraProducto _Instancia;
        public static ControladoraProducto ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraProducto();
            return _Instancia;
        }

        private ControladoraProducto()
        {
            _Modelo = Modelo.Sistema.CatalogoProductos.ObtenerInstancia();
        }

        public void Agregar(Entidades.Sistema.Producto Producto)
        {
            _Modelo.Agregar(Producto);
        }

        public void Modificar(Entidades.Sistema.Producto Producto)
        {
            _Modelo.Modificar(Producto);
        }

        public void Eliminar(Entidades.Sistema.Producto Producto)
        {
            _Modelo.Eliminar(Producto);
        }

        public List<Entidades.Sistema.Producto> RecuperarProducto()
        {
            return _Modelo.RecuperarProductos();
        }

        public List<Entidades.Sistema.CategoriaProducto> RecuperarCategorias()
        {
            return Modelo.Sistema.CatalogoCategoriasProductos.ObtenerInstancia().RecuperarCategorias();
        }
    }
}
