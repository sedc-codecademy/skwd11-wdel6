// See https://aka.ms/new-console-template for more information

using Sedc.Server.Core;
using Sedc.Server.Interface.Configuration;

var port = 668; //the neighbour of the beast;
var options = ServerOptions
    .Default
    .SetPort(port)
    .EnableDebugging();

var server = new Server(options);

//server.Configure();

server.Start();
