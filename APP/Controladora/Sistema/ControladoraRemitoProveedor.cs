using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Sistema
{
    public class ControladoraRemitoProveedor
    {
        private Modelo.Sistema.CatalogoRemitosProveedores _Modelo;
        private static ControladoraRemitoProveedor _Instancia;
        public static ControladoraRemitoProveedor ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraRemitoProveedor();
            return _Instancia;
        }

        private ControladoraRemitoProveedor()
        {
            _Modelo = Modelo.Sistema.CatalogoRemitosProveedores.ObtenerInstancia();
        }

        public void AgregarRemitoProveedor(Entidades.Sistema.RemitoProveedor RemitoProveedor)
        {
            _Modelo.AgregarRemitoProveedor(RemitoProveedor);
        }

        public void ModificarRemitoProveedor(Entidades.Sistema.RemitoProveedor RemitoProveedor)
        {
            _Modelo.ModificarRemitoProveedor(RemitoProveedor);
        }

        public void EliminarRemitoProveedor(Entidades.Sistema.RemitoProveedor RemitoProveedor)
        {
            _Modelo.EliminarRemitoProveedor(RemitoProveedor);
        }

        public List<Entidades.Sistema.RemitoProveedor> RecuperarRemitosProveedores()
        {
            return _Modelo.RecuperarRemitosProveedores();
        }
    }
}
