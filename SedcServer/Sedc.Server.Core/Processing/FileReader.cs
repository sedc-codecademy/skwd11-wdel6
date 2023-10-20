using Sedc.Server.Core.Logging;
using Sedc.Server.Interface.Entities;
using Sedc.Server.Interface.Logging;
using Sedc.Server.Interface.Requests;
using Sedc.Server.Interface.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Core.Processing
{
    internal class FileReader: IGenerator
    {
        public LoggerBase Logger { get; }
        public string Name { get; } = "Default index.html Generator";

        public FileReader(LoggerBase logger)
        {
            Logger = logger;
        }

        internal (string Content, string Type) GetFileContents(string fullPath)
        {
            var realPath = Path.Combine("public", fullPath);
            string result = File.ReadAllText(realPath, Encoding.UTF8);
            return (result, "text/html");
        }

        public HttpResponse Generate(HttpRequest request)
        {
            (var content, var contentType) = GetFileContents(request.Uri.FullPath);
            var statusCode = 200;
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", contentType },
                { "Content-Length", content.Length.ToString() }
            };

            return new StringHttpResponse
            {
                Body = content,
                StatusCode = statusCode,
                Headers = HeaderCollection.FromDictionary(headers)
            };
        }

        public bool WannaConsume(HttpRequest request)
        {
            if (request.Method == SedcMethod.Get && request.Uri.FullPath == "index.html")
            {
                return true;
            }
            return false;
        }
    }
}
