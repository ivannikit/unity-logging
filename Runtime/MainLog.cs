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

        
        public static bool InfoEnabled() => _target.InfoEnabled();

        public static bool WarningEnabled() => _target.WarningEnabled();

        public static bool ErrorEnabled() => _target.ErrorEnabled();
		
        public static bool ExceptionEnabled() => _target.ExceptionEnabled();
		
        public static void Info(object o) => _target.Info(o);
		
        public static void Warning(object o) => _target.Warning(o);
		
        public static void Error(object o) => _target.Error(o);
		
        public static void Exception(Exception e) => _target.Exception(e);
    }
}
