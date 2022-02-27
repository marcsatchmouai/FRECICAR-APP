using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    public class Envio
    {
        private int _NumeroEnvio;
        private Cliente _Cliente;
        private RemitoVenta _RemitoVenta;
        private Enum _Estado;
        private DateTime _Fecha;

        public int NumeroEnvio
        {
            get { return _NumeroEnvio; }
            set { value = _NumeroEnvio; }
        }

        public Cliente Cliente
        {
            get { return _Cliente; }
            set { value = _Cliente; }
        }

        public Enum Estado
        {
            get { return _Estado; }
            set { value = _Estado; }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { value = _Fecha; }
        }

        public RemitoVenta RemitoVenta
        {
            get { return _RemitoVenta; }
            set { value = _RemitoVenta; }
        }
    }
}
