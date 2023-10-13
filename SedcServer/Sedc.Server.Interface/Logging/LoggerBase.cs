using Sedc.Server.Interface.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Interface.Logging
{
    public abstract class LoggerBase
    {
        public LogLevel LogLevel { get; init; }

        protected abstract void OutputMessage(string message);

        public virtual void Log(LogLevel level, string message)
        {
            if (level >= LogLevel)
            {
                OutputMessage(message);
            }
        }

        public virtual void Debug(string message) => Log(LogLevel.Debug, message);
        public virtual void Info(string message) => Log(LogLevel.Info, message);
        public virtual void Warning(string message) => Log(LogLevel.Warning, message);
        public virtual void Error(string message) => Log(LogLevel.Error, message);
        public virtual void Fatal(string message) => Log(LogLevel.Fatal, message);
    }
}
