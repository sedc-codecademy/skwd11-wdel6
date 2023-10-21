using Sedc.Server.Core.Logging;
using Sedc.Server.Interface.Entities;
using Sedc.Server.Interface.Logging;
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
    internal class DefaultResponseGenerator: IGenerator
    {
        public LoggerBase Logger { get; }
        public string Name { get; } = "Default Response Generator";

        public DefaultResponseGenerator(LoggerBase logger)
        {
            Logger = logger;
        }

        public HttpResponse Generate(HttpRequest request)
        {
            var body = "Hello world!";
            var contentType = "text/plain";
            var statusCode = 200;
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", contentType },
                { "Content-Length", body.Length.ToString() }
            };

            return new StringHttpResponse
            {
                Body = body,
                StatusCode = statusCode,
                Headers = HeaderCollection.FromDictionary(headers)
            };
        }

        public bool WannaConsume(HttpRequest request)
        {
            return true;
        }
    }
}
