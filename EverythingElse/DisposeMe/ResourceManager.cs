using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposeMe
{
    internal class ResourceManager : IDisposable
    {
        public Resource Resource { get; set; }
        public ResourceManager() 
        { 
            Resource = new Resource();
        }

        public void Dispose()
        {
            if (Resource != null)
            {
                Resource.Dispose();
            }
        }
    }
}
