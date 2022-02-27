using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    [Serializable]
    public class SituacionFiscal
    {
        private int _Codigo;
        private String _Descripcion;

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        public String Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
