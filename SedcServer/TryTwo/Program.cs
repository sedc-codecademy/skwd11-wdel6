// See https://aka.ms/new-console-template for more information

using Sedc.Server.Core;
using Sedc.Server.Interface.Configuration;

using TryTwo;


var port = 668; //the neighbour of the beast;
var options = ServerOptions
    .Default
    .SetPort(port)
    .SetLogger(new TryTwoLogger("Try2", LogLevel.Info))
    .EnableDebugging();

var server = new Server(options);

//server.Configure();

server.Start();
