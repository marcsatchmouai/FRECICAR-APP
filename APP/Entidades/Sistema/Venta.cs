using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    [Serializable]
    public class Venta : IDetalle
    {

        private int _CodigoVenta;
        private Cliente _Cliente;
        private FormadePago _FormadePago;
        private FormadeEnvio _Envio;
        private string _Detalle;
        private List<Entidades.Sistema.DetalleVenta> _DetallesVentas;
        private DateTime _Fecha;
        private Decimal _Total;

        public Venta()
        {
            _DetallesVentas = new List<Sistema.DetalleVenta>();
        }
        public enum EstadoVenta { Relizado, Anulado, Finalizado, Pendiente }
        private EstadoVenta _Estado;
        
        public EstadoVenta Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        public Decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        public int CodigoVenta
        {
            get { return _CodigoVenta; }
            set { _CodigoVenta = value; }
        }

        public Cliente Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        public FormadeEnvio Envio
        {
            get { return _Envio; }
            set { _Envio = value; }
        }

        public FormadePago FormadePago
        {
            get { return _FormadePago; }
            set { _FormadePago = value; }
        }

        public List<DetalleVenta> DetallesVentas
        {
            get { return _DetallesVentas; }
            set { _DetallesVentas = value; }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public string Detalle
        {
            get
            {
                return _Detalle;
            }
             set
            {
                _Detalle = value;
            }
        }
        public void AgregarDetalle(DetalleVenta DetalleVenta)
        {
            _DetallesVentas.Add(DetalleVenta);
        }

        public void EliminarDetalle(DetalleVenta DetalleVenta)
        {
            _DetallesVentas.Remove(DetalleVenta);
        }

        public List<Entidades.Sistema.DetalleVenta> ListarDetalles()
        {
            return _DetallesVentas;
        }

        public override string ToString()
        {
            return Detalle;
        }

        public Memento CrearMemento()
        {
            return new Memento(this);
        }

        public void SetMemento(Memento oMemento)
        {
            this._DetallesVentas =  oMemento.GetMemento().DetallesVentas;
        }
    }
}
