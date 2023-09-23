using System.Net;
using System.Net.Sockets;

var address = IPAddress.Any;
var port = 668; //the neighbour of the beast

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

    var request = string.Join(",", buffer.Take(byteCount).Select(b => b.ToString()));
    Console.WriteLine(request);
}