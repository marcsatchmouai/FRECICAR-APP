using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Sistema
{
    public class CatalogoCategoriasProductos
    {
        Mapping.Sistema.MappingCategoriaProducto _Mapping;
        List<Entidades.Sistema.CategoriaProducto> _Categorias;
        private static CatalogoCategoriasProductos _Instancia;
        public static CatalogoCategoriasProductos ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoCategoriasProductos();
            return _Instancia;
        }

        private CatalogoCategoriasProductos()
        {
            _Mapping = Mapping.Sistema.MappingCategoriaProducto.ObtenerInstancia();
            _Categorias = new List<Entidades.Sistema.CategoriaProducto>();
            _Categorias = _Mapping.DevolverLista();
        }

        public void Agregar(Entidades.Sistema.CategoriaProducto Categoria)
        {
            _Mapping.AgregarCategoriaProducto(Categoria);
            _Categorias.Add(Categoria);
        }

        public void Eliminar(Entidades.Sistema.CategoriaProducto Categoria)
        {
            _Mapping.EliminarCategoriaProducto(Categoria);
            _Categorias.Remove(Categoria);
        }

        public void Modificar(Entidades.Sistema.CategoriaProducto Categoria)
        {
            _Mapping.ModificarCategoriaProducto(Categoria);
            _Categorias.Remove(Categoria);
            _Categorias.Add(Categoria);
        }

        public List<Entidades.Sistema.CategoriaProducto> RecuperarCategorias()
        {
            return _Categorias;
        }
    }
}
