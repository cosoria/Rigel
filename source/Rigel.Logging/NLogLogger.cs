using Rigel.Core;
using NLog;
using Rigel.Core.Logging;

namespace Rigel.Logging
{
    public class NLogLogger : ILogger
    {
        private readonly Logger _logger; 

        public NLogLogger() : this(LogManager.GetCurrentClassLogger())
        {
        }

        public NLogLogger(Logger logger)
        {
            Ensure.Argument.NotNull(() => logger);
            _logger = logger;
        }

        public void LogMessage(string message, LogSeverity severity)
        {
            _logger.Log(severity.ToNLogLevel(), message);
        }
    }
}