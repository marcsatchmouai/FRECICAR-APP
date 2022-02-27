using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Seguridad
{
    public class DatosCorreo
    {
        private string _DireccionMail;

        public string DireccionMail
        {
            get { return _DireccionMail; }
            set { _DireccionMail = value; }
        }
        private string _Smtp;

        public string Smtp
        {
            get { return _Smtp; }
            set { _Smtp = value; }
        }
        private int _PuertoSmtp;

        public int PuertoSmtp
        {
            get { return _PuertoSmtp; }
            set { _PuertoSmtp = value; }
        }
        private string _Usuario;

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        private string _Clave;

        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }
        private bool _UsaCredencialesDefault;

        public bool UsaCredencialesDefault
        {
            get { return _UsaCredencialesDefault; }
            set { _UsaCredencialesDefault = value; }
        }
        private bool _SSL;

        public bool SSL
        {
            get { return _SSL; }
            set { _SSL = value; }
        }
        private string _NombreEmisor;
        public string NombreEmisor
        {
            get { return _NombreEmisor; }
            set { _NombreEmisor = value; }
        }

    }
}
