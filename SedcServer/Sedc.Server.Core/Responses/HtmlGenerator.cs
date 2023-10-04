using Sedc.Server.Interface.Requests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Core.Responses
{
    internal static class HtmlGenerator
    {
        //public HtmlGenerator() { }

        public static (string Content, string Type) GetRequestEchoHtml(HttpRequest request)
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
            return (sb.ToString(), "text/html");
        }
    }
}
