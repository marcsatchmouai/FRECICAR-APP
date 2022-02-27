using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Sistema
{
    public class ControladoraVenta
    {
        private Modelo.Sistema.CatalogoVentas _Modelo;
        private static ControladoraVenta _Instancia;
        public static ControladoraVenta ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new ControladoraVenta();
            return _Instancia;
        }

        private ControladoraVenta()
        {
            _Modelo = Modelo.Sistema.CatalogoVentas.ObtenerInstancia();
        }

        public void Agregar(Entidades.Sistema.Venta Venta)
        {
            foreach (Entidades.Sistema.DetalleVenta DV in Venta.DetallesVentas)
            {
                DV.Producto.Cantidad = DV.Producto.Cantidad - DV.Cantidad;
            }

            Entidades.Sistema.CuentaCorriente oCuentaCorriente = Modelo.Sistema.CatalogoCuentasCorrientes.ObtenerInstancia().RecuperarCuentasCorrientes().Find(x => x.Cliente.Cuit == Venta.Cliente.Cuit);
            if (oCuentaCorriente.Saldo >= Venta.Total)
            {
                Venta.Detalle = "Se Realizo Venta Por un importe de: " + Venta.Total + "y pagado por saldo a favor";
                Venta.Estado = Entidades.Sistema.Venta.EstadoVenta.Finalizado;

                _Modelo.Agregar(Venta);

                Entidades.Sistema.Movimiento oMov2 = new Entidades.Sistema.Movimiento();
                oMov2.Fecha = Venta.Fecha;
                oMov2.Importe = Venta.Total;
                oMov2.TipoMovimiento = "Debito";
                oMov2.Detalle = Venta;
                oCuentaCorriente.AgregarMovimiento(oMov2);
                Modelo.Sistema.CatalogoCuentasCorrientes.ObtenerInstancia().ModificarCuentaCorriente(oCuentaCorriente);
            }
            else if (oCuentaCorriente.Saldo > 0)
            {
                Venta.Estado = Entidades.Sistema.Venta.EstadoVenta.Pendiente;
                Venta.Detalle = "Venta Realizada el: " + Venta.Fecha.Date + " al Cliente: " + Venta.Cliente + " por un Importe de:  " + Venta.Total + ".";

                _Modelo.Agregar(Venta);

                Entidades.Sistema.Pago oPago = new Entidades.Sistema.Pago();
                oPago.Cliente = Venta.Cliente;
                oPago.Fecha = Venta.Fecha;
                oPago.Venta = Venta;
                oPago.Importe = Venta.Total - oCuentaCorriente.Saldo;
                oPago.Detalle = "Pago por descuento de saldo a la Venta: " + Venta.CodigoVenta + " por un importe de: " + oPago.Importe + ".";
                Modelo.Sistema.CatalogoPagos.ObtenerInstancia().Agregar(oPago);

                Entidades.Sistema.Movimiento oMov = new Entidades.Sistema.Movimiento();
                oMov.Fecha = Venta.Fecha;
                oMov.Importe = oPago.Importe;
                oMov.TipoMovimiento = "Descuento";
                oMov.Detalle = oPago;
                oCuentaCorriente.AgregarMovimiento(oMov);
                Modelo.Sistema.CatalogoCuentasCorrientes.ObtenerInstancia().ModificarCuentaCorriente(oCuentaCorriente);

                Entidades.Sistema.Movimiento oMov2 = new Entidades.Sistema.Movimiento();
                oMov2.Fecha = Venta.Fecha;
                oMov2.Importe = Venta.Total;
                oMov2.TipoMovimiento = "Debito";
                oMov2.Detalle = Venta;
                oCuentaCorriente.AgregarMovimiento(oMov2);
                Modelo.Sistema.CatalogoCuentasCorrientes.ObtenerInstancia().ModificarCuentaCorriente(oCuentaCorriente);

            }
            else
            {

                Venta.Estado = Entidades.Sistema.Venta.EstadoVenta.Relizado;
                Venta.Detalle = "Venta Realizada el: " + Venta.Fecha.Date + " al Cliente: " + Venta.Cliente + " por un Importe de:  " + Venta.Total + ".";
                _Modelo.Agregar(Venta);

                Entidades.Sistema.Movimiento oMov2 = new Entidades.Sistema.Movimiento();
                oMov2.Fecha = Venta.Fecha;
                oMov2.Importe = Venta.Total;
                oMov2.TipoMovimiento = "Debito";
                oMov2.Detalle = Venta;
                oCuentaCorriente.AgregarMovimiento(oMov2);
                Modelo.Sistema.CatalogoCuentasCorrientes.ObtenerInstancia().ModificarCuentaCorriente(oCuentaCorriente);

            }
        }

        public bool Modificar(Entidades.Sistema.Venta Venta)
        {
            Entidades.Sistema.NotaCredito oNota = new Entidades.Sistema.NotaCredito();
            oNota.Cliente = Venta.Cliente;
            oNota.Detalle = "Nota de credito creada por la anulacion de la Venta Nº " + Venta.CodigoVenta + ".";
            oNota.Fecha = DateTime.Now;
            oNota.Importe = Venta.Total;
            if (Modelo.Sistema.CatalogoNotasCreditos.ObtenerInstancia().Agregar(oNota) == true)
            {
                Venta.Estado = Entidades.Sistema.Venta.EstadoVenta.Anulado;
                Entidades.Sistema.CuentaCorriente oCuentaCorriente = Modelo.Sistema.CatalogoCuentasCorrientes.ObtenerInstancia().RecuperarCuentasCorrientes().Find(x => x.Cliente.Cuit == Venta.Cliente.Cuit);
                Entidades.Sistema.Movimiento oMovimiento = new Entidades.Sistema.Movimiento();
                oMovimiento.Detalle = oNota;
                oMovimiento.Fecha = oNota.Fecha;
                oMovimiento.Importe = oNota.Importe;
                oMovimiento.TipoMovimiento = "Credito";
                oCuentaCorriente.AgregarMovimiento(oMovimiento);
                Modelo.Sistema.CatalogoCuentasCorrientes.ObtenerInstancia().ModificarCuentaCorriente(oCuentaCorriente);
                _Modelo.Modificar(Venta);

                foreach (Entidades.Sistema.DetalleVenta DV in Venta.DetallesVentas)
                {
                    DV.Producto.Cantidad = DV.Producto.Cantidad + DV.Cantidad;
                    Modelo.Sistema.CatalogoProductos.ObtenerInstancia().Modificar(DV.Producto);
                }

                return true;
            }
            else return false;
        }

        public void Eliminar(Entidades.Sistema.Venta Venta)
        {
            _Modelo.Eliminar(Venta);
        }

        public List<Entidades.Sistema.Venta> RecuperarVentas()
        {
            return _Modelo.RecuperarVentas();
        }

        public List<Entidades.Sistema.Producto> RecuperarProductos()
        {
            return Modelo.Sistema.CatalogoProductos.ObtenerInstancia().RecuperarProductos();
        }
    }
}
