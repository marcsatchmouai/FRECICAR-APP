using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Sistema
{
    public class CatalogoProveedores
    {
        private Mapping.Sistema.MappingProveedor MappingProveedor;
        private List<Entidades.Sistema.Proveedor> _Proveedor;
        private static CatalogoProveedores _Instancia;
        public static CatalogoProveedores ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoProveedores();
            return _Instancia;
        }

        public CatalogoProveedores()
        {
            MappingProveedor = Mapping.Sistema.MappingProveedor.ObtenerInstancia();
            _Proveedor = new List<Entidades.Sistema.Proveedor>();
            _Proveedor = MappingProveedor.ListarProveedores();
        }

        public void AgregarProveedor(Entidades.Sistema.Proveedor Proveedor)
        {
            MappingProveedor.AgregarProveedor(Proveedor);
            _Proveedor.Add(Proveedor);
        }

        public void ModificarProveedor(Entidades.Sistema.Proveedor Proveedor)
        {
            MappingProveedor.ModificarProveedor(Proveedor);
            _Proveedor.Remove(Proveedor);
            _Proveedor.Add(Proveedor);
        }

        public void EliminarProveedor(Entidades.Sistema.Proveedor Proveedor)
        {
            MappingProveedor.EliminarProveedor(Proveedor);
            _Proveedor.Remove(Proveedor);
        }

        public List<Entidades.Sistema.Proveedor> RecuperarProveedores()
        {
            return _Proveedor;
        }

    }
}
