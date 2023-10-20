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
        public HeaderCollection Headers { get; init; }

        protected HttpResponse() {
            StatusCode = 200;
            Headers = HeaderCollection.Empty;
        }

        protected HttpResponse(int statusCode, Dictionary<string, string> headers)
        {
            StatusCode = statusCode;
            Headers = HeaderCollection.FromDictionary(headers);
        }
    }

    public class HttpResponse<T>: HttpResponse
    {
        public T Body { get; init; }

        protected HttpResponse() : base()
        {
            Body = default;
        }
        protected HttpResponse(int statusCode, T body, Dictionary<string, string> headers) 
            : base(statusCode, headers)
        {
            Body = body;
        }
    }
}
