using NLog;
using Rigel.Core.Logging;

namespace Rigel.Logging
{
    public static class NLogExtensions
    {
        public static LogLevel ToNLogLevel(this LogSeverity severity)
        {
            switch (severity)
            {
                case LogSeverity.Critical:
                    return LogLevel.Fatal;
                case LogSeverity.Error:
                    return LogLevel.Error;
                case LogSeverity.Warning:
                    return LogLevel.Warn;
                case LogSeverity.Info:
                    return LogLevel.Info;
                case LogSeverity.Debug:
                    return LogLevel.Debug;
                case LogSeverity.Trace:
                    return LogLevel.Trace;
                case LogSeverity.Off:
                    return LogLevel.Off;
                default:
                    return LogLevel.Off;
            }
        }
    }
}