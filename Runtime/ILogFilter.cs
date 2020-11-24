namespace TeamZero.Core.Logging
{
    public interface ILogFilter
    {
        bool InfoEnabled();

        bool WarningEnabled();

        bool ErrorEnabled();
        
        bool ExceptionEnabled();
    }
}
