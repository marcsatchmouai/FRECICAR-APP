using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Sistema
{
   public class ControladoraCategoria
    {
        private Modelo.Sistema.CatalogoCategorias _Modelo;
        private static ControladoraCategoria _Instancia;
        public static ControladoraCategoria ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraCategoria();
            return _Instancia;
        }

        private ControladoraCategoria()
        {
            _Modelo = Modelo.Sistema.CatalogoCategorias.ObtenerInstancia();
        }

        public void AgregarCategoria(Entidades.Sistema.Categoria Categoria)
        {
            _Modelo.AgregarCategoria(Categoria);
        }

        public void ModificarCategoria(Entidades.Sistema.Categoria Categoria)
        {
            _Modelo.ModificarCategoria(Categoria);
        }

        public bool EliminarCategoria(Entidades.Sistema.Categoria Categoria)
        {
            Entidades.Sistema.MateriaPrima materia = Modelo.Sistema.CatalogoMateriasPrimas.ObtenerInstancia().RecuperarMateriasPrimas().Find(x => x.Categoria.Nombre == Categoria.Nombre);
            if (materia == null)
            {
                _Modelo.EliminarCategoria(Categoria);
                return true;
            }
            else return false;
        }

        public List<Entidades.Sistema.Categoria> RecuperarCategorias()
        {
            return _Modelo.RecuperarCategorias();
        }
    }
}
