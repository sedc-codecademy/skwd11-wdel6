using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equality
{
    internal struct PersonStruct
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PersonStruct(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

    }
}
