using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Interface.Configuration
{
    public enum LogLevel
    {
        Debug = 0, // message that is interesting for client developers
        Info = 1,  // message that is interesting for analytics
        Warning = 2, // message that is somewhat interesting to support
        Error = 3, // message that is very interesting to support
        Fatal = 4 // message that is VERY very interesting to support
    }
}
