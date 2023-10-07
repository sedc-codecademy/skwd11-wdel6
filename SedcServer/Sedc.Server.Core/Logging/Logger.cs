using Sedc.Server.Interface.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Core.Logging
{
    internal class Logger
    {
        public LogLevel LogLevel { get; init; }
        public Logger(LogLevel logLevel)
        {
            this.LogLevel = logLevel;
        }

        public void Log(LogLevel level, string message)
        {
            if (level >= LogLevel)
            {
                Console.WriteLine(message);
            }
        }

        public void Debug(string message) => Log(LogLevel.Debug, message);
        public void Info(string message) => Log(LogLevel.Info, message);
        public void Warning(string message) => Log(LogLevel.Warning, message);
        public void Error(string message) => Log(LogLevel.Error, message);
        public void Fatal(string message) => Log(LogLevel.Fatal, message);
    }
}
