using Serilog;

namespace SecureUserApp.Logging
{
    public static class LogConfig
    {
        public static void Configure()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("logs/app.log",
                    rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
