using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture7Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryAnimalNames();

            //DeferredExecution();

            //Projection();

            //LinqToSql();
        }

        private static void QueryAnimalNames()
        {
            string[] names = { "Monkey", "Bear", "Dog", "Cat" };

            // We want this variable to contain only names that have the letter "o".
            IEnumerable<string> namesWithO = null;

            // Without LINQ.
            var foundNames = new List<string>();
            foreach (var name in names)
            {
                if (name.Contains("o"))
                {
                    foundNames.Add(name);
                }
            }
            namesWithO = foundNames;

            // LINQ Where extension method used with named method as a delegate.
            //namesWithO = names.Where(new Func<string, bool>(FilterNames));
            //namesWithO = names.Where(FilterNames);

            // LINQ Where extension method used with anonymous method as delegate.
            //namesWithO = names.Where(delegate (string name) { return name.Contains("o"); });

            // LINQ Where extension method used with lambda expression as a delegate.
            //namesWithO = names.Where(n => n.Contains("o"));

            // LINQ using query syntax.
            //namesWithO = from n in names
            //             where n.Contains("o")
            //             select n;

            foreach (var name in namesWithO) //.OrderBy(n => n))
            {
                Console.WriteLine(name);
            }
        }

        private static bool FilterNames(string name)
        {
            return name.Contains("o");
        }

        private static void DeferredExecution()
        {
            List<string> names = new List<string> { "Monkey", "Bear", "Dog", "Cat" };
            var query = names.Where(n => n.Contains("B"));

            names.Add("Boar");

            foreach (var name in query)
            {
                Console.WriteLine(name);
            }
        }

        private static void Projection()
        {
            List<string> names = new List<string> { "Monkey", "Bear", "Dog", "Cat" };

            var query = names.Select((n, i) => new { Animal = n, Length = n.Length, Order = i });

            names.Add("Boar");

            foreach (var animal in query) { Console.WriteLine(animal); }
        }

        private static void LinqToSql()
        {
            AdventureWorksDataContext dc = new AdventureWorksDataContext();

            var query = dc.Persons
                .Select(p => new { FirstName = p.FirstName, LastName = p.LastName })
                .Where(p => p.FirstName == "Bob")
                .OrderBy(p => p.LastName)
                .ThenBy(p => p.FirstName);

            foreach (var person in query)
            {
                Console.WriteLine("{0}, {1}", person.LastName, person.FirstName);
            }
        }
    }
}
