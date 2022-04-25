using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class Encriptacion
    {
        public string Hash(string texto)
        {
            UnicodeEncoding codificar = new UnicodeEncoding();
            byte[] textobyte = codificar.GetBytes(texto);
            SHA256 sha256 = new SHA256CryptoServiceProvider();
            byte[] tablaBytes = sha256.ComputeHash(textobyte);
            string textoCifrado = Convert.ToBase64String(tablaBytes).ToString();
            return textoCifrado;
        }
    }
}
