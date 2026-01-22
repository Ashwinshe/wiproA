using SecureUserApp.Logging;
using SecureUserApp.Services;

LogConfig.Configure();

var auth = new AuthService();
auth.Register("ashwin", "123", "ashwin@mail.com");

Console.WriteLine(auth.Authenticate("ashwin", "123"));
