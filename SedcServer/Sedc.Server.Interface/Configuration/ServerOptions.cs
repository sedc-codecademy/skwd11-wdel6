using Sedc.Server.Interface.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Interface.Configuration
{
    public class ServerOptions
    {
        public int Port { get; private set; }

        public LogLevel LogLevel { get; private set; }

        public LoggerBase Logger { get; private set; }

        private ServerOptions() { }

        public ServerOptions SetPort(int port)
        {
            this.Port = port;
            return this;
        }

        public ServerOptions SetLogLevel(LogLevel logLevel)
        {
            this.LogLevel = logLevel;
            return this;
        }

        public ServerOptions EnableDebugging()
        {
            this.LogLevel = LogLevel.Debug;
            // set additional properties
            return this;
        }

        public override string ToString()
        {
            return $"Server is set up on port {Port} with log level of {LogLevel}";
        }


        private static ServerOptions _default() => new() { 
            Port = 668,
            LogLevel = LogLevel.Info,
            Logger = new Logger(LogLevel.Info)
        };
        public static ServerOptions Default => _default();


        // public static ServerOptions FromValue(int value) => new() { Port = value };
    }
}
