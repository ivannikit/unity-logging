using System;

namespace TeamZero.Core.Logging
{
    public interface ILogTarget
    {
        void Info(object o);

        void Warning(object o);

        void Error(object o);
        
        void Error(Exception e);
    }
}
