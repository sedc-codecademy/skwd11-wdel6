using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedc.Server.Interface.Entities
{
    using Sedc.Server.Interface.Exceptions;

    using System.Collections;
    using System.Collections.Immutable;

    public class HeaderCollection : IEnumerable<KeyValuePair<string, string>>
    {
        static HeaderCollection()
        {
            Empty = new HeaderCollection(new Dictionary<string, string>());
        }
        public static HeaderCollection Empty { get; private set; }

        public static HeaderCollection FromDictionary(Dictionary<string, string> headers)
        {
            return new HeaderCollection(headers);
        }

        private readonly ImmutableDictionary<string, string> _headers;

        public string this[string name]
        {
            get
            {
                return _headers[name];
            }
        }

        public HeaderCollection(Dictionary<string, string> headers)
        {
            var builder = ImmutableDictionary.CreateBuilder<string, string>();
            builder.AddRange(headers);
            _headers = builder.ToImmutable();
        }

        public void AddHeader(string name, string value)
        {
            _headers.Add(name, value);
        }

        public void RemoveHeader(string name)
        {
            _headers.Remove(name);
        }

        public bool HasHeader(string name)
        {
            return _headers.ContainsKey(name);
        }

        public string GetHeader(string name)
        {
            if (!HasHeader(name))
            {
                throw new SedcServerException($"Header with name {name} does not exist");
            }
            return _headers[name];
        }

        //public bool TryGetHeader(string name, out string value)
        //{
        //    return _headers.TryGetValue(name, out value);
        //}

        public (bool, string?) TryGetHeader(string name)
        {
            var hasValue = _headers.TryGetValue(name, out string? value);
            return (hasValue, value);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _headers.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _headers.GetEnumerator();
        }
    }
}
