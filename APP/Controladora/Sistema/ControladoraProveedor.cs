using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Sistema
{
    public class ControladoraProveedor
    {
        private Modelo.Sistema.CatalogoProveedores _Modelo;
        private static ControladoraProveedor _Instancia;
        public static ControladoraProveedor ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraProveedor();
            return _Instancia;
        }

        private ControladoraProveedor()
        {
            _Modelo = Modelo.Sistema.CatalogoProveedores.ObtenerInstancia();
        }

        public void AgregarProveedor(Entidades.Sistema.Proveedor Proveedor)
        {
            _Modelo.AgregarProveedor(Proveedor);
        }

        public void ModificarProveedor(Entidades.Sistema.Proveedor Proveedor)
        {
            _Modelo.ModificarProveedor(Proveedor);
        }

        public void EliminarProveedor(Entidades.Sistema.Proveedor Proveedor)
        {
            Entidades.Sistema.MateriaPrima oMateriaPrima = ControladoraMateriaPrima.ObtenerInstancia().RecuperarMateriasPrimas().Find(x => x.Proveedor.Cuit == Proveedor.Cuit);
            Entidades.Sistema.OrdenCompra oOrdenCompra = ControladoraOrdenCompra.ObtenerInstancia().RecuperarOrdenesCompras().Find(x => x.Proveedor.Cuit == Proveedor.Cuit);
            Entidades.Sistema.RemitoProveedor oRemito = ControladoraRemitoProveedor.ObtenerInstancia().RecuperarRemitosProveedores().Find(x => x.Proveedor.Cuit == Proveedor.Cuit);
            if (oMateriaPrima == null && oOrdenCompra == null && oRemito == null)
            {
                _Modelo.EliminarProveedor(Proveedor);
            }
        }

        public List<Entidades.Sistema.Proveedor> RecuperarProveedores()
        {
            return _Modelo.RecuperarProveedores();
        }

    }
}
