using System;

namespace HalloSingelton
{
    class Logger
    {
        private static Logger _instance = null;
        private static Object _syncObj = new Object();

        public static Logger Instance
        {
            get
            {
                lock (_syncObj)
                {
                    if (_instance == null)
                        _instance = new Logger();
                }
                return _instance;
            }
        }

        private Logger()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("CTOR");
            Console.ResetColor();
        }

        public void Log(string txt)
        {
            Console.WriteLine($"[{DateTime.Now}] {txt}");
        }
    }
}
