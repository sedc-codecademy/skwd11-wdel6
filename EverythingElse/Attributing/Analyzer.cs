using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Attributing
{
    internal static class Analyzer
    {
        public static void Analyze(Type type)
        {
            var methodInfos = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("Methods");

            foreach (var methodInfo in methodInfos.Where(mi => mi.DeclaringType == type))
            {
                Console.WriteLine($"  {methodInfo.Name}");
            }

            var propInfos = type.GetProperties();
            Console.WriteLine("Properties");
            foreach (var propInfo in propInfos)
            {
                Console.WriteLine($"  {propInfo.Name}");
                var fattr = propInfo.GetCustomAttribute<FieldAttribute>();
                if (fattr == null)
                {
                    Console.WriteLine("This property is not marked with field");
                } 
                else
                {
                    Console.WriteLine($"This property IS marked with field {fattr.FieldName}");
                }

            }

            var person = new Person
            {
                FirstName = "Wekoslav",
                LastName = "Stefanovski"
            };
            //var method = person.GetType().GetMethod("HiddenMethod", BindingFlags.Instance | BindingFlags.NonPublic);

            //var result = method.Invoke(person, new object[] { });

            //Console.WriteLine(result);

            Console.WriteLine("Attributes");
            var attrs = type.GetCustomAttributes();
            Console.WriteLine($"Class has {attrs.Count()} attributes");


        }
    }
}
