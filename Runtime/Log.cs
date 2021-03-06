﻿using System;
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
		
		public bool ExceptionEnabled() 
		{
#if DISABLE_EXCEPTION_LOG
			return false;
#else
			return _filter.ExceptionEnabled();
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
		
#if DISABLE_EXCEPTION_LOG
		[System.Diagnostics.Conditional("__NEVER_DEFINED__")]
#endif
		public void Exception(Exception e)
		{
			if(ExceptionEnabled()) 
				_target.Exception(e);
		}
	}
}
