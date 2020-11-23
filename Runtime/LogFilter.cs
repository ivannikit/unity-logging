namespace TeamZero.Core.Logging
{
    public sealed class LogFilter : ILogFilter
    {
        private readonly bool _logInfo;
        private readonly bool _logWarning;
        private readonly bool _logError;

        public LogFilter(bool info, bool warning, bool error)
        {
            _logInfo = info;
            _logWarning = warning;
            _logError = error;
        }

        public bool InfoEnabled() => _logInfo;

        public bool WarningEnabled() => _logWarning;

        public bool ErrorEnabled() => _logError;
    }
}