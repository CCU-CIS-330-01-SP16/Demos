using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPillars
{
    class Program
    {
        static void Main(string[] args)
        {
            //Giraffe g = new Giraffe();
            //g.NumberOfLegs = 42;
            //g.Speak();
            //Console.WriteLine(g.NumberOfLegs);

            //Animal a = GetAnimalFromBarn();
            //a.Speak();

            int age = 42;
            age = 21;
            int age2 = age;

            Console.WriteLine("{0},{1}", age, age2);
        }

        static Animal GetAnimalFromBarn()
        {
            return new Giraffe();
        }
    }


}
