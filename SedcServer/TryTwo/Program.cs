// See https://aka.ms/new-console-template for more information

using Sedc.Server.Core;

var port = 668; //the neighbour of the beast;
var server = new Server(port); 

server.Start();