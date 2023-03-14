#nullable enable

namespace TeamZero.Core.Logging
{
    public interface ILogTarget
    {
        void Info(object o);

        void Warning(object o);

        void Error(object o);
    }
}
