namespace TeamZero.Core.Logging
{
    internal static class Factory
    {
        internal static Log Default() => new(DefaultTarget(), DefaultFilter());
        
	    internal static ILogTarget DefaultTarget()
        {
#if UNITY_5_3_OR_NEWER //if Unity Engine
            return new UnityConsoleTarget();
#else
			throw new NotImplementedException();
#endif
        }

        internal static ILogFilter DefaultFilter() => LogFilter.All();
    }
}
