using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Controladora.Sistema
{
    public class Validaciones
    {
        public static bool ValidarDecimal(string valor)
        {
            if (Regex.IsMatch(valor, "^(\\$|)([1-9]\\d{0,2}(\\.\\d{3})*|([1-9]\\d*))(\\,\\d{2})?$")) return true;
            else return false;  
        } 
    }
}
