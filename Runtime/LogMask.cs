#nullable enable

using System;

namespace TeamZero.Logging
{
    [Flags]
    public enum LogMask
    {
        Empty = 0,
        All = ~Empty,
        Info = 1 << 0,
        Warning = 1 << 1,
        Error = 1 << 2,
        Exception = 1 << 3
    }
    
    public static class LogMaskExtension
    {
        public static LogMask Union(this LogMask target, LogMask value) => target | value;
        
        public static LogMask Distinct(this LogMask target, LogMask value) => target & ~value;
        
        public static bool Contains(this LogMask target, LogMask value) => (target & value) != 0;
    }
}
