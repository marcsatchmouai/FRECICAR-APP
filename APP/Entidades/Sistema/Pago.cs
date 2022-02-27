using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    [Serializable]
    public class Pago : IDetalle
    {
        int _Codigo;
        Cliente _Cliente;
        DateTime _Fecha;
        Decimal _Importe;
        string _detalle;
        Venta _Venta;

        public Venta Venta
        {
            get { return _Venta; }
            set { _Venta = value; }
        }

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public Cliente Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public Decimal Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }

        public string Detalle
        {
            get
            {
                return _detalle;
            }

            set
            {
                _detalle = value;
            }
        }

        public override string ToString()
        {
            return Detalle;
        }
    }
}
