using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    [Serializable]
    public class PrecioEnvio
    {
        private Decimal _PrecioxBulto;
        private int _Kilometros;
        private Producto _Producto;

        public Decimal PrecioxBulto
        {
            get { return _PrecioxBulto; }
            set { value = _PrecioxBulto; }
        }

        public int Kilometros
        {
            get { return _Kilometros; }
            set { value = _Kilometros; }
        }

        public Producto Producto
        {
            get { return _Producto; }
            set { value = _Producto; }
        }
    }
}
