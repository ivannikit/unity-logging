namespace TeamZero.Core.Logging
{
    public sealed class LogFilter : ILogFilter
    {
        private readonly LogMask _mask;
        
        public static LogFilter FromMask(LogMask mask) => new LogFilter(mask);
        public static LogFilter ErrorLevel() => new LogFilter(LogMask.Error | LogMask.Exception);
        public static LogFilter WarningLevel() => new LogFilter(LogMask.Warning | LogMask.Error | LogMask.Exception);
        public static LogFilter All() => new LogFilter(LogMask.All);

        private LogFilter(LogMask mask)
        {
            _mask = mask;
        }

        public bool InfoEnabled() => _mask.Contains(LogMask.Info);

        public bool WarningEnabled() => _mask.Contains(LogMask.Warning);

        public bool ErrorEnabled() => _mask.Contains(LogMask.Error);
    }
}