﻿using System.Net;
using System.Net.Sockets;
using System.Text;

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
    var requestString = Encoding.UTF8.GetString(bytes);
    // Console.WriteLine(request);
    var request = RequestProcessor.ProcessRequest(requestString);
    var response = ActualProcessor.Process(request);
    var output = OutputGenerator.MakeResponse(response);
    stream.Write(output);
}

