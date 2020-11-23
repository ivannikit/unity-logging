using System;
using JetBrains.Annotations;

namespace TeamZero.Core.Logging
{
    public static class Main
    {
        private static Log _log;

        public static Log Log
        {
            get
            {
                if (_log == null)
                {
                    ILogTarget listener = DefaultTarget();
                    ILogFilter filter = DefaultFilter();
                    _log = new Log(listener, filter);
                }

                return _log;
            }
        }

        public static void Init(ILogTarget target, ILogFilter filter) => Init(new Log(target, filter));

        public static void Init([NotNull] Log value)
        {
            if (_log != null)
                throw new Exception("Default value already used");

            _log = value ?? throw new ArgumentNullException(nameof(value));
        }

        public static ILogTarget DefaultTarget()
        {
#if UNITY_5_3_OR_NEWER //if Unity Engine
            return new UnityConsoleTarget();
#else
			throw new NotImplementedException();
#endif
        }

        public static ILogFilter DefaultFilter(bool info = true, bool warning = true, bool error = true) =>
            LogFilter.Create(info, warning, error);
    }
}
