using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    public class RemitoVenta
    {
        private int _NumeroRemitoVenta;
        private Cliente _Cliente;
        private DateTime _Fecha;
        private Decimal _Total;
        private Venta _Venta;

        public int NumeroRemitoVenta
        {
            get { return _NumeroRemitoVenta; }
            set { value = _NumeroRemitoVenta; }
        }

        public Cliente Cliente
        {
            get { return _Cliente; }
            set { value = _Cliente; }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { value = _Fecha; }
        }

        public Venta Venta
        {
            get { return _Venta; }
            set { value = _Venta; }
        }

        public Decimal Total
        {
            get { return _Total; }
            set { value = _Total; }
        }
    }
}
