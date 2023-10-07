using Sedc.Server.Interface.Requests;

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Interface.Responses
{
    public interface IGenerator
    {
        bool WannaConsume(HttpRequest request);
        (string Content, string Type) Generate(HttpRequest request);
    }
}
