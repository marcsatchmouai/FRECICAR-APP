using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    [Serializable]
    public class RemitoProveedor
    {
        private int _Codigo;
        private Proveedor _Proveedor;
        private DateTime _Fecha;
        private List<DetalledeRemitoProveedor> _DetalleRemitoProveedor;
        private Decimal _Total;
        private Int32 _NumeroOrdenCompra;

        public RemitoProveedor()
        {
           _DetalleRemitoProveedor = new List<DetalledeRemitoProveedor>();
        }

        public int NumeroOrdenCompra
        {
            get { return _NumeroOrdenCompra; }
            set { _NumeroOrdenCompra = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public Proveedor Proveedor
        {
            get { return _Proveedor; }
            set { _Proveedor = value; }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public List<DetalledeRemitoProveedor> DetalleRemitoProveedor
        {
            get { return _DetalleRemitoProveedor; }
            set { _DetalleRemitoProveedor = value; }
        }

        public decimal Total
        {
            get { return _Total; }
            set { _Total = value; }
        }

        public void AgregarDetalle(DetalledeRemitoProveedor detalle)
        {
            this._DetalleRemitoProveedor.Add(detalle);
        }

        public void EliminarDetalle(DetalledeRemitoProveedor detalle)
        {
            this._DetalleRemitoProveedor.Remove(detalle);
        }
    }
}
