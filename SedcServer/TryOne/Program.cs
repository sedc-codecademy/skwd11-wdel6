using System.Net;
using System.Net.Sockets;
using System.Text;

var address = IPAddress.Any;
var port = 668; //the neighbour of the beast

return;

TcpListener listener = new TcpListener(address, port);
listener.Start();


while (true)
{
    // wait for a request
    Console.WriteLine($"Waiting for tcp client");
    var client = listener.AcceptTcpClient();
    Console.WriteLine($"Accepted tcp client");
    using var stream = client.GetStream();
    byte[] buffer = new byte[8192];
    Span<byte> bytes = new (buffer);
    var byteCount = stream.Read(bytes);
    Console.WriteLine(byteCount);
    var request = Encoding.UTF8.GetString(bytes);
    Console.WriteLine(request);
    var requestObject = RequestProcessor.ProcessRequest(request);
    var responseObject = ActualProcessor.Process(requestObject);
    var response = OutputGenerator.MakeResponse(responseObject);
    stream.Write(response);
}