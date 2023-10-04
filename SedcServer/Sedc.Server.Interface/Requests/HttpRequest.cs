using Sedc.Server.Interface.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Interface.Requests
{
    public class HttpRequest
    {
        public SedcMethod Method { get; init; } = SedcMethod.Invalid;
        public SedcUri Uri { get; init; } = SedcUri.Empty;
        public HeaderCollection Headers { get; init; } = HeaderCollection.Empty;
        public string Body { get; init; } = string.Empty;
    }
}
