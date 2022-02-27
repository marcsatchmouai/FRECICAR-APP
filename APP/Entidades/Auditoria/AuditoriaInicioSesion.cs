using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Auditoria
{
    public class AuditoriaInicioSesion
    {
        private string _Usuario;
        private TipoLog _TipoLogin;

        public TipoLog Operacion
        {
            get { return _TipoLogin; }
            set { _TipoLogin = value; }
        }

        public enum TipoLog
        {
            Ingreso,Egreso,Erroneo
        }
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }
        private DateTime _FechaHora;

        public DateTime FechaHora
        {
            get { return _FechaHora; }
            set { _FechaHora = value; }
        }
        
        private string _Equipo;

        public string Equipo
        {
            get { return _Equipo; }
            set { _Equipo = value; }
        }
    }
}
