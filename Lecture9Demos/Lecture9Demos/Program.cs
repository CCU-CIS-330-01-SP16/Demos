using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lecture9Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Assembly currentAssembly = Assembly.GetExecutingAssembly();
            //Console.WriteLine("FullName: {0}", currentAssembly.FullName);
            //Console.WriteLine("Location: {0}", currentAssembly.Location);
            //Console.WriteLine("CodeBase: {0}", currentAssembly.CodeBase);

            //Console.WriteLine();
            //Console.WriteLine("Modules:");
            //foreach (Module module in currentAssembly.Modules)
            //{
            //    Console.WriteLine("Module FQN: {0}", module.FullyQualifiedName);
            //}

            //Console.WriteLine();
            //Console.WriteLine("Attributes:");
            //foreach (var attribute in currentAssembly.CustomAttributes)
            //{
            //    Console.WriteLine(attribute);
            //}

            //Console.WriteLine();
            //Console.WriteLine("Types:");
            //foreach (var type in currentAssembly.GetTypes())
            //{
            //    Console.WriteLine(type);
            //}
        }
    }
}
