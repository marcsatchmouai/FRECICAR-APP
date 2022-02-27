using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public abstract class EstrategiaEncriptacion
    {
        public abstract string Encriptar(string unEncryptedPassword);
        public abstract string Desencriptar(string encryptedPassword);

        public abstract void Encriptar();

        public abstract void Desencriptar();

    }
}
