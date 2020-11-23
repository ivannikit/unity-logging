using System;
using JetBrains.Annotations;

#if DISABLE_INFO_LOG || DISABLE_WARNING_LOG || DISABLE_ERROR_LOG
using System.Diagnostics;
#endif

namespace TeamZero.Core.Logging
{
	public sealed class Log : ILogFilter
	{
		private readonly ILogTarget _target;
		private readonly ILogFilter _filter;

		public Log([NotNull] ILogTarget target, [NotNull] ILogFilter filter)
        {
         	_target = target ?? throw new ArgumentNullException(nameof(target));
         	_filter = filter ?? throw new ArgumentNullException(nameof(filter));
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
		[Conditional("__NEVER_DEFINED__")]
#endif
		public void Info(string message)
		{
			if(InfoEnabled()) 
				_target.Info(message);
		}
		
		
#if DISABLE_INFO_LOG
		[Conditional("__NEVER_DEFINED__")]
#endif
		public void Info(object o)
		{
			if(InfoEnabled()) 
				_target.Info(o.ToString());
		}
		
		
#if DISABLE_WARNING_LOG
		[Conditional("__NEVER_DEFINED__")]
#endif
		public void Warning(string message)
		{
			if(WarningEnabled()) 
				_target.Warning(message);
		}
		
		
#if DISABLE_WARNING_LOG
		[Conditional("__NEVER_DEFINED__")]
#endif
		public void Warning(object o)
		{
			if(WarningEnabled()) 
				_target.Warning(o.ToString());
		}
 
		
#if DISABLE_ERROR_LOG
		[Conditional("__NEVER_DEFINED__")]
#endif
		public void Error(string message)
		{
			if(ErrorEnabled()) 
				_target.Error(message);
		}
		
		
#if DISABLE_ERROR_LOG
		[Conditional("__NEVER_DEFINED__")]
#endif
		public void Error(object o)
		{
			if(ErrorEnabled()) 
				_target.Error(o.ToString());
		}

		
#if DISABLE_ERROR_LOG
		[Conditional("__NEVER_DEFINED__")]
#endif
		public void Error(Exception e)
		{
			if(ErrorEnabled()) 
				_target.Error(e);
		}
	}
}
