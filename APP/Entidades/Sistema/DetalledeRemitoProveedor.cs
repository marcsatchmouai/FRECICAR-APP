using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    [Serializable]
    public class DetalledeRemitoProveedor
    {
        
        private int _Cantidad;
        private MateriaPrima _MateriaPrima;
        private decimal _SubTotal;

        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        public MateriaPrima MateriaPrima
        {
            get { return _MateriaPrima; }
            set { _MateriaPrima = value; }
        }

        public decimal SubTotal
        {
            get { return _SubTotal; }
            set { _SubTotal = value; }
        }
    }
}
