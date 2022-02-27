using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Sistema
{
    [Serializable]
    public class Provincia
    {
        private string _Nombre;
        private List<Entidades.Sistema.Ciudad> _ciudades;
        public Provincia()
        {
            _ciudades = new List<Ciudad>();
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public List<Ciudad> Ciudades
        {
            get
            {
                return _ciudades;
            }
            
        }
        public void Agregar(Ciudad ciudad)
        {
            ciudad.Provincia = this;
            _ciudades.Add(ciudad);
        }

    }
}
