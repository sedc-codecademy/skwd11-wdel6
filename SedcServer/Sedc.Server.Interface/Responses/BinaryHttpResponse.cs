using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Interface.Responses
{
    public class BinaryHttpResponse: HttpResponse<byte[]>
    {
        public BinaryHttpResponse() : base()
        {
        }
        public BinaryHttpResponse(int statusCode, byte[] body, Dictionary<string, string> headers)
            : base(statusCode, body, headers)
        {
        }
    }
}
