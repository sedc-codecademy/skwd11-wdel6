using System.Net.Sockets;
using System.Net;
using System.Text;
using Sedc.Server.Interface.Exceptions;
using Sedc.Server.Core.Requests;
using Sedc.Server.Core.Processing;
using Sedc.Server.Interface.Configuration;
using Sedc.Server.Core.Logging;
using Sedc.Server.Interface.Logging;

namespace Sedc.Server.Core
{
    public class Server
    {
        private int Port { get; init;}
        private LoggerBase Logger{ get; init; }

        private ActualProcessor processor;
        public Server(ServerOptions options)
        {
            this.Port = options.Port;
            this.Logger = new Logger(options.LogLevel);
            this.processor = new ActualProcessor(Logger);
        }

        public Server(): this(ServerOptions.Default)
        {

        }

        public void Start()
        {
            var address = IPAddress.Any;

            TcpListener listener = new TcpListener(address, Port);
            try
            {
                listener.Start();
                Logger.Info("Server started successfully");
            } 
            catch (Exception ex)
            {
                var message = "Failed to start server, maybe port is in use";
                Logger.Fatal(message);
                var exception = new SedcServerException(message, ex);
                throw exception;
            }

            while (true)
            {
                // wait for a request
                Logger.Debug($"Waiting for tcp client");
                var client = listener.AcceptTcpClient();
                Logger.Debug($"Accepted tcp client");

                using var stream = client.GetStream();
                byte[] buffer = new byte[8192];
                Span<byte> bytes = new(buffer);
                var byteCount = stream.Read(bytes);
                Logger.Debug($"Received {byteCount} bytes");
                var requestString = Encoding.UTF8.GetString(bytes);

                var request = RequestProcessor.ProcessRequest(requestString, Logger);
                var response = processor.Process(request);
                var output = OutputGenerator.MakeResponse(response, Logger);
                stream.Write(output);
            }

        }
    }

}
