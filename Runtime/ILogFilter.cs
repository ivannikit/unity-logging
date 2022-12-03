#nullable enable

namespace TeamZero.Logging
{
    public interface ILogFilter
    {
        bool InfoEnabled();

        bool WarningEnabled();

        bool ErrorEnabled();
    }
}
