using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Accessing
{
    internal class Person
    {
        // private string firstName;
        //public string GetFirstName()
        //{
        //    return firstName;
        //}
        //public void SetFirstName(string value)
        //{
        //    firstName = value;
        //}   

        //public string FirstName
        //{
        //    get
        //    {
        //        return firstName;
        //    }
        //    set
        //    {
        //        if (firstName != null)
        //        {
        //            throw new InvalidOperationException("Cannot change first name");
        //        }
        //        firstName = value;
        //    }
        //}
        public string FirstName { get; init; }

        public string LastName { get; init; }

        public Person() { }

        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        private string fullNameCache;

        public string FullName
        {
            get
            {
                if (fullNameCache == null)
                {
                    Console.WriteLine("CALCULATING FULLNAME");
                    fullNameCache = $"{FirstName} {LastName}";
                }
                return fullNameCache;
                // return $"{FirstName} {LastName}";
            }
        }

        public override string ToString()
        {
            return FullName;
        }

        //public void ChangeName(string firstName, string lastName)
        //{
        //    this.FirstName = firstName;
        //    this.LastName = lastName;
        //}
    }
}
