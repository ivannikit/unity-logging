using System;
using JetBrains.Annotations;

namespace TeamZero.Core.Logging
{
    public static class MainLog
    {
        private static Log _instance;

        private static Log Instance
        {
            get
            {
                if (_instance == null)
                {
                    ILogTarget listener = DefaultTarget();
                    ILogFilter filter = DefaultFilter();
                    _instance = new Log(listener, filter);
                }

                return _instance;
            }
        }

        public static void Init(ILogTarget target, ILogFilter filter) => Init(new Log(target, filter));

        public static void Init([NotNull] Log value)
        {
            if (_instance != null)
                throw new Exception("Default value already used");

            _instance = value ?? throw new ArgumentNullException(nameof(value));
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

        
        public static bool InfoEnabled() => _instance.InfoEnabled();

        public static bool WarningEnabled() => _instance.WarningEnabled();

        public static bool ErrorEnabled() => _instance.ErrorEnabled();
		
        public static bool ExceptionEnabled() => _instance.ExceptionEnabled();
		
        public static void Info(object o) => _instance.Info(o);
		
        public static void Warning(object o) => _instance.Warning(o);
		
        public static void Error(object o) => _instance.Error(o);
		
        public static void Exception(Exception e) => _instance.Exception(e);
    }
}
