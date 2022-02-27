using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Modelo.Seguridad
{
    class CatalogoGrupos
    {
        private static CatalogoGrupos _Instancia;
        private List<Entidades.Seguridad.Grupo> _Grupos;
        
        private CatalogoGrupos()
        {
           this._Grupos = Mapping.Seguridad.MappingGrupos.RecuperarGrupos(); 
        }
        
        public static CatalogoGrupos ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoGrupos();
            return _Instancia;
        }
        
        public bool AgregarGrupo(Entidades.Seguridad.Grupo grupo)
        {
            bool operacion = false;
            if (Mapping.Seguridad.MappingGrupos.AgregarGrupo(grupo))
            {
                operacion = true;
                if (this._Grupos.Find(ogrupo => ogrupo.Nombre == grupo.Nombre) == null)
                {
                    this._Grupos.Add(grupo);
                    operacion = true;
                }
                else operacion = false;
            }
            return operacion;
        }

        public bool ModificarGrupo(Entidades.Seguridad.Grupo grupo)
        {
            bool operacion = false;
            if(Mapping.Seguridad.MappingGrupos.ModificarGrupo(grupo))
            {
                operacion = true;
                if (this._Grupos.Find(ogrupo => ogrupo.Nombre == grupo.Nombre) != null)
                {
                    this._Grupos.Remove(grupo);
                    this._Grupos.Add(grupo);
                    operacion = true;
                }
            }
            return operacion;
        }

        public bool EliminarGrupo(Entidades.Seguridad.Grupo grupo)
        {
            bool operacion = false;
            if (Mapping.Seguridad.MappingGrupos.EliminarGrupo(grupo))
            {
                operacion = true;
                if (this._Grupos.Find(ogrupo => ogrupo.Nombre == grupo.Nombre) != null)
                {
                    this._Grupos.Remove(grupo);
                    operacion = true;
                }
                else operacion = false; 
            }
            return operacion;
        }

        public Entidades.Seguridad.Grupo BuscarGrupo(string nombreGrupo)
        {
            return this._Grupos.Find(delegate(Entidades.Seguridad.Grupo grupo) { return grupo.Nombre == nombreGrupo; });
        }

        public ReadOnlyCollection<Entidades.Seguridad.Grupo> RecuperarGrupos()
        {
            return this._Grupos.AsReadOnly();
        }

        public ReadOnlyCollection<Entidades.Seguridad.Grupo> FiltrarGrupos(string grupo)
        {
            return this._Grupos.FindAll(delegate(Entidades.Seguridad.Grupo oGrupo) { return oGrupo.Nombre.ToLower().Contains(grupo.ToString().ToLower()) || oGrupo.Descripcion.ToLower().Contains(grupo.ToString().ToLower()); }).AsReadOnly();
        }
    }
}
