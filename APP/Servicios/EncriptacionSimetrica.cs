using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public class EncriptacionSimetrica : EstrategiaEncriptacion
    {
        public enum TipoAlgoritmo {Aes, DES, RC2, Rijndael,TripleDES }
        private static TipoAlgoritmo _algoritmo;
        private static ICryptoTransform _cryptoTransform;
        private MemoryStream _memoryStream;
        private CryptoStream _cryptoStream;
        private StreamReader _streamReader;
        private StreamWriter _streamWriter;
        private static string hash = string.Empty;
        private Byte[] bytes;
        public EncriptacionSimetrica(TipoAlgoritmo tipoAlgoritmo)
        {
            _algoritmo = tipoAlgoritmo;
            try
            {
                hash = System.Configuration.ConfigurationManager.AppSettings["EncriptionString"].ToString();
                if (string.IsNullOrEmpty(hash)) throw new Exception("No hay un valor establecito en el Key EncryptionString del archivo de configuración.");
                bytes = Encoding.ASCII.GetBytes(hash);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public override string Encriptar(string unEncryptedPassword)
        {
            try
            {
                switch (_algoritmo)
                {
                    case TipoAlgoritmo.Aes:
                        _cryptoTransform = new AesCryptoServiceProvider().CreateEncryptor(bytes, bytes);
                        break;
                    case TipoAlgoritmo.DES:
                        _cryptoTransform = new DESCryptoServiceProvider().CreateEncryptor(bytes, bytes);
                        break;
                    case TipoAlgoritmo.RC2:
                        _cryptoTransform = new RC2CryptoServiceProvider().CreateEncryptor(bytes, bytes);
                        break;
                    case TipoAlgoritmo.Rijndael:
                        _cryptoTransform = new RijndaelManaged().CreateEncryptor(bytes, bytes);
                        break;
                    case TipoAlgoritmo.TripleDES:
                        _cryptoTransform = new TripleDESCryptoServiceProvider().CreateEncryptor(bytes, bytes);
                        break;
                }
                _memoryStream = new MemoryStream();
                _cryptoStream = new CryptoStream(_memoryStream, _cryptoTransform, CryptoStreamMode.Write);
                _streamWriter = new StreamWriter(_cryptoStream);
                _streamWriter.Write(unEncryptedPassword);
                _streamWriter.Flush();
                _cryptoStream.FlushFinalBlock();
                _streamWriter.Flush();
                string cryptedPassword = Convert.ToBase64String(_memoryStream.GetBuffer(), 0, (int)_memoryStream.Length);
                _memoryStream.Dispose();
                return cryptedPassword;
            }
            catch (CryptographicException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public override string Desencriptar(string encryptedPassword)
        {
            try
            {
                switch (_algoritmo)
                {
                    case TipoAlgoritmo.Aes:
                        _cryptoTransform = new AesCryptoServiceProvider().CreateDecryptor(bytes,bytes);
                        break;
                    case TipoAlgoritmo.DES:
                        _cryptoTransform = new DESCryptoServiceProvider().CreateDecryptor(bytes,bytes);
                        break;
                    case TipoAlgoritmo.RC2:
                        _cryptoTransform = new RC2CryptoServiceProvider().CreateDecryptor(bytes, bytes);
                        break;
                    case TipoAlgoritmo.Rijndael:
                        _cryptoTransform = new RijndaelManaged().CreateDecryptor(bytes, bytes);
                        break;
                    case TipoAlgoritmo.TripleDES:
                        _cryptoTransform = new TripleDESCryptoServiceProvider().CreateDecryptor(bytes, bytes);
                        break;
                }
                _memoryStream = new MemoryStream(Convert.FromBase64String(encryptedPassword));
                _cryptoStream = new CryptoStream(_memoryStream, _cryptoTransform, CryptoStreamMode.Read);
                _streamReader = new StreamReader(_cryptoStream);
                _cryptoStream.Dispose();
                _memoryStream.Dispose();
                return _streamReader.ReadToEnd();
            }
            catch (CryptographicException ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
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
