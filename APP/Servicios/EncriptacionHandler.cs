using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class EncriptacionHandler
    {
        private EstrategiaEncriptacion _estrategia;

        public EncriptacionHandler(EstrategiaEncriptacion estrategia)
        {
            _estrategia = estrategia;
        }

        public string Encriptar(string passSinEncriptar)
        {
            if(_estrategia is EncriptacionAplicacion) throw new InvalidOperationException("No se puede utilizar esta estrategia para este tipo de encriptación.");
            else return _estrategia.Encriptar(passSinEncriptar);
        }
        public string Desencriptar(string passEncriptado)
        {
            if (_estrategia is EncriptacionAplicacion) throw new InvalidOperationException("No se puede utilizar esta estrategia para este tipo de encriptación.");
            else return _estrategia.Desencriptar(passEncriptado);
        }
        public void Encriptar()
        {
            if (_estrategia is EncriptacionAplicacion) _estrategia.Encriptar();
            else throw new InvalidOperationException("No se puede utilizar esta estrategia para este tipo de encriptación.");
        }
        public void Desencriptar()
        {
            if (_estrategia is EncriptacionAplicacion) _estrategia.Desencriptar();
            else throw new InvalidOperationException("No se puede utilizar esta estrategia para este tipo de encriptación.");
        }
    }
}
