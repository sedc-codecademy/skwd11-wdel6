using Sedc.Server.Core.Logging;
using Sedc.Server.Interface.Requests;
using Sedc.Server.Interface.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Core.Processing
{
    internal class ApiResponseGenerator: IGenerator
    {
        public Logger Logger { get; }
        public ApiResponseGenerator(Logger logger)
        {
            Logger = logger;
        }

        public (string Content, string Type) Generate(HttpRequest request)
        {
            var body = "Hello world!";
            var contentType = "text/plain";
            return (body, contentType);
        }

        public bool WannaConsume(HttpRequest request)
        {
            return true;
        }
    }
}
