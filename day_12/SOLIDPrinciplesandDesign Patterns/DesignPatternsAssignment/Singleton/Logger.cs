namespace DesignPatternsAssignment.Singleton
{
    public sealed class Logger
    {
        private static readonly Logger _instance = new Logger();

        // Private constructor prevents external instantiation
        private Logger() { }

        public static Logger Instance
        {
            get { return _instance; }
        }

        public void Log(string message)
        {
            Console.WriteLine($"[LOG] {message}");
        }
    }
}
