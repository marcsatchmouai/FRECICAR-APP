using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    [Serializable]
    public class OrdenCompra
    {
        private int _Codigo;
        private FormadeEnvio _FormadeEnvio;
        private FormadePago _FormadePago;
        private Proveedor _Proveedor;
        private decimal _Total;
        private DateTime _Fecha;
        private string _Usuario;
        private String _Estado;
        private string _Operacion;
        private DateTime _FechaOperacion;
        private string _Equipo;
        private List<DetalledeOrdenCompra> _DetalleOrdenCompra;

        public OrdenCompra()
        {
            _DetalleOrdenCompra = new List<DetalledeOrdenCompra>();
        }

        public DateTime FechaOperacion
        {
            get { return _FechaOperacion; }
            set { _FechaOperacion = value; }
        }
        public string Operacion
        {
            get { return _Operacion; }
            set { _Operacion = value; }
        }
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public List<DetalledeOrdenCompra> DetalleOrdenCompra
        {
            get { return _DetalleOrdenCompra; }
            set { _DetalleOrdenCompra = value; }
        }
        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public string Equipo
        {
            get { return _Equipo; }
            set { _Equipo = value; }
        }
        public FormadeEnvio FormadeEnvio
        {
            get { return _FormadeEnvio; }
            set { _FormadeEnvio = value; }
        }

        public FormadePago FormadePago
        {
            get { return _FormadePago; }
            set { _FormadePago = value; }
        }

        public Proveedor Proveedor
        {
            get { return _Proveedor; }
            set { _Proveedor = value; }
        }

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        public void AgregarDetalle(DetalledeOrdenCompra detalle)
        {
            detalle.SubTotal = detalle.Cantidad * detalle.MateriaPrima.CostoUnitario;
            _Total = _Total + detalle.SubTotal;
            DetalleOrdenCompra.Add(detalle);
        }

        public void EliminarDetalle(DetalledeOrdenCompra detalle)
        {
            _Total = _Total - detalle.SubTotal;
            DetalleOrdenCompra.Remove(detalle);
        }

        public List<DetalledeOrdenCompra> RecuperarDetalles()
        {
            return DetalleOrdenCompra;
        }

    }
}
