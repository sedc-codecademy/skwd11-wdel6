using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attributing
{
    [Database("persons")]
    internal class Person
    {
        public int Id { get; set; }
        
        [Field(FieldName = "Name")]
        public string FirstName { get; set; }
        
        [Field(FieldName = "Surname")]
        public string LastName { get; set; }
        public string Description { get; set; }
        public Person() { }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }

        private string HiddenMethod()
        {
            return $"{LastName}, {FirstName}";
        }

    }
}
