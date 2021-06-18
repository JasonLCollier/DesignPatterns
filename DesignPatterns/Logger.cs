using System;

namespace Console.App
{
    public enum LogVerbosity
    {
        Trace,
        Debug,
        Info,
        Warn,
        Error,
        Critical
    }
    public interface ILogger
    {
        void Log(string message, LogVerbosity verbosity);
    }
    public class Logger : ILogger
    {
        private static Logger _logger;
        private static readonly Logger _logger3 = new Logger();
        //Static - use access
        private static readonly object _syncLock = new object(); 

        private Logger() { }

        // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
        static Logger()
        {
        }

        public void Log(string message, LogVerbosity verbosity)
        {
            var logMessage = $"[{verbosity}] - {DateTimeOffset.UtcNow:R} - {message}";
            System.Console.WriteLine(logMessage);
            if (verbosity == LogVerbosity.Critical)
            {
                throw new Exception(logMessage);
            }
        }

        /*
         * Singleton 1
         * Simple - Not Thread safe
         */
        public static Logger GetLogger()
        {
            if (_logger == null)
            {
                _logger = new Logger();
            }

            return _logger;
        }

        //rather
        public static Logger Instance
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new Logger();
                }

                return _logger;
            }

        }

        /*
         * Singleton 2
         * Double Check Lock - Thread Safe
         */
        public static Logger GetLogger2()
        {
            if (_logger == null) //Don't go into lock every time - to prevent dead locking
            {
                lock (_syncLock)
                {
                    if (_logger == null)
                    {
                        _logger = new Logger();
                    }
                }
            }

            return _logger;
        }

        /*
         * Singleton 3
         * Static Initialisation - Must Hav Static Constructor - probably most performant
         */
        public static Logger GetLogger3()
        {
            return _logger3;
        }

        /*
         * Singleton 4
         * Lazy Version
         */
        private static readonly Lazy<Logger> _lazy = new Lazy<Logger>(() => new Logger());
        public static Logger Instance4 => _lazy.Value;

        //public static Logger Instance4
        //{
        //    get { return _lazy.Value; }
        //}
    }
}