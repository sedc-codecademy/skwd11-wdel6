﻿using Sedc.Server.Core.Logging;
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
    internal class FileReader: IGenerator
    {
        public LoggerBase Logger { get; }
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

        public (string Content, string Type) Generate(HttpRequest request)
        {
            return GetFileContents(request.Uri.FullPath);
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
