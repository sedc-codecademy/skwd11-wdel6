using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryOne
{
    internal static class HtmlGenerator
    {
        //public HtmlGenerator() { }

        public static (string Content, string Type) GetHtml(HttpRequest request)
        {
            var sb = @$"<!DOCTYPE html>
<html>
<head>
    <meta charset=""utf-8"">
    <title>Test</title>
</head>
<body>
    <h1>Test</h1>
    <p>Test</p>";
            if (string.IsNullOrEmpty(request.Uri))
            {
                sb += @$"<p>You requested the root page</p>";
            }
            else
            {
                sb += @$"<p>Uri is {request.Uri}</p>";
            }
            sb += @$"<p>Method is {request.Method}</p>";

            sb += @$"<p>Headers are</p>";
            sb += @$"<ul>";
            foreach (var (key, value) in request.Headers)
            {
                sb += @$"<li>{key}: {value}</li>";
            }
            sb += @$"</ul>";

            sb += @"</body>
</html>";
            return (sb, "text/html");
        }
    }
}
