using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Sistema
{
    public class CatalogoRemitosProveedores
    {
        private Mapping.Sistema.MappingRemitoProveedor MappingRemitoProveedor;
        private List<Entidades.Sistema.RemitoProveedor> _RemitoProveedor;
        private static CatalogoRemitosProveedores _Instancia;
        public static CatalogoRemitosProveedores ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoRemitosProveedores();
            return _Instancia;
        }

        public CatalogoRemitosProveedores()
        {
            MappingRemitoProveedor = Mapping.Sistema.MappingRemitoProveedor.ObtenerInstancia();
            _RemitoProveedor = new List<Entidades.Sistema.RemitoProveedor>();
            _RemitoProveedor = MappingRemitoProveedor.ListarRemitosProveedor();
        }

        public void AgregarRemitoProveedor(Entidades.Sistema.RemitoProveedor RemitoProveedor)
        {
            MappingRemitoProveedor.AgregarRemitoProveedor(RemitoProveedor);
            _RemitoProveedor.Add(RemitoProveedor);
        }

        public void ModificarRemitoProveedor(Entidades.Sistema.RemitoProveedor RemitoProveedor)
        {
            MappingRemitoProveedor.ModificarRemitoProveedor(RemitoProveedor);
            _RemitoProveedor.Remove(RemitoProveedor);
            _RemitoProveedor.Add(RemitoProveedor);
        }

        public void EliminarRemitoProveedor(Entidades.Sistema.RemitoProveedor RemitoProveedor)
        {
            MappingRemitoProveedor.EliminarRemitoProveedor(RemitoProveedor);
            _RemitoProveedor.Remove(RemitoProveedor);
        }

        public List<Entidades.Sistema.RemitoProveedor> RecuperarRemitosProveedores()
        {
            return _RemitoProveedor;
        }
    }
}
