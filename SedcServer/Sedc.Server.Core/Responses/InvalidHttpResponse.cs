using Sedc.Server.Interface.Entities;
using Sedc.Server.Interface.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Core.Responses
{
    internal class InvalidHttpResponse : HttpResponse
    {
        public InvalidHttpResponse() : base()
        {
            StatusCode = 400;
            Body = "Bad request";
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "text/plain" },
                { "Content-Length", "11" }
            };
            Headers = HeaderCollection.FromDictionary(headers);
        }
    }
}
