
using System;
namespace Entidades.Seguridad
{
    [Serializable]
    public class Grupo
    {
        private string _Nombre;
        private string _Descripcion;

        /// <summary>
        /// Nombre del Grupo.
        /// </summary>
        public string Nombre
        {
            get { return this._Nombre; }
            set { this._Nombre = value; }
        }
        
        /// <summary>
        /// Descripcion del grupo
        /// </summary>
        public string Descripcion
        {
            get { return this._Descripcion; }
            set { this._Descripcion = value; }
        }

        public override string ToString()
        {
            return this._Nombre;
        }
    }
}
