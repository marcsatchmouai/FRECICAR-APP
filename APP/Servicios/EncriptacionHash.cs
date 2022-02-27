using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class EncriptacionHash : EstrategiaEncriptacion
    {
        public enum TipoAlgoritmo {KeyedHashAlgorithm ,MD5, RIPEMD160, SHA1, SHA256, SHA384, SHA512 }
        private TipoAlgoritmo _algoritmo;
        private HashAlgorithm _algoritmoHash;
        private Byte[] bytes;
        public EncriptacionHash(TipoAlgoritmo tipoAlgoritmo)
        {
            _algoritmo = tipoAlgoritmo;
      
        }

        public override string Encriptar(string unEncryptedPassword)
        {
            try
            {
                switch (_algoritmo)
                {
                    case TipoAlgoritmo.KeyedHashAlgorithm:
                        _algoritmoHash = KeyedHashAlgorithm.Create();
                        break;
                    case TipoAlgoritmo.MD5:
                        _algoritmoHash = MD5.Create();
                        break;
                    case TipoAlgoritmo.RIPEMD160:
                        _algoritmoHash = RIPEMD160.Create();
                        break;
                    case TipoAlgoritmo.SHA1:
                        _algoritmoHash = SHA1.Create();
                        break;
                    case TipoAlgoritmo.SHA256:
                        _algoritmoHash = SHA256.Create();
                        break;
                    case TipoAlgoritmo.SHA384:
                        _algoritmoHash = SHA384.Create();
                        break;
                    case TipoAlgoritmo.SHA512:
                        _algoritmoHash = SHA512.Create();
                        break;
                }
                bytes = Encoding.ASCII.GetBytes(unEncryptedPassword);
                byte[] resultado = _algoritmoHash.ComputeHash(bytes);
                return new ASCIIEncoding().GetString(resultado);
            }
            catch (CryptographicException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }


        public override string Desencriptar (string encryptedPassword)
        {
            throw new InvalidOperationException("No se puede desencriptar un Algorimo Hash");
        }

        public override void Encriptar()
        {
            throw new InvalidOperationException("Este metodo solo puede ejecutarse cuando la estrategia es EncriptacionAplicacion");
        }

        public override void Desencriptar()
        {
            throw new InvalidOperationException("Este metodo solo puede ejecutarse cuando la estrategia es EncriptacionAplicacion");
        }
    }
}
