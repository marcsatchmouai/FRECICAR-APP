using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Entidades.Seguridad
{
    public class Formulario
    {
        private List<Permiso> _Permisos;

        public ReadOnlyCollection<Permiso> Permisos
        {
            get { return _Permisos.AsReadOnly(); }
        }
        private string _Nombre;
        private string _Descripcion;

        public string Descripcion
        {
            get { return this._Descripcion; }
            set { this._Descripcion = value; }
        }

        public string Nombre
        {
            get { return this._Nombre; }
            set { this._Nombre = value; }
        }
        /// <summary>
        /// Constructor de la clase que instancia la colección de permisos.
        /// </summary>
        public Formulario()
        {
            this._Permisos = new List<Permiso>();
        }
        
        /// <summary>
        /// Agrega a la colección de Permisos un objeto de tipo Permiso, en caso que existiese dentro de la colección, no realiza la operación.
        /// </summary>
        /// <param name="oPermiso">Objeto que se agrega a la colección.</param>
        public void AgregarPermiso(Permiso oPermiso)
        {
            if (!this._Permisos.Contains(oPermiso)) this._Permisos.Add(oPermiso);
        }

        /// <summary>
        /// Elimina de la colección de Permisos un objeto de tipo Permiso, en caso de que no existiese dentro de la colección, no realiza ningua operación.
        /// </summary>
        /// <param name="oPermiso">Objeto que se elimina de la colección.</param>
        public void EliminarPermiso(Permiso oPermiso)
        {
            if (this._Permisos.Contains(oPermiso)) this._Permisos.Remove(oPermiso);
        }

        public Permiso Buscar(Permiso permiso)
        {
            return _Permisos.Find(opermiso => opermiso.Nombre == permiso.Nombre);
        }
    }
}
