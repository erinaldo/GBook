using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Encriptacion
    {
        #region Keys AES
        private readonly string IV = ConfigurationManager.AppSettings["AES_KeyIV"]; //16 chars = 128 bytes
        private readonly string key = ConfigurationManager.AppSettings["AES_Key"];  // 32 chars = 256 bytes
        #endregion

        #region Hash SHA256
        public string Hash(string texto)
        {
            UnicodeEncoding codificar = new UnicodeEncoding();
            byte[] textobyte = codificar.GetBytes(texto);
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            byte[] tablaBytes = sha256.ComputeHash(textobyte);
            string textoCifrado = Convert.ToBase64String(tablaBytes).ToString();
            return textoCifrado;
        }
        #endregion

        #region Algoritmo Encriptación AES
        public string EncriptarAES(string decrypted)
        {
            byte[] textbytes = ASCIIEncoding.ASCII.GetBytes(decrypted);
            AesCryptoServiceProvider encdec = new AesCryptoServiceProvider();
            encdec.BlockSize = 128;
            encdec.KeySize = 256;
            encdec.Key = ASCIIEncoding.ASCII.GetBytes(key);
            encdec.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            encdec.Padding = PaddingMode.PKCS7;
            encdec.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = encdec.CreateEncryptor(encdec.Key, encdec.IV);

            byte[] enc = icrypt.TransformFinalBlock(textbytes, 0, textbytes.Length);
            icrypt.Dispose();

            return Convert.ToBase64String(enc);
        }

        public string DesencriptarAES(string encrypted)
        {
            byte[] encbytes = Convert.FromBase64String(encrypted);
            AesCryptoServiceProvider encdec = new AesCryptoServiceProvider();
            encdec.BlockSize = 128;
            encdec.KeySize = 256;
            encdec.Key = ASCIIEncoding.ASCII.GetBytes(key);
            encdec.IV = ASCIIEncoding.ASCII.GetBytes(IV);
            encdec.Padding = PaddingMode.PKCS7;
            encdec.Mode = CipherMode.CBC;

            ICryptoTransform icrypt = encdec.CreateDecryptor(encdec.Key, encdec.IV);

            byte[] dec = icrypt.TransformFinalBlock(encbytes, 0, encbytes.Length);
            icrypt.Dispose();

            return ASCIIEncoding.ASCII.GetString(dec);
        }

        public string GenerarPasswordRandom()
        {
            string Password = "";
            
            Random random = new Random();
            string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = caracteresPermitidos.Length;            
            char letra;
            int longitudPassword = 8;

            for (int i = 0; i < longitudPassword; i++)
            {
                letra = caracteresPermitidos[random.Next(longitud)];
                Password += letra.ToString();
            }

            return Password;
        }
        #endregion
    }
}
