using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Sistema;

namespace Controladora.Sistema
{
    public class EstrategiaTipoMovimiento : Estrategia
    {
        public override List<Movimiento> Filtrar(string criterio)
        {
            return CuentaCorriente.ListarMovimientos().FindAll(x => x.TipoMovimiento.ToString().ToLower().StartsWith(criterio.ToLower()));
        }
    }
}
