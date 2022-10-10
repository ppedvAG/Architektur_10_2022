namespace HalloSingelton
{
    internal class Logger
    {
        private static Logger? _instance;

        public static object _syncObj = new();
        public static Logger Instance
        {
            get
            {
                lock (_syncObj)
                {
                    _instance ??= new Logger();
                }

                return _instance;
            }
        }

        private Logger()
        {
            Info("Logger wurde gestartet");
        }

        public void Info(string msg)
        {
            Console.WriteLine($"[INFO] {DateTime.Now:G} {msg}");
        }
    }
}
