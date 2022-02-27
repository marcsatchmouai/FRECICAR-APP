using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Sistema
{
    public class CatalogoMateriasPrimas
    {
        private Mapping.Sistema.MappingMateriaPrima MappingMateriaPrima;
        private List<Entidades.Sistema.MateriaPrima> _MateriaPrima;
        private static CatalogoMateriasPrimas _Instancia;
        public static CatalogoMateriasPrimas ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoMateriasPrimas();
            return _Instancia;
        }

        private CatalogoMateriasPrimas()
        {
            MappingMateriaPrima = Mapping.Sistema.MappingMateriaPrima.ObtenerInstancia();
            _MateriaPrima = new List<Entidades.Sistema.MateriaPrima>();
            _MateriaPrima = MappingMateriaPrima.ListarMateriasPrimas();
        }

        public void AgregarMateriaPrima(Entidades.Sistema.MateriaPrima MateriaPrima)
        {
            MappingMateriaPrima.AgregarMateriaPrima(MateriaPrima);
            _MateriaPrima.Add(MateriaPrima);
        }

        public void ModificarMateriaPrima(Entidades.Sistema.MateriaPrima MateriaPrima)
        {
            MappingMateriaPrima.ModificarMateriaPrima(MateriaPrima);
            _MateriaPrima.Remove(MateriaPrima);
            _MateriaPrima.Add(MateriaPrima);
        }

        public void EliminarMateriaPrima(Entidades.Sistema.MateriaPrima MateriaPrima)
        {
            MappingMateriaPrima.EliminarMateriaPrima(MateriaPrima);
            _MateriaPrima.Remove(MateriaPrima);
        }

        public List<Entidades.Sistema.MateriaPrima> RecuperarMateriasPrimas()
        {
            return _MateriaPrima;
        }
    }
}
