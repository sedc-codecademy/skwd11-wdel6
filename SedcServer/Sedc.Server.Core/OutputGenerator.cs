using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sedc.Server.Core.Logging;
using Sedc.Server.Interface.Logging;
using Sedc.Server.Interface.Responses;

namespace Sedc.Server.Core
{

    internal static class OutputGenerator
    {
        internal static ReadOnlySpan<byte> MakeResponse(HttpResponse response, LoggerBase logger)
        {
            var responseString = GetResponseString(response, logger);
            var bytes = Encoding.UTF8.GetBytes(responseString);
            return bytes;
        }

        private static string GetResponseString(HttpResponse response, LoggerBase logger)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"HTTP/1.1 {response.StatusCode}");
            foreach (var (key, value) in response.Headers)
            {
                sb.AppendLine($"{key}: {value}");
            }
            sb.AppendLine();
            sb.AppendLine(response.Body);
            return sb.ToString();
        }
    }
}
