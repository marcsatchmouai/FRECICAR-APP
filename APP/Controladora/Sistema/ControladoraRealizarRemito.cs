using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Sistema
{
    public class ControladoraRealizarRemito
    {
        private Modelo.Sistema.CatalogoRemitosProveedores oModelo;
        private static ControladoraRealizarRemito _Instancia;
        public static ControladoraRealizarRemito ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraRealizarRemito();
            return _Instancia;
        }

        private ControladoraRealizarRemito()
        {
            oModelo = Modelo.Sistema.CatalogoRemitosProveedores.ObtenerInstancia();
        }

        public void AgregarRemito(Entidades.Sistema.RemitoProveedor Remito,Entidades.Seguridad.Usuario usuario)
        {
            Entidades.Sistema.OrdenCompra oc = Modelo.Sistema.CatalogoOrdenesCompras.ObtenerInstancia().RecuperarOrdenCompra().Find(x=>x.Codigo == Remito.NumeroOrdenCompra);
            bool pendiente = false;
            foreach (var detalle in oc.DetalleOrdenCompra)
            {
                if (detalle.Faltante != 0) { pendiente = true; }
            }
            if (pendiente) oc.Estado = "Pendiente";
            else oc.Estado = "Finalizado";
            oModelo.AgregarRemitoProveedor(Remito);
            oc.Usuario = usuario.NombreUsuario;
            oc.Operacion = "Modificar";
            oc.FechaOperacion = DateTime.Now;
            oc.Equipo = Environment.MachineName;
            Modelo.Sistema.CatalogoOrdenesCompras.ObtenerInstancia().ModificarOrdenCompra(oc);
        }

        public List<Entidades.Sistema.Proveedor> RecuperarProveedores()
        {
            return Modelo.Sistema.CatalogoProveedores.ObtenerInstancia().RecuperarProveedores();
        }

        public List<Entidades.Sistema.RemitoProveedor> RecuperarRemitos()
        {
            return oModelo.RecuperarRemitosProveedores();
        }

        public List<Entidades.Sistema.MateriaPrima> RecuperarMateriasPrimas(Entidades.Sistema.Proveedor proveedor)
        {
            return Modelo.Sistema.CatalogoMateriasPrimas.ObtenerInstancia().RecuperarMateriasPrimas().FindAll(x => x.Proveedor.Cuit == proveedor.Cuit);
        }
    }
}
