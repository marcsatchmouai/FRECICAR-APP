using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Sistema
{
   public class ControladoraFormadeEnvio
    {
        private Modelo.Sistema.CatalogoFormadeEnvios _Modelo;
        private static ControladoraFormadeEnvio _Instancia;
        public static ControladoraFormadeEnvio ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraFormadeEnvio();
            return _Instancia;
        }

        private ControladoraFormadeEnvio()
        {
            _Modelo = Modelo.Sistema.CatalogoFormadeEnvios.ObtenerInstancia();
        }

        public void AgregarFormadeEnvio(Entidades.Sistema.FormadeEnvio FormadeEnvio)
        {
            _Modelo.AgregarFormadeEnvio(FormadeEnvio);
        }

        public void ModificarFormadeEnvio(Entidades.Sistema.FormadeEnvio FormadeEnvio)
        {
            _Modelo.ModificarFormadeEnvio(FormadeEnvio);
        }

        public void EliminarFormadeEnvio(Entidades.Sistema.FormadeEnvio FormadeEnvio)
        {
            Entidades.Sistema.OrdenCompra oOrdenCompra = (Entidades.Sistema.OrdenCompra)Controladora.Sistema.ControladoraOrdenCompra.ObtenerInstancia().RecuperarOrdenesCompras().Find(x => x.FormadeEnvio.Nombre == FormadeEnvio.Nombre);
            if (oOrdenCompra == null)
            {
                _Modelo.EliminarFormadeEnvio(FormadeEnvio);
            }
        }

        public List<Entidades.Sistema.FormadeEnvio> RecuperarFormasdeEnvios()
        {
            return _Modelo.RecuperarFormasdeEnvios().ToList();
        }
    }
}
