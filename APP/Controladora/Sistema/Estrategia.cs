using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Sistema
{
    public abstract class Estrategia
    {
        public  Entidades.Sistema.CuentaCorriente CuentaCorriente { get;  set; }
        public abstract List<Entidades.Sistema.Movimiento> Filtrar(string criterio);

    }
}
