using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equality
{
    // We've implemented value semantics for PersonClass
    // Not something you'd do in real life, but it's a good example
    internal class PersonClass : IEquatable<PersonClass>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }  
        
        public PersonClass(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override bool Equals(object obj)
        {
            Console.WriteLine("Called object equals");
            var other = obj as PersonClass;
            if (ReferenceEquals(other,null))
            {
                if (obj is PersonStruct personStruct)
                {
                    var otherAsClass = PersonClass.FromStruct(personStruct);
                    return Equals(otherAsClass);
                }
                return false;
            }
                

            return Equals(other);
        }

        public bool Equals(PersonClass? other)
        {
            Console.WriteLine("Called PersonClass equals");
            if (ReferenceEquals(other, null))
            {
                return false;
            }
            return FirstName == other.FirstName && LastName == other.LastName;
        }

        public static bool operator ==(PersonClass? left, PersonClass? right)
        {
            Console.WriteLine("Called operator ==");
            if (ReferenceEquals(left, right))
                return true;
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }
            return left.Equals(right);
        }

        public static bool operator !=(PersonClass? left, PersonClass? right)
        {
            Console.WriteLine("Called operator !=");
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode();
        }

        public static PersonClass FromStruct(PersonStruct personStruct)
        {
            return new PersonClass(personStruct.FirstName, personStruct.LastName);
        }
    }
}
