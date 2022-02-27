using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Sistema;

namespace Controladora.Sistema
{
    public class ControladoraRealizarOrdenCompra
    {
        private Modelo.Sistema.CatalogoOrdenesCompras oModelo;
        private static ControladoraRealizarOrdenCompra _Instancia;
        public static ControladoraRealizarOrdenCompra ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraRealizarOrdenCompra();
            return _Instancia;
        }

        private ControladoraRealizarOrdenCompra()
        {
            oModelo = Modelo.Sistema.CatalogoOrdenesCompras.ObtenerInstancia();
        }

        public void AgregarOrdenCompra(Entidades.Sistema.OrdenCompra OrdenCompra)
        {
            OrdenCompra.Operacion = "Agregar";
            OrdenCompra.FechaOperacion = DateTime.Now;
            OrdenCompra.Equipo = Environment.MachineName;
            Modelo.Sistema.CatalogoOrdenesCompras.ObtenerInstancia().AgregarOrdenCompra(OrdenCompra);
        }

        public List<Entidades.Sistema.FormadeEnvio> RecuperarFormadeEnvios()
        {
            return Modelo.Sistema.CatalogoFormadeEnvios.ObtenerInstancia().RecuperarFormasdeEnvios();
        }

        public List<FormadePago> RecuperarFormasdePagos()
        {
            return Modelo.Sistema.CatalogoFormadePagos.ObtenerInstancia().RecuperarFormasdePagos();
        }

        public List<Proveedor> RecuperarProveedores()
        {
            return Modelo.Sistema.CatalogoProveedores.ObtenerInstancia().RecuperarProveedores();
        }
   
        public List<Entidades.Sistema.OrdenCompra> RecuperarOrdenesCompras()
        {
            return Modelo.Sistema.CatalogoOrdenesCompras.ObtenerInstancia().RecuperarOrdenCompra();
        }

        public List<Entidades.Sistema.MateriaPrima> RecuperarMateriasPrimas(Proveedor proveedor)
        {
            return Modelo.Sistema.CatalogoMateriasPrimas.ObtenerInstancia().RecuperarMateriasPrimas().FindAll(x => x.Proveedor.Cuit == proveedor.Cuit);
        }

        public void ModificarEstadoOrdenCompra(OrdenCompra OrdenCompra)
        {
            OrdenCompra.Operacion = "Modificar";
            OrdenCompra.FechaOperacion = DateTime.Now;
            OrdenCompra.Equipo = Environment.MachineName;
            Modelo.Sistema.CatalogoOrdenesCompras.ObtenerInstancia().ModificarOrdenCompra(OrdenCompra);
        }
    }
}
