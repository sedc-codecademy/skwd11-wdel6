using Sedc.Server.Interface.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public ServerOptions SetLogger(LoggerBase logger)
        {
            this.Logger = logger;
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
            // bad code - don't do this
            Console.WriteLine($"Name of the logger type is {Logger.GetType().Name}");
            Console.WriteLine("Let's see if we can find a suitable constructor");

            Type loggerType = Logger.GetType();
            var constructors = loggerType.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            var constructor = constructors.FirstOrDefault(ctor =>
            {
                var parameters = ctor.GetParameters();
                if (parameters.Length != 1)
                {
                    return false;
                }
                var paramType = parameters[0].ParameterType;
                return paramType == typeof(LogLevel);
            });

            if (constructor == null)
            {
                Logger.Error("Didn't find a suitable logger, reverting to basic console logger");
                this.Logger = new Logger(this.LogLevel);
                return this;
            }

            Logger = (LoggerBase)constructor.Invoke([LogLevel]);

            //Console.WriteLine($"Found {constructors.Length} constructors");
            //foreach (var constructor in constructors)
            //{
            //    var @params = constructor.GetParameters();
            //    Console.WriteLine($"Constructor has {@params.Length} parameters");
            //    foreach (var param in @params)
            //    {
            //        Console.WriteLine($"Parameter is called {param.Name}");
            //        Console.WriteLine($"Parameter is of type {param.ParameterType.FullName}");
            //    }
            //}


            // this.Logger = new Logger(this.LogLevel);
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
