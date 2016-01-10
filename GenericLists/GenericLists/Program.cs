using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericLists
{
    class Program
    {
        static void Main(string[] args)
        {
            // ArrayList allows any type. Value types are boxed.
            var myArrayList = new ArrayList() { 23, "Matt", DateTime.Now };
            foreach (var value in myArrayList)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();

            // A closed generic list can also allow any type. Value types are boxed here as well.
            var myObjectList = new List<object>() { 23, "Matt", DateTime.Now };
            foreach (var value in myObjectList)
            {
                Console.WriteLine(value);
            }

            // But, in most cases, we need to ensure a collection contains only one type.
            // Ex: We want to calculate the sum of all values in a collection.
        }
    }
}
