using Sedc.Server.Interface.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Interface.Responses
{
    public class HttpResponse
    {
        public int StatusCode { get; init; }
        public string Body { get; init; }
        public HeaderCollection Headers { get; init; }

        public HttpResponse()
        {
            StatusCode = 200;
            Body = string.Empty;
            Headers = HeaderCollection.Empty;
        }
        public HttpResponse(int statusCode, string body, Dictionary<string, string> headers)
        {
            StatusCode = statusCode;
            Body = body;
            Headers = HeaderCollection.FromDictionary(headers);
        }
    }
}
