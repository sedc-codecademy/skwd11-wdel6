using Sedc.Server.Core.Logging;
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
        public FolderReader(string folderPath, string sitePath, LoggerBase logger)
        {
            FolderPath = folderPath;
            SitePath = sitePath;
            Logger = logger;
        }

        internal (string Content, string Type) GetFileContents(string filename)
        {
            var realPath = Path.Combine(FolderPath, filename);
            var extension = Path.GetExtension(filename);
            var contentType = extension.ToLowerInvariant() switch
            {
                ".css" => "text/css",
                ".txt" => "text/plain",
                _ => "text/html"
            };

            string result = File.ReadAllText(realPath, Encoding.UTF8);
            return (result, contentType);
        }

        public (string Content, string Type) Generate(HttpRequest request)
        {
            var fileName = GetFileName(request.Uri);
            var response = GetFileContents(fileName);
            return response;
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
