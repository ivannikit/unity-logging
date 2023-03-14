# unity-logging
Simple logging tool for Unity3d (or c# only projects).

This sdk use System.Diagnostics.ConditionalAttribute to remove debug messages in release build. Use precompile definitions:
- DISABLE_INFO_LOG
- DISABLE_WARNING_LOG
- DISABLE_ERROR_LOG

### Sample:
```csharp
ILogTarget target = Log.DefaultTarget();
ILogFilter filter = LogFilter.WarningLevel();
Log log = new Log(target, filter);
...

log.Info("info message");
log.Warning("warning message");
log.Error("error message");
...

if(log.InfoEnabled())
{
    StringBuilder message = new StringBuilder();
    ...
    log.Info(message);
}
```