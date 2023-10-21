using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributing
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    internal class DatabaseAttribute: Attribute
    {
        public string TableName { get; set; }
        public DatabaseAttribute(string tableName) { 
            TableName = tableName;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    internal class FieldAttribute : Attribute
    {
        public string FieldName { get; set; }
        public FieldAttribute()
        {
        }
    }
}
