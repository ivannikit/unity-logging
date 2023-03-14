#nullable enable

namespace TeamZero.Core.Logging
{
    public sealed class LogFilter : ILogFilter
    {
        private readonly LogMask _mask;
        
        public static LogFilter Create(LogMask mask) => new(mask);
        public static LogFilter ErrorLevel() => new(LogMask.Error);
        public static LogFilter WarningLevel() => new(LogMask.Warning | LogMask.Error);
        public static LogFilter All() => new(LogMask.All);

        private LogFilter(LogMask mask)
        {
            _mask = mask;
        }

        public bool InfoEnabled() => _mask.Contains(LogMask.Info);

        public bool WarningEnabled() => _mask.Contains(LogMask.Warning);

        public bool ErrorEnabled() => _mask.Contains(LogMask.Error);
    }
}