using Sedc.Server.Interface.Configuration;
using Sedc.Server.Interface.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryTwo
{
    internal class TryTwoLogger : LoggerBase
    {
        public TryTwoLogger(LogLevel logLevel) {
            this.LogLevel = logLevel;
        }

        protected override void OutputMessage(string message)
        {
            Console.WriteLine($"[TryTwo]: {message}");
        }
    }
}
