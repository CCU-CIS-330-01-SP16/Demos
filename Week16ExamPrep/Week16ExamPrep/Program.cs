using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week16ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            Question1();
            //Question2();
            //Question3();
            //Question4();
            //Question5();
            //Question6();
        }

        private static void Question1()
        {
            // Which asynchronous programming pattern is the recommended approach as of .NET 4.0?

            // Asynchronous Programming Model (APM) pattern
            // Event-based Asynchronous Pattern (EAP)
            // Task-based Asynchronous Pattern (TAP)

            // See https://msdn.microsoft.com/en-us/library/jj152938(v=vs.110).aspx
        }

        private static void Question2()
        {
            // How do I read a file asynchronously using Task-based Asynchronous Pattern (TAP)?

            string contents = ReadFileAsync("test.txt").Result;

            Console.WriteLine(contents);
        }

        private static async Task<string> ReadFileAsync(string path)
        {
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                return await reader.ReadToEndAsync();
            }
        }

        private static void Question3()
        {
            // You need to write data to a file. Which lines should you use and in which order?
            // Choose the fewest number of lines possible.

            // writer.Close();
            // string fileName = "file.txt";
            // StreamWriter writer = null;
            // writer.Open();
            // writer.Flush();
            // writer.AutoFlush = true;
            // writer = new StreamWriter(fileName);
            // writer.Write("The quick brown fox jumps over the lazy dog.");
        }

        private static void Question4()
        {
            List<Animal> animals = new List<Animal>
            {
                new Animal { Name = "Red Robin", NumberOfLegs = 2 },
                new Animal { Name = "George", NumberOfLegs = 2 },
                new Animal { Name = "Max", NumberOfLegs = 4 },
                new Animal { Name = "Furry", NumberOfLegs = 4 }
            };

            var output = from a in animals
                         group a by a.NumberOfLegs into legs
                         select new { sorted = legs.Key, Animals = legs };

            // How many objects will exist in the output collection?
            // The sorted property of the collection will be of what type?

            //Console.WriteLine(output.Count());
            //Console.WriteLine(output.First().sorted.GetType().Name);
        }

        public static void Question5()
        {
            // You are creating a Game class that has a Score member. You need to ensure
            // external code can assign a value to Score but you need to restrict the range
            // of values for Score. What approach should you use for the Score member?

            // protected static Score
            // public static extern Score;
            // public Score { get {...}; private set {...}; }
            // public Score { get {...}; set {...}; }
        }

        public static void Question6()
        {
            AnimalTracker tracker = new AnimalTracker();

            // How do I add a new animal to the animal tracker with the least possible code?

            //tracker.AddAnimal(...);
        }
    }
}
