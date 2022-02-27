using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace Modelo.Seguridad
{
    class CatalogoPerfiles
    {
        private static CatalogoPerfiles _Instancia;
        private List<Entidades.Seguridad.Perfil> _Perfiles;
        private Entidades.Seguridad.Memento.CaretakerPerfil _Cuidador;
 
        private CatalogoPerfiles()
        {
            _Perfiles = Mapping.Seguridad.MappingPerfiles.RecuperarPerfiles();
        }

        
        public static CatalogoPerfiles ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoPerfiles();
            return _Instancia;
        }

        public bool AgregarPerfil(Entidades.Seguridad.Perfil perfil)
        {
            bool operacion = false;
            if (Mapping.Seguridad.MappingPerfiles.AgregarPerfil(perfil))
            {
                operacion = true;
                if (_Perfiles.Find(operfil => operfil.Grupo.Nombre == perfil.Grupo.Nombre) == null)
                {
                    _Perfiles.Add(perfil);
                    operacion = true;
                }
            }
            return operacion;
        }

        public bool ModificarPerfil(Entidades.Seguridad.Perfil perfil)
        {
            bool operacion = false;
            if (Mapping.Seguridad.MappingPerfiles.ModificarPerfil(perfil, _Cuidador))
            {
                operacion = true;
                if(this._Perfiles.Find(operfil => operfil.Grupo.Nombre == perfil.Grupo.Nombre) != null)
                {
                    _Perfiles.Remove(perfil);
                    _Perfiles.Add(perfil);
                    operacion = true;
                }
            }
            else
            {
                perfil.ReestablecerMemento(_Cuidador.Memento);
                operacion = false;
            }
            _Cuidador = null;
            return operacion;
        }

        public bool EliminarPerfil(Entidades.Seguridad.Perfil perfil)
        { 
            bool operacion = false;
            if (Mapping.Seguridad.MappingPerfiles.EliminarPerfil(perfil))
            {
                operacion = true;
                if (_Perfiles.Find(operfil => operfil.Grupo.Nombre == perfil.Grupo.Nombre) != null)
                {
                    _Perfiles.Remove(perfil);
                    operacion = true;
                }
            }
            return operacion;
        }
        
        /// <summary>
        /// Busca si el grupo que se envia por parámetro esta contenido en algún objeto perfil de la coleccion
        /// </summary>
        /// <param name="grupo">objeto grupo que se buscará</param>
        /// <returns>true: la busqueda no devolvió resultados, false: se encontró al menos una coincidencia</returns>
        
        public bool BuscarGrupoPerfil(Entidades.Seguridad.Grupo grupo)
        {
            if (_Perfiles.Find(operfil => operfil.Grupo.Nombre == grupo.Nombre) != null)
                return true;
            else return false;
        }

        public ReadOnlyCollection<Entidades.Seguridad.Perfil> RecuperarPerfiles()
        {
            return _Perfiles.AsReadOnly();
        }

        public Entidades.Seguridad.Perfil BuscarPerfil(string grupo)
        {
            Entidades.Seguridad.Perfil oPerfil = new Entidades.Seguridad.Perfil();
            oPerfil = _Perfiles.Find(delegate(Entidades.Seguridad.Perfil perfil) { return perfil.Grupo.Nombre == grupo; });
            if (oPerfil != null) 
            {
                _Cuidador = new Entidades.Seguridad.Memento.CaretakerPerfil();
                _Cuidador.Memento = oPerfil.CrearMemento();
            }
            return oPerfil;
        }

        public ReadOnlyCollection<Entidades.Seguridad.Perfil> RecuperarPerfilesGrupos(Entidades.Seguridad.Usuario usuario)
        {
            List<Entidades.Seguridad.Perfil> perfilesEncontrados = new List<Entidades.Seguridad.Perfil>();
            foreach (Entidades.Seguridad.Grupo oGrupo in usuario.Grupos)
            {
               List<Entidades.Seguridad.Perfil> perfilesParciales = _Perfiles.FindAll(delegate (Entidades.Seguridad.Perfil operfil) {return operfil.Grupo.Nombre == oGrupo.Nombre;});
               foreach (Entidades.Seguridad.Perfil operfil in perfilesParciales)
               {
                   perfilesEncontrados.Add(operfil);
               }
            }
            return perfilesEncontrados.AsReadOnly();
        }
        
        public ReadOnlyCollection<Entidades.Seguridad.Perfil> FiltrarPerfiles(string stringBusqueda)
        {
            return _Perfiles.FindAll(delegate(Entidades.Seguridad.Perfil perfil) { return perfil.Grupo.Nombre.ToLower().Contains(stringBusqueda);}).AsReadOnly();
        }
    }
}
        