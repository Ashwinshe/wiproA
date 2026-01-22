using SecureUserApp.Services;
using Xunit;

namespace SecureUserApp.Tests
{
    public class CryptoTests
    {
        [Fact]
        public void Encrypt_Decrypt_Should_Work()
        {
            var data = "secret";
            var encrypted = CryptoService.Encrypt(data);
            var decrypted = CryptoService.Decrypt(encrypted);

            Assert.Equal(data, decrypted);
        }
    }
}
