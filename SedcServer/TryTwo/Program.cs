using Sedc.Server.Core;
using Sedc.Server.Interface.Configuration;

using TryTwo;


var port = 668; //the neighbour of the beast;
var options = ServerOptions
    .Default
    .SetPort(port)
    .SetLogger(logLevel => new TryTwoLogger("Try2", logLevel))
    .EnableDebugging();

var server = new Server(options);

server.RegisterStaticSite("public", "site");


//server.Configure();

server.Start();
