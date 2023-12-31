﻿using Sedc.Server.Interface.Configuration;
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
        public string Header { get; set; }
        public TryTwoLogger(string header, LogLevel logLevel) {
            this.LogLevel = logLevel;
            this.Header = header;
        }

        protected override void OutputMessage(string message)
        {
            Console.WriteLine($"[{Header}]: {message}");
        }
    }
}
