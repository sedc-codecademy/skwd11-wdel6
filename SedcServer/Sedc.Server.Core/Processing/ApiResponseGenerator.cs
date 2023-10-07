using Sedc.Server.Core.Logging;
using Sedc.Server.Interface.Requests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Core.Processing
{
    internal class ApiResponseGenerator
    {
        public Logger Logger { get; }
        public ApiResponseGenerator(Logger logger)
        {
            Logger = logger;
        }

        internal (string Content, string Type) GetApiResponse(HttpRequest request)
        {
            var body = "Hello world!";
            var contentType = "text/plain";
            return (body, contentType);
        }

    }
}
