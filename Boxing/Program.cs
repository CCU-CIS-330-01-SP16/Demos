using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();

            for(int i = 0; i < 10000000; i++)
            {
                object obj = i;
                //int y = i;
            }

            sw.Stop();

            Console.WriteLine("{0}ms", sw.ElapsedMilliseconds);
        }
    }
}
