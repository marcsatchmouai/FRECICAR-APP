using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System;
[assembly: CLSCompliant(true)]
namespace Entidades.Seguridad
{
    [Serializable]
    public class Usuario 
    {   
        private List<Grupo> _Grupos;

        public ReadOnlyCollection<Grupo> Grupos
        {
            get { return _Grupos.AsReadOnly(); }
        }
        private string _Email;

        private string _NombreUsuario;
        private string _Clave;
        private string _NombreApellido;
        private bool _Activo;
        private bool _Habilitado;
        private bool _CambioContraseña = false;

        public bool CambioContraseña
        {
            get { return _CambioContraseña; }
        }
        public bool Habilitado
        {
            get { return this._Habilitado; }
            set { this._Habilitado = value; }
        }

        public string NombreUsuario
        {
            get { return this._NombreUsuario; }
            set { this._NombreUsuario = value; }
        }
        
        public string Clave
        {
            get { return this._Clave; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string NombreApellido
        {
            get { return this._NombreApellido; }
            set { this._NombreApellido = value; }
        }

        public bool Activo
        {
            get { return this._Activo; }
            set { this._Activo = value; }
        }
        
        public Usuario()
        {
            this._Grupos = new List<Grupo>();
        }
        
        public bool AgregarGrupo(Grupo grupo)
        {
            bool operacion = false;
            if (this._Grupos.Find(ogrupo => ogrupo.Nombre == grupo.Nombre) == null)
            {
                this._Grupos.Add(grupo);
                operacion = true;
            }
            else operacion = false;
            return operacion;
        }
        
        public bool EliminarGrupo(Grupo grupo)
        {
            bool operacion = false;
            if (this._Grupos.Find(ogrupo => ogrupo.Nombre == grupo.Nombre) != null)
            {
                this._Grupos.Remove(grupo);
                operacion = true;
            }
            else operacion = false;
            return operacion;
        }

        public bool CambiarClave(string claveVieja, string claveNueva)
        {
            bool operacion = false;
            if (this._Clave == claveVieja)
            {
                _CambioContraseña = true;
                this._Clave = claveNueva;
                operacion = true;
            }
            else operacion = false;
            return operacion;
        }

        public override string ToString()
        {
            return this._NombreUsuario;
        }

        public Memento.MementoUsuario CrearMemento()
        {
            return new Memento.MementoUsuario(this);
        }

        public void ReestablecerMemento(Memento.MementoUsuario memento)
        {
            this._Grupos = null;
            Entidades.Seguridad.Grupo[] grupo = new Entidades.Seguridad.Grupo[memento.Grupos.Count]; 
            grupo = memento.Grupos.ToArray();
            this._Grupos = grupo.ToList();
        }
    }
}
