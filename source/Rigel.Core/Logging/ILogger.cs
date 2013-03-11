namespace Rigel.Logging
{
    public interface ILogger
    {
        void LogMessage(string message, LogSeverity severity);
    }
}