using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Sistema
{
   public class CatalogoCategorias
    {
        private Mapping.Sistema.MappingCategoria MappingCategoria;
        private List<Entidades.Sistema.Categoria> _categorias;
        private static CatalogoCategorias _Instancia;
        public static CatalogoCategorias ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoCategorias();
            return _Instancia;
        }

        private CatalogoCategorias()
        {
            MappingCategoria = Mapping.Sistema.MappingCategoria.ObtenerInstancia();
            _categorias = new List<Entidades.Sistema.Categoria>();
            _categorias = MappingCategoria.DevolverLista();
        }
        public void AgregarCategoria(Entidades.Sistema.Categoria Categoria)
        {
            MappingCategoria.AgregarCategoria(Categoria);
            _categorias.Add(Categoria);
        }

        public void ModificarCategoria(Entidades.Sistema.Categoria Categoria)
        {
            MappingCategoria.ModificarCategoria(Categoria);
            _categorias.Remove(Categoria);
            _categorias.Add(Categoria);
        }

        public void EliminarCategoria(Entidades.Sistema.Categoria Categoria)
        {
            MappingCategoria.EliminarCategoria(Categoria);
            _categorias.Remove(Categoria);
        }

        public List<Entidades.Sistema.Categoria> RecuperarCategorias()
        {
            return _categorias;
        }
    }
}
