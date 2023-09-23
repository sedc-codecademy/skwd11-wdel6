using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposeMe
{
    internal class Resource : IDisposable
    {
        private static bool existing = false;
        private bool disposedValue;

        public Resource() {
            // WeakReference x = new WeakReference(this, true);

            if (existing)
            {
                throw new InvalidOperationException("Ne mojt");
            }
            existing = true;
            Console.WriteLine("I'm being created");
        }

        public void Open() {
            Console.WriteLine("I'm being opened");
        }

        public void Dispose()
        {
            existing = false;
            Console.WriteLine("I'm being disposed");
        }
    }
}
