using Sedc.Server.Core.Logging;
using Sedc.Server.Core.Responses;
using Sedc.Server.Interface.Entities;
using Sedc.Server.Interface.Logging;
using Sedc.Server.Interface.Requests;
using Sedc.Server.Interface.Responses;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Core.Processing
{
    internal class FolderReader : IGenerator
    {
        public string FolderPath { get; }
        public string SitePath { get; }
        public LoggerBase Logger { get; }
        public string Name { get => $"Folder Reader for path {FolderPath} at site {SitePath}"; } 

        public FolderReader(string folderPath, string sitePath, LoggerBase logger)
        {
            FolderPath = folderPath;
            SitePath = sitePath;
            Logger = logger;
        }

        internal string GetTextFileContents(string filename)
        {
            var realPath = Path.Combine(FolderPath, filename);
            string result = File.ReadAllText(realPath, Encoding.UTF8);
            return result;
        }

        internal byte[] GetBinaryFileContents(string filename)
        {
            var realPath = Path.Combine(FolderPath, filename);
            var result = File.ReadAllBytes(realPath);
            return result;
        }

        internal (string ContentType, bool IsBinary) GetContentType(string filename)
        {
            var extension = Path.GetExtension(filename);
            var result = extension.ToLowerInvariant() switch
            {
                ".css" => ("text/css", false),
                ".txt" => ("text/plain", false),
                ".png" => ("image/png", true),
                ".js" => ("application/javascript", false),
                _ => ("text/html", false)
            };

            return result;
        }

        public HttpResponse Generate(HttpRequest request)
        {
            var fileName = GetFileName(request.Uri);
            (var contentType, var isBinary) = GetContentType(fileName);
            var statusCode = 200;

            var realPath = Path.Combine(FolderPath, fileName);
            if (!File.Exists(realPath))
            {
                return new InvalidHttpResponse(404, $"File {fileName} not found");
            }

            if (isBinary)
            {
                var body = GetBinaryFileContents(fileName);
                var headers = new Dictionary<string, string>
                {
                    { "Content-Type", contentType },
                    { "Content-Length", body.Length.ToString() }
                };
                return new BinaryHttpResponse
                {
                    Body = body,
                    StatusCode = statusCode,
                    Headers = HeaderCollection.FromDictionary(headers)
                };
            } 
            else
            {
                var body = GetTextFileContents(fileName);
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
        }

        private string GetFileName(SedcUri uri)
        {
            if (uri.Paths.Length == 1)
            {
                return "index.html";
            }
            return uri.Paths[1];
        }

        private bool CheckSitePath(SedcUri uri)
        {
            if (uri.Paths.Length < 1)
            {
                return false;
            }
            var sitePath = uri.Paths[0];
            if (string.IsNullOrEmpty(sitePath))
            {
                return false;
            }
            return sitePath == SitePath;
        }

        public bool WannaConsume(HttpRequest request)
        {
            if (request.Method == SedcMethod.Get && CheckSitePath(request.Uri))
            {
                return true;
            }
            return false;
        }
    }
}
