using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    public class Memento
    {

        private Venta _Originator;

        public Memento (Venta State)
        {
            MemoryStream m = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(m, State);
            m.Position = 0;
            _Originator = (Entidades.Sistema.Venta)b.Deserialize(m);
        }

        public Venta GetMemento()
        {
            return _Originator;
        }
    }
}
