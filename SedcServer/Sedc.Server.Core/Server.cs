using System.Net.Sockets;
using System.Net;
using System.Text;
using Sedc.Server.Interface.Exceptions;
using Sedc.Server.Core.Requests;
using Sedc.Server.Core.Processing;

namespace Sedc.Server.Core
{
    public class Server
    {
        private int Port { get; init;}
        public Server(int port)
        {
            this.Port = port;
        }
        public void Start()
        {
            var address = IPAddress.Any;

            TcpListener listener = new TcpListener(address, Port);
            try
            {
                listener.Start();
            } 
            catch (Exception ex)
            {
                var exception = new SedcServerException("Failed to start server, maybe port is in use", ex);
                throw exception;
            }

            while (true)
            {
                // wait for a request
                Console.WriteLine($"Waiting for tcp client");
                var client = listener.AcceptTcpClient();
                Console.WriteLine($"Accepted tcp client");

                using var stream = client.GetStream();
                byte[] buffer = new byte[8192];
                Span<byte> bytes = new(buffer);
                var byteCount = stream.Read(bytes);
                Console.WriteLine(byteCount);
                var requestString = Encoding.UTF8.GetString(bytes);
                // Console.WriteLine(requestString);

                var request = RequestProcessor.ProcessRequest(requestString);
                var response = ActualProcessor.Process(request);
                //var output = OutputGenerator.MakeResponse(response);
                //stream.Write(output);
            }

        }
    }

}
