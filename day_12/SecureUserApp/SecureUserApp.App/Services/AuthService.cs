using SecureUserApp.Models;
using System.Security.Cryptography;
using System.Text;
using Serilog;

namespace SecureUserApp.Services
{
    public class AuthService
    {
        private readonly Dictionary<string, User> _users = new();

        public void Register(string username, string password, string email)
        {
            if (_users.ContainsKey(username))
                throw new ApplicationException("User already exists");

            var hashedPassword = HashPassword(password);
            var encryptedEmail = CryptoService.Encrypt(email);

            _users.Add(username, new User
            {
                Username = username,
                HashedPassword = hashedPassword,
                EncryptedEmail = encryptedEmail
            });
        }

        public bool Authenticate(string username, string password)
        {
            if (!_users.ContainsKey(username))
                return false;

            var hashed = HashPassword(password);
            return _users[username].HashedPassword == hashed;
        }

        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
