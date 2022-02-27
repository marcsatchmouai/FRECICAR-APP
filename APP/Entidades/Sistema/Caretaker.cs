using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    [Serializable]

    public class Caretaker
    {
        
        private List<Entidades.Sistema.Memento> _Mementos;

        private Memento oMemento;
        public Caretaker()
        {
            _Mementos = new List<Memento>();
        }

        public void AgregarMemento(Memento oMemento)
        {
            _Mementos.Add(oMemento);
        }

        public Memento EliminarMemento()
        {
            if (_Mementos.Count > 0)
            {

                Memento memento = _Mementos[_Mementos.Count - 1];
                _Mementos.Remove(memento);
                return memento;


            }
            else
            {
                return null;
            }
        }
    }
}
