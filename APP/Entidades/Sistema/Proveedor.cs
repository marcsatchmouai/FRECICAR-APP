using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    [Serializable]
    public class Proveedor
    {
        private Int64 _Cuit;
        private string _RazonSocial;
        private string _Telefono;
        private string _DireccionCalle;
        private string _DireccionNumero;
        public string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }

        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public string DireccionCalle
        {
            get { return _DireccionCalle; }
            set { _DireccionCalle = value; }
        }
        public string DireccionNumero
        {
            get { return _DireccionNumero; }
            set { _DireccionNumero = value; }
        }

        public Int64 Cuit
        {
            get { return _Cuit; }
            set { _Cuit = value; }
        }

        public override string ToString()
        {
            return RazonSocial;
        }
    }
}
