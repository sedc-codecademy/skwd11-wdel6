using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Interface.Exceptions
{
    public class SedcServerException: ApplicationException
    {
        public SedcServerException(string message): base(message)
        {
        }

        public SedcServerException(string message, Exception innerException): base(message, innerException)
        {
        }

        public SedcServerException() : this("Sedc Server Exception")
        {
        }
    }
}
