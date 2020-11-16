using System;

namespace TeamZero.Core.Logging
{
    public interface ILogTarget
    {
        void Info(string message);

        void Warning(string message);

        void Error(string message);
        
        void Error(Exception e);
    }
}
