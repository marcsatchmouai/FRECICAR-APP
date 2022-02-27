using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Sistema
{
    public class ControladoraCategoriaProducto
    {
        private Modelo.Sistema.CatalogoCategoriasProductos oModelo;
        private static ControladoraCategoriaProducto _Instancia;
        public static ControladoraCategoriaProducto ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraCategoriaProducto();
            return _Instancia;
        }

        private ControladoraCategoriaProducto()
        {
            oModelo = Modelo.Sistema.CatalogoCategoriasProductos.ObtenerInstancia();
        }

        public void Agregar(Entidades.Sistema.CategoriaProducto CategoriaProducto)
        {
            oModelo.Agregar(CategoriaProducto);
        }

        public void Modificar(Entidades.Sistema.CategoriaProducto CategoriaProducto)
        {
            oModelo.Modificar(CategoriaProducto);
        }

        public void Eliminar(Entidades.Sistema.CategoriaProducto CategoriaProducto)
        {
            oModelo.Eliminar(CategoriaProducto);
        }

        public List<Entidades.Sistema.CategoriaProducto> RecuperarCategorias()
        {
            return oModelo.RecuperarCategorias();
        }
    }
}
