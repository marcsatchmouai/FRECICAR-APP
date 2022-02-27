using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Entidades.Seguridad.Memento
{
    public class MementoUsuario
    {
        private List<Entidades.Seguridad.Grupo> _Grupos;

        public ReadOnlyCollection<Entidades.Seguridad.Grupo> Grupos
        {
            get { return _Grupos.AsReadOnly(); }
        }
        public MementoUsuario(Entidades.Seguridad.Usuario usuario)
        {
            Entidades.Seguridad.Grupo[] grupos = new Entidades.Seguridad.Grupo[usuario.Grupos.Count];
            grupos = usuario.Grupos.ToArray();
            _Grupos = grupos.ToList();
            grupos = null;
        }
    }
}
