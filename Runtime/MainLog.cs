using System;
using JetBrains.Annotations;

namespace TeamZero.Core.Logging
{
    public static class MainLog
    {
        private static Log _target;
        public static Log Target
        {
            get
            {
                if (_target == null)
                {
                    ILogTarget listener = DefaultTarget();
                    ILogFilter filter = DefaultFilter();
                    _target = new Log(listener, filter);
                }

                return _target;
            }
        }

        public static void Init(ILogTarget target, ILogFilter filter) => Init(new Log(target, filter));

        public static void Init([NotNull] Log value)
        {
            if (_target != null)
                throw new Exception("Default value already used");

            _target = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static ILogTarget DefaultTarget()
        {
#if UNITY_5_3_OR_NEWER //if Unity Engine
            return new UnityConsoleTarget();
#else
			throw new NotImplementedException();
#endif
        }

        public static ILogFilter DefaultFilter(bool info = true, bool warning = true, bool error = true, bool exception = true) =>
            LogFilter.Create(info, warning, error, exception);

        
        public static bool InfoEnabled() => Target.InfoEnabled();

        public static bool WarningEnabled() => Target.WarningEnabled();

        public static bool ErrorEnabled() => Target.ErrorEnabled();
		
        public static bool ExceptionEnabled() => Target.ExceptionEnabled();
		
#if DISABLE_INFO_LOG
		[System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
        public static void Info(object o) => Target.Info(o);
		
#if DISABLE_WARNING_LOG
		[System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
        public static void Warning(object o) => Target.Warning(o);
		
#if DISABLE_ERROR_LOG
		[System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
        public static void Error(object o) => Target.Error(o);
		
#if DISABLE_EXCEPTION_LOG
		[System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
        public static void Exception(Exception e) => Target.Exception(e);
    }
}
