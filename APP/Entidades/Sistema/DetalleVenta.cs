using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    [Serializable]
    public class DetalleVenta
    {

        private Producto _Producto;
        private Decimal _SubTotal;
        private int _Cantidad;

        public Producto Producto
        {
            get { return _Producto; }
            set { _Producto = value; }
        }
        public Decimal SubTotal
        {
            get { return _SubTotal; }
            set { _SubTotal = value; }
        }
        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }
    }
}
