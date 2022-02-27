using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Sistema
{
    public class ControladoraFormadePago
    {
        private Modelo.Sistema.CatalogoFormadePagos _Modelo;
        private static ControladoraFormadePago _Instancia;
        public static ControladoraFormadePago ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraFormadePago();
            return _Instancia;
        }

        private ControladoraFormadePago()
        {
            _Modelo = Modelo.Sistema.CatalogoFormadePagos.ObtenerInstancia();
        }

        public void AgregarFormadePago(Entidades.Sistema.FormadePago FormadePago)
        {
            _Modelo.AgregarFormadePago(FormadePago);
        }

        public void ModificarFormadePago(Entidades.Sistema.FormadePago FormadePago)
        {
            _Modelo.ModificarFormadePago(FormadePago);
        }

        public void EliminarFormadePago(Entidades.Sistema.FormadePago FormadePago)
        {
            Entidades.Sistema.OrdenCompra oOrdenCompra = (Entidades.Sistema.OrdenCompra)Controladora.Sistema.ControladoraOrdenCompra.ObtenerInstancia().RecuperarOrdenesCompras().Find(x => x.FormadePago.Nombre == FormadePago.Nombre);
            if (oOrdenCompra == null)
            {
                _Modelo.EliminarFormadePago(FormadePago);
            }
        }

        public List<Entidades.Sistema.FormadePago> RecuperarFormasdePagos()
        {
            return _Modelo.RecuperarFormasdePagos();
        }
    }
}
