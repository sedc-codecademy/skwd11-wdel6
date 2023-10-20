using Sedc.Server.Interface.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Interface.Responses
{
    public class StringHttpResponse : HttpResponse<string>
    {
        public StringHttpResponse(): base()
        {
        }
        public StringHttpResponse(int statusCode, string body, Dictionary<string, string> headers)
            : base(statusCode, body, headers)
        {
        }
    }
}
