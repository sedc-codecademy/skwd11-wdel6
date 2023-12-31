﻿using Sedc.Server.Core.Logging;
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
    internal class HtmlGenerator: IGenerator
    {
        public LoggerBase Logger { get; }
        public string Name { get; } = "Default HTML Generator";

        public HtmlGenerator(LoggerBase logger)
        {
            Logger = logger;
        }

        private (string Content, string Type) GetRequestEchoHtml(HttpRequest request)
        {
            var sb = new StringBuilder();
            sb.AppendLine(@$"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"">
    <title>Request Echo</title>
</head>
<body>
    <h1>Request Echo</h1>");
            if (string.IsNullOrEmpty(request.Uri.FullUri))
            {
                sb.AppendLine(@$"<p>You requested the root page</p>");
            }
            else
            {
                ;
                sb.AppendLine($@"<p>Path is {request.Uri.FullPath}</p>");

                sb.AppendLine($@"<p>Paths are</p>");
                sb.AppendLine($@"<ul>");
                foreach (var path in request.Uri.Paths)
                {
                    sb.AppendLine($@"<li>{path}</li>");
                }
                sb.AppendLine($@"</ul>");
                sb.AppendLine($@"<p>Query is {request.Uri.FullQuery}</p>");

                sb.AppendLine($@"<p>Queries are</p>");
                sb.AppendLine($@"<ul>");
                foreach (var (key, value) in request.Uri.Queries)
                {
                    sb.AppendLine($@"<li>{key}: {value}</li>");
                }
                sb.AppendLine($@"</ul>");
            }
            sb.AppendLine($@"<p>Method is {request.Method}</p>");

            sb.AppendLine($@"<p>Headers are</p>");
            sb.AppendLine($@"<ul>");
            foreach (var (key, value) in request.Headers)
            {
                sb.AppendLine($@"<li>{key}: {value}</li>");
            }
            sb.AppendLine($@"</ul>");

            sb.AppendLine(@"</body>
</html>");

            var response = sb.ToString();
            Logger.Debug($"Generated {response.Length} characters of response");
            return (sb.ToString(), "text/html");
        }

        public HttpResponse Generate(HttpRequest request) {

            (var content, var contentType) = GetRequestEchoHtml(request);
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
            return (request.Method == SedcMethod.Get);
        }
    }
}
