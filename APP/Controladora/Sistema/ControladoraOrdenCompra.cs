using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Sistema
{
    public class ControladoraOrdenCompra
    {
        private Modelo.Sistema.CatalogoOrdenesCompras _Modelo;
        private static ControladoraOrdenCompra _Instancia;
        public static ControladoraOrdenCompra ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraOrdenCompra();
            return _Instancia;
        }

        private ControladoraOrdenCompra()
        {
            _Modelo = Modelo.Sistema.CatalogoOrdenesCompras.ObtenerInstancia();
        }

        public void AgregarOrdenCompra(Entidades.Sistema.OrdenCompra OrdenCompra)
        {
            _Modelo.AgregarOrdenCompra(OrdenCompra);
        }

        public void ModificarOrdenCompra(Entidades.Sistema.OrdenCompra OrdenCompra)
        {
            _Modelo.ModificarOrdenCompra(OrdenCompra);
        }

        public void EliminarOrdenCompra(Entidades.Sistema.OrdenCompra OrdenCompra)
        {
            _Modelo.EliminarOrdenCompra(OrdenCompra);
        }

        public List<Entidades.Sistema.OrdenCompra> RecuperarOrdenesCompras()
        {
            return _Modelo.RecuperarOrdenCompra();
        }

    }
}
