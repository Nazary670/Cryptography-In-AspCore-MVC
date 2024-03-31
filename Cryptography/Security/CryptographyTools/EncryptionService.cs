using System.Security.Cryptography;
using System.Text;

namespace Cryptography.Security.CryptographyTools
{
    public class EncryptionService
    {
        private readonly string _encryptionKey = "your-secret-key";

        public string Encrypt(string input)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(input);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new(_encryptionKey, "Ivan Medvedev"u8.ToArray());
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using MemoryStream ms = new();
                using (CryptoStream cs = new(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                input = Convert.ToBase64String(ms.ToArray());
            }
            return input;
        }

        public string Decrypt(string cipherText)
        {
            byte[] buffer = Convert.FromBase64String(cipherText);

            using Aes aes = Aes.Create();
            Rfc2898DeriveBytes pdb = new(_encryptionKey, "Ivan Medvedev"u8.ToArray());
            aes.Key = pdb.GetBytes(32);
            aes.IV = pdb.GetBytes(16);

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using MemoryStream memoryStream = new(buffer);
            using CryptoStream cryptoStream = new(memoryStream, decryptor, CryptoStreamMode.Read);
            using StreamReader streamReader = new(cryptoStream);
           
            var result= streamReader.ReadToEnd().Replace("\0", string.Empty);
            return result;
        }

    }
}
