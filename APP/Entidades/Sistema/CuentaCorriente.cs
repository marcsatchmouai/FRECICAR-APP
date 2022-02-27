using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    [Serializable]
    public class CuentaCorriente
    {
        private int _NumeroCuentaCorriente;
        private decimal _Saldo;
        private Cliente _Cliente;
        private List<Movimiento> _Movimientos;

        public CuentaCorriente()
        {
            _Movimientos = new List<Movimiento>();
        }

        public int NumeroCuentaCorriente
        {
            get { return _NumeroCuentaCorriente; }
            set { _NumeroCuentaCorriente = value; }
        }
        public Decimal Saldo
        {
            get { return _Saldo; }
         }

        public Cliente Cliente
        {
            get { return _Cliente; }
            set { _Cliente = value; }
        }

        public List<Movimiento> Movimientos
        {
            get { return _Movimientos; }
            set { _Movimientos = value; }
        }

        public void AgregarMovimiento(Entidades.Sistema.Movimiento oMovimiento)
        {
            if (oMovimiento.Detalle is Pago || oMovimiento.Detalle is NotaCredito) _Saldo = _Saldo + oMovimiento.Importe;
            else _Saldo = _Saldo - oMovimiento.Importe;
            _Movimientos.Add(oMovimiento);
        }

        public List<Entidades.Sistema.Movimiento> ListarMovimientos()
        {
            return _Movimientos;
        }
    }
}
