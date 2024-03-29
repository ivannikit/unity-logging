﻿#nullable enable

namespace TeamZero.Core.Logging
{
	public sealed class Log : ILogFilter
	{
		private readonly ILogTarget _target;
		private readonly ILogFilter _filter;

		public Log(ILogTarget target, ILogFilter filter)
        {
         	_target = target;
         	_filter = filter;
        }
		
		public bool InfoEnabled()
		{
#if DISABLE_INFO_LOG
			return false;
#else
			return _filter.InfoEnabled();
#endif
		}

		public bool WarningEnabled()
		{
#if DISABLE_WARNING_LOG
			return false;
#else
			return _filter.WarningEnabled();
#endif
		}

		public bool ErrorEnabled() 
		{
#if DISABLE_ERROR_LOG
			return false;
#else
			return _filter.ErrorEnabled();
#endif
		}

#if DISABLE_INFO_LOG
		[System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
		public void Info(object o)
		{
			if(InfoEnabled()) 
				_target.Info(o);
		}
		
#if DISABLE_WARNING_LOG
		[System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
		public void Warning(object o)
		{
			if(WarningEnabled()) 
				_target.Warning(o);
		}
		
#if DISABLE_ERROR_LOG
		[System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
		public void Error(object o)
		{
			if(ErrorEnabled()) 
				_target.Error(o);
		}


		public static Log Default() => Factory.Default();
		
		public static ILogTarget DefaultTarget() => Factory.DefaultTarget();
		
		public static ILogFilter DefaultFilter() => Factory.DefaultFilter();
	}
}
