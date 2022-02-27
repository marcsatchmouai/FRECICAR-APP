using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    public class EnvioPropio : Envio
    {
        private int _NumeroEnvioPropio;
        private int _NumeroTraking;
        private decimal _CostoEnvio;

        public int NumeroEnvioPropio
        {
            get { return _NumeroEnvioPropio; }
            set { value = _NumeroEnvioPropio; }
        }

        public int NumeroTraking
        {
            get { return _NumeroTraking; }
            set { value = _NumeroTraking; }
        }

        public decimal CostoEnvio
        {
            get { return _CostoEnvio; }
            set { value = _CostoEnvio; }
        }
    }
}
