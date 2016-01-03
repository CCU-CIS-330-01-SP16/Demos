using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorExecutionOrder
{
    class Person : Contact
    {
        static Person()
        {
            Console.WriteLine("Static Person");
        }

        public Person()
        {
            Console.WriteLine("Person");
        }

        public Person(string name)
            : this()
        {
            Console.WriteLine("Person with name");
            Name = name;
        }

        public string Name { get; set; }

    }
}
