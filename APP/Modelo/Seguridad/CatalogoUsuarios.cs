using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
namespace Modelo.Seguridad
{
    class CatalogoUsuarios
    {
        private List<Entidades.Seguridad.Usuario> _Usuarios;
        private Entidades.Seguridad.Memento.CaretakerUsuario _Cuidador;
        private static CatalogoUsuarios _Instancia;
        
        public static CatalogoUsuarios ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new CatalogoUsuarios();
            return _Instancia;
        }
        
        private CatalogoUsuarios()
        {
            this._Usuarios = Mapping.Seguridad.MappingUsuarios.RecuperarUsuarios();
        }

        public Entidades.Seguridad.Usuario BuscarUsuario(string nombreUsuario)
        {
            Entidades.Seguridad.Usuario usuarioEncontrado = _Usuarios.Find(delegate (Entidades.Seguridad.Usuario usuario) {return nombreUsuario.ToLower() == usuario.NombreUsuario.ToLower();});
            if (usuarioEncontrado != null)
            {
                _Cuidador = new Entidades.Seguridad.Memento.CaretakerUsuario();
                _Cuidador.Memento = usuarioEncontrado.CrearMemento();
            }
            return usuarioEncontrado;
        }

        public bool AgregarUsuario(Entidades.Seguridad.Usuario usuario)
        {
            bool operacion = false;
            if (Mapping.Seguridad.MappingUsuarios.AgregarUsuario(usuario))
            {
                operacion = true;
                if (_Usuarios.Find(usu => usu.NombreUsuario == usuario.NombreUsuario) == null)
                {
                    _Usuarios.Add(usuario);
                    operacion = true;
                }
            }
            return operacion;
        }

        public bool ModificarUsuario(Entidades.Seguridad.Usuario usuario)
        {
            bool operacion = false;
            this.BuscarUsuario(usuario.NombreUsuario);
            if (Mapping.Seguridad.MappingUsuarios.ModificarUsuario(usuario) && Mapping.Seguridad.MappingUsuarios.ActualizarGrupos(usuario, _Cuidador))
            {
                operacion = true;
                if (_Usuarios.Find(ousuario => ousuario.NombreUsuario == usuario.NombreUsuario) != null)
                {
                    _Usuarios.Remove(usuario);
                    _Usuarios.Add(usuario);
                    operacion = true;
                }
            }
            else
            {
                usuario.ReestablecerMemento(_Cuidador.Memento);
                operacion = false;
            }
            _Cuidador = null;
            return operacion;
        }

        public bool EliminarUsuario(Entidades.Seguridad.Usuario usuario)
        {
            bool operacion = false;
            if (Mapping.Seguridad.MappingUsuarios.EliminarUsuario(usuario))
            {
                operacion = true;
                if (_Usuarios.Find(ousuario => ousuario.NombreUsuario  == usuario.NombreUsuario) != null)
                {
                    _Usuarios.Remove(usuario);
                    operacion = true;
                }
                else operacion  = false;
            }
            return operacion;
        }

        /// <summary>
        /// Busca si el grupo que se envia por parámetro esta contenido en algún objeto usuario de la coleccion
        /// </summary>
        /// <param name="grupo">objeto grupo que se buscará</param>
        /// <returns>true: la busqueda no devolvió resultados, false: se encontró al menos una coincidencia</returns>
        public bool BuscarGruposUsuario(Entidades.Seguridad.Grupo grupo)
        {
            if (_Usuarios.Find(ogrupo => ogrupo.Grupos.Contains(grupo)) != null)
                return true;
            else return false;
        }

        public ReadOnlyCollection<Entidades.Seguridad.Usuario> RecuperarUsuarios()
        {
            return _Usuarios.AsReadOnly();
        }

        public ReadOnlyCollection<Entidades.Seguridad.Usuario> FiltrarUsuarios(string criterio)
        {
            return _Usuarios.FindAll(usu => usu.NombreUsuario.ToLower().Contains(criterio.ToLower()) || usu.NombreApellido.ToLower().Contains(criterio.ToLower())).AsReadOnly();
        }
    }
}
