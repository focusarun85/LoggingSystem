using System.Collections.Concurrent;

namespace Logging.Core
{ 

    /// <summary>
    /// Log Helper
    /// </summary>
    public static class LogHelper
    {
        #region "Private Fields"
        private static readonly ConcurrentDictionary<LogTarget, ILogger> Loggers;
        #endregion

        #region "Constructor"
        static LogHelper()
        {
            Loggers = new ConcurrentDictionary<LogTarget, ILogger>();            
        }
        #endregion

        #region "Private Methods"
        private static void WriteEntry(LogLevel logLevel, string message)
        {
            var entry = $"{(logLevel == LogLevel.None ? "" : $"[{logLevel}]")}[{DateTime.Now}] {message}";
            foreach (var logger in Loggers.Values)
            {
                switch (logger.DefaultLogLevel)
                {
                    case LogLevel.Trace:
                        logger.WriteLine(entry);
                        break;
                    case LogLevel.Debug:
                        if (logLevel != LogLevel.Trace)
                            logger.WriteLine(entry);
                        break;
                    case LogLevel.Information:
                        if (logLevel != LogLevel.Trace && logLevel != LogLevel.Debug)
                            logger.WriteLine(entry);
                        break;
                    case LogLevel.Warning:
                        if (logLevel != LogLevel.Trace && logLevel != LogLevel.Debug && logLevel != LogLevel.Information)
                            logger.WriteLine(entry);
                        break;
                    case LogLevel.Error:
                        if (logLevel != LogLevel.Trace && logLevel != LogLevel.Debug && logLevel != LogLevel.Information && logLevel != LogLevel.Warning)
                            logger.WriteLine(entry);
                        break;
                    case LogLevel.Critical:
                        if (logLevel != LogLevel.Trace && logLevel != LogLevel.Debug && logLevel != LogLevel.Information && logLevel != LogLevel.Warning && logLevel != LogLevel.Error)
                            logger.WriteLine(entry);
                        break;
                }

            }
        }
        #endregion

        #region "Public Methods"
        public static void AddLogTarget(LogTarget target, LogLevel defaultLogLevel)
        {
            ILogger? logger = null;
            switch (target)
            {
                case LogTarget.File:
                    var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Log.txt");
                    logger = new FileLogger { Path = fileName, DefaultLogLevel = defaultLogLevel };
                    Loggers.AddOrUpdate(target, logger, (s, logger1) => logger);
                    break;
                case LogTarget.Console:
                    logger = new ConsoleLogger { DefaultLogLevel = defaultLogLevel };
                    Loggers.AddOrUpdate(target, logger, (s, logger1) => logger);
                    break;                
            }
        }       

        public static void LogTrace(string message)
        {
            WriteEntry(LogLevel.Trace, message);
        }

        public static void LogDebug(string message)
        {
            WriteEntry(LogLevel.Debug, message);
        }

        public static void LogInformation(string message)
        {
            WriteEntry(LogLevel.Information, message);
        }

        public static void LogWarning(string message)
        {
            WriteEntry(LogLevel.Warning, message);
        }

        public static void LogError(string message)
        {
            WriteEntry(LogLevel.Error, message);
        }

        public static void LogCritical(string message)
        {
            WriteEntry(LogLevel.Critical, message);
        }
        #endregion
    }
}
