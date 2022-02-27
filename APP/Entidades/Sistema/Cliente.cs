using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    [Serializable]
    public class Cliente
    {
        private int _Codigo;
        private string _RazonSocial;
        private Int64 _Telefono;
        private string _Domicilio;
        private Int64 _Cuit;
        private string _Email;
        private SituacionFiscal _SituacionFiscal;
        private Ciudad _Ciudad;

        public int Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }
        public Ciudad Ciudad
        {
            get { return _Ciudad; }
            set { _Ciudad = value;}
        }
        public SituacionFiscal SituacionFiscal
        {
            get { return _SituacionFiscal; }
            set { _SituacionFiscal = value; }
        }
        public string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }

        public Int64 Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }

        public string Domicilio
        {
            get { return _Domicilio; }
            set { _Domicilio = value; }

        }

        public Int64 Cuit
        {
            get { return _Cuit; }
            set { _Cuit = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public override string ToString()
        {
            return RazonSocial;
        }
    }
}
