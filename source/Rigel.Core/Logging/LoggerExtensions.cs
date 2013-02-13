using System;

namespace Rigel.Core.Logging
{
    public static class LoggerExtensions
    {
        public static void LogException(this ILogger logger, Exception ex)
        {
            logger.LogCritical(ex.ToString());
        }

        public static void LogCritical(this ILogger logger, string message)
        {
            logger.LogMessage(message, LogSeverity.Critical);
        }
        
        public static void LogError(this ILogger logger, string message)
        {
            logger.LogMessage(message, LogSeverity.Error);
        }

        public static void LogWarning(this ILogger logger, string message)
        {
            logger.LogMessage(message, LogSeverity.Warning);
        }

        public static void LogInfo(this ILogger logger, string message)
        {
            logger.LogMessage(message, LogSeverity.Info);
        }

        public static void LogDebug(this ILogger logger, string message)
        {
            logger.LogMessage(message, LogSeverity.Debug);
        }

        public static void LogTrace(this ILogger logger, string message)
        {
            logger.LogMessage(message, LogSeverity.Trace);
        }
    }
}