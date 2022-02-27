using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    class EnvioTercero : Envio
    {
        private int _NumeroTercero;
        private string _Responsable;
        private int _DniResponsable;
        private int _TelResponsable;
        private string _NombreEmpresa;

        public int NumeroTercero
        {
            get { return _NumeroTercero; }
            set { value = _NumeroTercero; }
        }

        public string Responsable
        {
            get { return _Responsable; }
            set { value = _Responsable; }
        }

        public int DniResposable
        {
            get { return _DniResponsable; }
            set { value = _DniResponsable; }
        }
        public int TelResposable
        {
            get { return _TelResponsable; }
            set { value = _TelResponsable; }
        }

        public string NombreEmpresa
        {
            get { return _NombreEmpresa; }
            set { value = _NombreEmpresa; }
        }

    }
}
