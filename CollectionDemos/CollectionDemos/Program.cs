using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionDemos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Simple list of values.
            List<int> list = new List<int>() { 72, 93, 46, 22 };
            list.Add(42);
            list.Remove(72);
            Print(list);

            // Key/Value pairs
            Dictionary<string, int> ages = new Dictionary<string, int>()
            {
                { "Matt", 42 },
                { "Christine", 43 },
                { "Ashton", 19 },
                { "Ryan", 14 }
            };
            ages.Add("Max", 92);
            ages.Remove("Max");
            Print(ages);

            // First In First Out (FIFO)
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(99);
            queue.Enqueue(88);
            queue.Enqueue(77);
            queue.Enqueue(66);
            queue.Dequeue();
            Print(queue);

            // Last In First Out (LIFO)
            Stack<int> stack = new Stack<int>();
            stack.Push(99);
            stack.Push(88);
            stack.Push(77);
            stack.Push(66);
            stack.Pop();
            Print(stack);
        }

        private static void Print<T>(IEnumerable<T> list)
        {
            Console.Write(list.GetType().Name + ": ");

            foreach (T value in list)
            {
                Console.Write(value + " ");
            }

            Console.WriteLine();
        }
    }
}
