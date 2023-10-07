using Sedc.Server.Core.Logging;
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
    internal class ActualProcessor
    {
        public Logger Logger { get; }
        public HtmlGenerator Generator { get; }
        public FileReader FileReader { get; }

        public ApiResponseGenerator ApiGenerator { get; }

        public ActualProcessor(Logger logger) {
            this.Logger = logger;
            this.Generator = new HtmlGenerator(Logger);
            this.FileReader = new FileReader(Logger);
            this.ApiGenerator = new ApiResponseGenerator(Logger);
        }


        internal HttpResponse Process(HttpRequest request)
        {
            if (request is InvalidHttpRequest)
            {
                return new InvalidHttpResponse();
            }

            int statusCode = 200;
            string body;
            string contentType;

            if (request.Method == SedcMethod.Get)
            {
                if (request.Uri.FullPath == "index.html")
                {
                    // serve public/index.html file
                    (body, contentType) = FileReader.GetFileContents(request.Uri.FullPath);
                } 
                else
                {
                    (body, contentType) = Generator.GetRequestEchoHtml(request);
                }

            }
            else
            {
                (body, contentType) = ApiGenerator.GetApiResponse(request);
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
