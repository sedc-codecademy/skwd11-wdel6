using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderDemo
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Title { get; set; }

        public string Email { get; set; }

        public string Info()
        {
            return $"{FirstName} {LastName} is a {Title} and can be reached at {Email}";
        }

        
    }
}
