using Sedc.Server.Core.Requests;
using Sedc.Server.Core.Responses;
using Sedc.Server.Interface.Entities;
using Sedc.Server.Interface.Requests;
using Sedc.Server.Interface.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Core.Processing
{
    internal static class ActualProcessor
    {
        internal static HttpResponse Process(HttpRequest request)
        {
            // Code that displays the request object we got
            //Console.WriteLine($"Processing request: {request.Method} {request.Uri}");

            //foreach (var (key, value) in request.Headers)
            //{
            //    Console.WriteLine($"The value of {key} is {value}");
            //}

            //Console.WriteLine();

            //Console.WriteLine("Body is");
            //Console.WriteLine(request.Body);

            if (request is InvalidHttpRequest)
            {
                return new InvalidHttpResponse();
            }

            int statusCode = 200;
            string body;
            string contentType;

            if (request.Method == SedcMethod.Get)
            {
                (body, contentType) = HtmlGenerator.GetRequestEchoHtml(request);
            }
            else
            {
                body = "Hello world!";
                contentType = "text/plain";
            }
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", contentType },
                { "Content-Length", body.Length.ToString() }
            };

            return new HttpResponse
            {
                Body = body,
                StatusCode = statusCode,
                Headers = HeaderCollection.FromDictionary(headers)
            };
        }
    }
}
