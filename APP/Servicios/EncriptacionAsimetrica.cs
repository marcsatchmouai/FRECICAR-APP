using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class EncriptacionAsimetrica : EstrategiaEncriptacion
    {
        public enum TipoAlgoritmo { RSA }
        private TipoAlgoritmo _tipoAlgoritmo;
        private byte[] plaintext;
        private byte[] encryptedData;
        private UnicodeEncoding _conversor;
        public EncriptacionAsimetrica(TipoAlgoritmo algoritmo)
        {
            _tipoAlgoritmo = algoritmo;
            _conversor = new UnicodeEncoding();
        }

        public override string Encriptar(string unEncryptedPassword)
        {
            try
            {
                plaintext = _conversor.GetBytes(unEncryptedPassword);
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSA.ExportParameters(false));
                    encryptedData = RSA.Encrypt(plaintext, false);
                }
                return _conversor.GetString(encryptedData);
            }
            catch (CryptographicException e)
            {
                throw new Exception(e.Message,e.InnerException);
            }
        }

        public override string Desencriptar(string encryptedPassword)
        {
            try
            {
                plaintext = _conversor.GetBytes(encryptedPassword);
                byte[] encryptedData;
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    RSA.ImportParameters(RSA.ExportParameters(true));
                    encryptedData = RSA.Decrypt(plaintext, false);
                }
                return _conversor.GetString(encryptedData);
            }
            catch (CryptographicException e)
            {
                throw new Exception(e.Message, e.InnerException);
            }
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
