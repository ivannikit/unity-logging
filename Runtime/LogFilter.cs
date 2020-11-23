﻿namespace TeamZero.Core.Logging
{
    public sealed class LogFilter : ILogFilter
    {
        private readonly LogMask _mask;

        public static LogFilter Create(bool info, bool warning, bool error)
        {
            LogMask mask = LogMask.Empty;
            if (info) mask = mask.Union(LogMask.Info);
            if (warning) mask = mask.Union(LogMask.Warning);
            if (error) mask = mask.Union(LogMask.Error);

            return new LogFilter(mask);
        }

        public LogFilter(LogMask mask)
        {
            _mask = mask;
        }

        public bool InfoEnabled() => _mask.Contains(LogMask.Info);

        public bool WarningEnabled() => _mask.Contains(LogMask.Warning);

        public bool ErrorEnabled() => _mask.Contains(LogMask.Error);
    }
}