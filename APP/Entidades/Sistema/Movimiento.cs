using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    [Serializable]
    public class Movimiento
    {
        IDetalle _Detalle;
        DateTime _Fecha;
        Decimal _Importe;
        String _TipoMovimiento;
  
        public string TipoMovimiento
        {
            get { return _TipoMovimiento; }
            set { _TipoMovimiento = value; }
        }
        public IDetalle Detalle
        {
            get { return _Detalle; }
            set { _Detalle = value; }
        }
        
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public decimal Importe
        {
            get { return _Importe; }
            set { _Importe = value; }
        }
        public override string ToString()
        {
            return _Detalle.Detalle;
        }
    }
}
