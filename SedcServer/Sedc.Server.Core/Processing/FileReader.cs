using Sedc.Server.Core.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Core.Processing
{
    internal class FileReader
    {
        public Logger Logger { get; }
        public FileReader(Logger logger)
        {
            Logger = logger;
        }

        internal (string Content, string Type) GetFileContents(string fullPath)
        {
            var realPath = Path.Combine("public", fullPath);
            string result = File.ReadAllText(realPath, Encoding.UTF8);
            return (result, "text/html");
        }
    }
}
