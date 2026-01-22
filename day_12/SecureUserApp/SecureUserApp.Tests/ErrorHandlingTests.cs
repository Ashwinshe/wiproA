using SecureUserApp.Services;
using Xunit;

namespace SecureUserApp.Tests
{
    public class ErrorHandlingTests
    {
        [Fact]
        public void Duplicate_User_Should_Throw_Exception()
        {
            var auth = new AuthService();
            auth.Register("u1", "123", "a@mail.com");

            Assert.Throws<ApplicationException>(() =>
                auth.Register("u1", "123", "a@mail.com"));
        }
    }
}
