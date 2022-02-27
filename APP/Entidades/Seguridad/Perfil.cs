using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Entidades.Seguridad
{
    public class Perfil
    {
        private List<Formulario> _Formularios;

        public ReadOnlyCollection<Formulario> Formularios
        {
            get { return _Formularios.AsReadOnly(); }
        }
        private Grupo _Grupo;

        public Grupo Grupo
        {
            get { return this._Grupo; }
            set { this._Grupo = value; }
        }

        /// <summary>
        /// Constructor de la clase que instancia una lista de Formularios
        /// </summary>
        public Perfil()
        {
           this._Formularios = new List<Formulario>();
        }
    
        public bool AgregarFormulario(Formulario formulario)
        {
            if (this._Formularios.Find(form => form.Nombre == formulario.Nombre) == null)
            {
                this._Formularios.Add(formulario);
                return true;
            }
            else return false;    
        }

        public bool EliminarFormulario(Formulario formulario)
        {
            if (this._Formularios.Find(form => form.Nombre == formulario.Nombre) != null)
            {
                this._Formularios.Remove(formulario);
                return true;
            }
            else return false;
        }

        public Entidades.Seguridad.Formulario Buscar(string nombre)
        {
            return _Formularios.Find(delegate(Entidades.Seguridad.Formulario oform) {return oform.Nombre == nombre ;});
        }

        public Memento.MementoPerfil CrearMemento()
        {
            return new Memento.MementoPerfil(this._Formularios);
        }

        public void ReestablecerMemento(Memento.MementoPerfil memento)
        {
            this._Formularios = null;
            this._Formularios = memento.Formularios;            
        }
    }
}
