using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.Backup
{
    public class BaseDeDatos
    {
        private string _CadenaConexion;

        public string CadenaConexion
        {
            get { return _CadenaConexion; }
            set { _CadenaConexion = value; }
        }
        private string _NombreBaseDeDatos;

        public string NombreBaseDeDatos
        {
            get { return _NombreBaseDeDatos; }
            set { _NombreBaseDeDatos = value; }
        }
        private string _NombreBackup;

        public string NombreBackup
        {
            get { return _NombreBackup; }
            set { _NombreBackup = value; }
        }
        private string _Ruta;

        public string Ruta
        {
            get { return _Ruta; }
            set { _Ruta = value; }
        }
        
    }
}
