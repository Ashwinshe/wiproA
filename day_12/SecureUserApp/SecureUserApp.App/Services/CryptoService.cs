using System.Security.Cryptography;
using System.Text;

namespace SecureUserApp.Services
{
    public static class CryptoService
    {
        private static readonly byte[] Key =
            Encoding.UTF8.GetBytes("12345678901234567890123456789012");

        private static readonly byte[] IV =
            Encoding.UTF8.GetBytes("1234567890123456");

        public static string Encrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            var encryptor = aes.CreateEncryptor();
            var bytes = Encoding.UTF8.GetBytes(plainText);
            var encrypted = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);

            return Convert.ToBase64String(encrypted);
        }

        public static string Decrypt(string cipherText)
        {
            using var aes = Aes.Create();
            aes.Key = Key;
            aes.IV = IV;

            var decryptor = aes.CreateDecryptor();
            var bytes = Convert.FromBase64String(cipherText);
            var decrypted = decryptor.TransformFinalBlock(bytes, 0, bytes.Length);

            return Encoding.UTF8.GetString(decrypted);
        }
    }
}
