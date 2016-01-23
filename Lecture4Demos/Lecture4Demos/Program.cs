using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture4Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 23;
            int y = 4;
            int z;
            Add(x, y, out z);
            Console.WriteLine(z);
            Console.WriteLine("x={0}, y={1}", x, y);

            string myValue = "72";
            //int myValueInt = (int)myValue;

            int myValueInt2;
            bool result = int.TryParse(myValue, out myValueInt2);
            Console.WriteLine(result + " " + myValueInt2);

            int myInt = 23;
            float myFloat = myInt;
        }

        public static void Add(int x, int y, out int z, bool useStandardMath = true)
        {
            if (useStandardMath)
            {
                z = x + y;
            }

            z = x - y;
            //z = 42;
        }

        public static int Add(ref int x, ref int y)
        {
            x = 5;
            y = 10;
            return x + y;
        }
    }
}
