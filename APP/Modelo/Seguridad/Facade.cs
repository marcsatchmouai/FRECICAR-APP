using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Modelo.Seguridad
{
    public class Facade
    {
        private static Facade _Instancia;
        public static Facade ObtenerInstancia()
        {
            if (_Instancia == null) _Instancia = new Facade();
            return _Instancia;
        }

        public bool Agregar(object objeto)
        {
            if (objeto is Entidades.Seguridad.Usuario)
            {
                return CatalogoUsuarios.ObtenerInstancia().AgregarUsuario((Entidades.Seguridad.Usuario)objeto);
            }
            if (objeto is Entidades.Seguridad.Grupo)
            {
                return CatalogoGrupos.ObtenerInstancia().AgregarGrupo((Entidades.Seguridad.Grupo)objeto);
            }
            else
            {
                return CatalogoPerfiles.ObtenerInstancia().AgregarPerfil((Entidades.Seguridad.Perfil)objeto);
            }

        }

        public object Recuperar(string entidad)
        {
            if (entidad == "Usuario") return CatalogoUsuarios.ObtenerInstancia().RecuperarUsuarios();
            if (entidad == "Perfil") return CatalogoPerfiles.ObtenerInstancia().RecuperarPerfiles();
            if (entidad == "Grupo") return CatalogoGrupos.ObtenerInstancia().RecuperarGrupos();
            if (entidad == "Formulario") return CatalogoFormularios.ObtenerInstancia().RecuperarPermisos();
            if (entidad == "Permiso") return CatalogoPermisos.ObtenerInstancia().RecuperarPermisos();
            else throw new Exception("No se puede Recuperar con la entidad especificada.");
        }

        public bool Eliminar(object Objeto)
        {
            if (Objeto is Entidades.Seguridad.Usuario)
            {
                return CatalogoUsuarios.ObtenerInstancia().EliminarUsuario((Entidades.Seguridad.Usuario)Objeto);
            }
            if (Objeto is Entidades.Seguridad.Grupo)
            {
                return CatalogoGrupos.ObtenerInstancia().EliminarGrupo((Entidades.Seguridad.Grupo)Objeto);
            }
            else
            {
                return CatalogoPerfiles.ObtenerInstancia().EliminarPerfil((Entidades.Seguridad.Perfil)Objeto);
            }
        }

        public bool Modificar(object Objeto)
        {
            if (Objeto is Entidades.Seguridad.Usuario) return CatalogoUsuarios.ObtenerInstancia().ModificarUsuario((Entidades.Seguridad.Usuario)Objeto);
            if (Objeto is Entidades.Seguridad.Grupo) return CatalogoGrupos.ObtenerInstancia().ModificarGrupo((Entidades.Seguridad.Grupo)Objeto);
            else return CatalogoPerfiles.ObtenerInstancia().ModificarPerfil((Entidades.Seguridad.Perfil)Objeto);
        }

        public object Buscar(string Entidad, string NombreObjeto)
        {
            if (Entidad == "Usuario") return CatalogoUsuarios.ObtenerInstancia().BuscarUsuario(NombreObjeto);
            if (Entidad == "Grupo") return CatalogoGrupos.ObtenerInstancia().BuscarGrupo(NombreObjeto);
            if (Entidad == "Perfil") return CatalogoPerfiles.ObtenerInstancia().BuscarPerfil(NombreObjeto);
            else throw new Exception("No se puede Buscar con la entidad especificada.");
        }

        public object Filtrar(string Entidad, string Criterio)
        {
            if (Entidad == "Usuario") return CatalogoUsuarios.ObtenerInstancia().FiltrarUsuarios(Criterio);
            if (Entidad == "Grupo") return CatalogoGrupos.ObtenerInstancia().FiltrarGrupos(Criterio);
            if (Entidad == "Perfiles") return CatalogoPerfiles.ObtenerInstancia().FiltrarPerfiles(Criterio);
            else throw new Exception("No se puede filtar con la entidad especificada.");
        }

        public bool BusquedaCompuesta(string Entidad, object Objeto)
        {
            if (Entidad == "Usuario") return CatalogoUsuarios.ObtenerInstancia().BuscarGruposUsuario((Entidades.Seguridad.Grupo)Objeto);
            if (Entidad == "Grupo") return CatalogoPerfiles.ObtenerInstancia().BuscarGrupoPerfil((Entidades.Seguridad.Grupo)Objeto);
            else throw new Exception("No se puede Buscar con la entidad especificada.");
        }

        public ReadOnlyCollection<Entidades.Seguridad.Perfil> RecuperarPerfilesGrupos(Entidades.Seguridad.Usuario Usuario)
        {
            return CatalogoPerfiles.ObtenerInstancia().RecuperarPerfilesGrupos(Usuario);
        }
    }
}
