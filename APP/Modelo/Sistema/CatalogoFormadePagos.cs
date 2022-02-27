using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Sistema
{
    public class CatalogoFormadePagos
    {
        Mapping.Sistema.MappingFormadePago MappingFormadePago;
        private List<Entidades.Sistema.FormadePago> _FormadePago;
        private static CatalogoFormadePagos _Instancia;
        public static CatalogoFormadePagos ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoFormadePagos();
            return _Instancia;
        }

        private CatalogoFormadePagos()
        {
            MappingFormadePago = Mapping.Sistema.MappingFormadePago.ObtenerInstancia();
            _FormadePago = new List<Entidades.Sistema.FormadePago>();
            _FormadePago = MappingFormadePago.ListarFormasPagos();
        }

        public void AgregarFormadePago(Entidades.Sistema.FormadePago FormadePago)
        {
            MappingFormadePago.AgregarFormadePago(FormadePago);
            _FormadePago.Add(FormadePago);
        }

        public void ModificarFormadePago(Entidades.Sistema.FormadePago FormadePago)
        {
            MappingFormadePago.ModificarFormadePago(FormadePago);
            _FormadePago.Remove(FormadePago);
            _FormadePago.Add(FormadePago);
        }

        public void EliminarFormadePago(Entidades.Sistema.FormadePago FormadePago)
        {
            MappingFormadePago.EliminarFormadePago(FormadePago);
            _FormadePago.Remove(FormadePago);
        }

        public List<Entidades.Sistema.FormadePago> RecuperarFormasdePagos()
        {
            return _FormadePago;
        }
    }
}
