using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sedc.Server.Core.Logging;
using Sedc.Server.Core.Responses;
using Sedc.Server.Interface.Exceptions;
using Sedc.Server.Interface.Logging;
using Sedc.Server.Interface.Responses;

namespace Sedc.Server.Core
{

    internal static class OutputGenerator
    {
        public static ReadOnlySpan<byte> MakeResponse(HttpResponse response, LoggerBase logger)
        {
            if (response is BinaryHttpResponse binaryResponse)
            {
                return MakeResponse(binaryResponse, logger);
            }
            if (response is StringHttpResponse stringResponse)
            {
                return MakeResponse(stringResponse, logger);
            }
            if (response is InvalidHttpResponse invalidResponse)
            {
                return MakeResponse(invalidResponse, logger);
            }

            logger.Fatal("Unknown type of HttpResponse");
            throw new SedcServerException("Unknown type of HttpResponse");
        }

        private static ReadOnlySpan<byte> MakeResponse(BinaryHttpResponse response, LoggerBase logger)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"HTTP/1.1 {response.StatusCode}");
            foreach (var (key, value) in response.Headers)
            {
                sb.AppendLine($"{key}: {value}");
            }
            sb.AppendLine();
            var headerString = sb.ToString();
            var headerBytes = Encoding.UTF8.GetBytes(headerString);
            var responseBytes = headerBytes.Concat(response.Body);
            
            return responseBytes.ToArray();
        }

        private static ReadOnlySpan<byte> MakeResponse(StringHttpResponse response, LoggerBase logger)
        {
            var responseString = GetResponseString(response, logger);
            var bytes = Encoding.UTF8.GetBytes(responseString);
            return bytes;
        }

        private static ReadOnlySpan<byte> MakeResponse(InvalidHttpResponse response, LoggerBase logger)
        {
            var responseString = GetResponseString(response, logger);
            var bytes = Encoding.UTF8.GetBytes(responseString);
            return bytes;
        }

        private static string GetResponseString(HttpResponse<string> response, LoggerBase logger)
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
