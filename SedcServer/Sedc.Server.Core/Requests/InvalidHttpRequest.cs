using Sedc.Server.Interface.Entities;
using Sedc.Server.Interface.Requests;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Core.Requests
{
    internal class InvalidHttpRequest : HttpRequest
    {
        private static readonly InvalidHttpRequest _request = new();
        private InvalidHttpRequest()
        {
            Method = SedcMethod.Invalid;
            Uri = SedcUri.Empty;
            Headers = HeaderCollection.Empty;
            Body = string.Empty;
        }

        public static InvalidHttpRequest Invalid { get { return _request; } }

    }
}
