using Sedc.Server.Interface.Configuration;
using Sedc.Server.Interface.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Interface.Logging
{
    public class ConsoleLogger : LoggerBase
    {
        public ConsoleLogger(LogLevel logLevel)
        {
            this.LogLevel = logLevel;
        }

        protected override void OutputMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
