using SecureUserApp.Services;
using Xunit;

namespace SecureUserApp.Tests
{
    public class AuthTests
    {
        [Fact]
        public void User_Should_Register_And_Login()
        {
            var auth = new AuthService();
            auth.Register("test", "123", "t@mail.com");

            Assert.True(auth.Authenticate("test", "123"));
        }
    }
}
