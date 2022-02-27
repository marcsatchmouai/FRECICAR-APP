﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Sistema;

namespace Controladora.Sistema
{
    public class EstrategiaFecha : Estrategia
    {
        public override List<Movimiento> Filtrar(string criterio)
        {
            return CuentaCorriente.ListarMovimientos().FindAll(x => x.Fecha.ToString().ToLower().StartsWith(criterio.ToLower())); 
        }
    }
}
