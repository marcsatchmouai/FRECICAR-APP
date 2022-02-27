using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Sistema
{
    public class ControladoraPago
    {
        Modelo.Sistema.CatalogoPagos _Modelo;
        private static ControladoraPago _Instancia;
        Modelo.Sistema.CatalogoCuentasCorrientes _ModeloCC;
        public static ControladoraPago ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraPago();
            return _Instancia;
        }

        private ControladoraPago()
        {
            _Modelo = Modelo.Sistema.CatalogoPagos.ObtenerInstancia();
            _ModeloCC = Modelo.Sistema.CatalogoCuentasCorrientes.ObtenerInstancia();
        }

        public void RegistrarPago(Entidades.Sistema.Pago oPago)
        {
            decimal TotalPagos = 0;
            Entidades.Sistema.Venta oVenta = Modelo.Sistema.CatalogoVentas.ObtenerInstancia().RecuperarVentas().Find(x=>x.CodigoVenta == oPago.Venta.CodigoVenta);
            List<Entidades.Sistema.Pago> _ListaPagos = _Modelo.Listar().FindAll(x=>x.Venta.CodigoVenta == oPago.Venta.CodigoVenta);
            foreach (Entidades.Sistema.Pago Pago in _ListaPagos)
            {
                TotalPagos =+ Pago.Importe;
            }
            TotalPagos = +oPago.Importe;
            if ((oVenta.Total - TotalPagos) <= 0)
            {
                oVenta.Estado = Entidades.Sistema.Venta.EstadoVenta.Finalizado;
                Modelo.Sistema.CatalogoVentas.ObtenerInstancia().Modificar(oVenta);
            }
            else
            {
                oVenta.Estado = Entidades.Sistema.Venta.EstadoVenta.Pendiente;
                Modelo.Sistema.CatalogoVentas.ObtenerInstancia().Modificar(oVenta);
            }

            List<Entidades.Sistema.CuentaCorriente> _CuentasCorrientes = _ModeloCC.RecuperarCuentasCorrientes();
            Entidades.Sistema.Movimiento oMovimiento = new Entidades.Sistema.Movimiento();
            oMovimiento.Fecha = oPago.Fecha;
            oMovimiento.Importe = oPago.Importe;
            oMovimiento.TipoMovimiento = "Credito";
            oMovimiento.Detalle = oPago;
            Entidades.Sistema.CuentaCorriente oCuentaCorriente = _CuentasCorrientes.Find(x =>x.Cliente.Cuit == oPago.Cliente.Cuit);
            oCuentaCorriente.AgregarMovimiento(oMovimiento);
            _ModeloCC.ModificarCuentaCorriente(oCuentaCorriente);
            _Modelo.Agregar(oPago);
        }

        public List<Entidades.Sistema.Cliente> ListarClientes()
        {
            return Modelo.Sistema.CatalogoClientes.ObtenerInstancia().RecuperarCliente();
        }
        public List<Entidades.Sistema.Pago> Listar()
        {
            return _Modelo.Listar();
        }

        public List<Entidades.Sistema.Venta> RecuperarVentas(Entidades.Sistema.Cliente oCliente)
        {
            return Modelo.Sistema.CatalogoVentas.ObtenerInstancia().RecuperarVentas().FindAll(
                x => x.Cliente.Cuit == oCliente.Cuit 
                && (x.Estado == Entidades.Sistema.Venta.EstadoVenta.Relizado 
                || x.Estado == Entidades.Sistema.Venta.EstadoVenta.Pendiente));
        }

    }
}
