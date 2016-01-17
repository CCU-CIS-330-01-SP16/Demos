using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            ConstructStrings();
            ValidateStrings();
            BuildString(new string[] { "first string", "second string", "third string" });

            ConstructDatesAndTimes();
            DateAndTimeMath();
            DateAndTimeComparison();
            NumberMath();
        }

        private static void ConstructStrings()
        {
            string string1 = "some value";
            Console.WriteLine(string1);

            string string2 = new string(new char[] { 'h', 'e', 'l', 'l', 'o' });
            Console.WriteLine(string2);

            string string3 = new string('a', 23);
            Console.WriteLine(string3);
        }

        private static void ValidateStrings()
        {
            string string1 = null;
            Console.WriteLine("string1 is null? {0}", string1 == null);
            Console.WriteLine("string1 IsNullOrEmpty? {0}", string.IsNullOrEmpty(string1));

            string string2 = "";
            Console.WriteLine("string2 is empty? {0}", string2 == string.Empty);

            string2 = string.Empty;
            Console.WriteLine("string2 is empty? {0}", string2 == string.Empty);
            Console.WriteLine("string2 IsNullOrEmpty? {0}", string.IsNullOrEmpty(string2));

            string string3 = "    ";
            Console.WriteLine("string3 IsNullOrWhiteSpace? {0}", string.IsNullOrWhiteSpace(string3));
        }

        private static void BuildString(string[] stringValues)
        {
            StringBuilder builder = new StringBuilder();

            foreach (string value in stringValues)
            { 
                builder.Append(value);
            }

            Console.WriteLine(builder.ToString());
        }

        private static void ConstructDatesAndTimes()
        {
            DateTime date1 = new DateTime(2004, 2, 23);
            Console.WriteLine(date1);

            DateTime date2 = DateTime.Now;
            Console.WriteLine(date2);

            DateTimeOffset date3 = DateTimeOffset.Now;
            Console.WriteLine(date3);

            TimeSpan timespan1 = TimeSpan.FromHours(5);
            Console.WriteLine(timespan1);
        }

        private static void DateAndTimeMath()
        {
            DateTime date1 = new DateTime(2004, 2, 23, 4, 00, 00);
            DateTime date2 = new DateTime(2004, 2, 25, 5, 10, 30);
            Console.WriteLine(date2 - date1);

            DateTime date3 = date1 + TimeSpan.FromMinutes(20);
            Console.WriteLine(date3);
        }

        private static void DateAndTimeComparison()
        {
            DateTime date1 = new DateTime(2004, 2, 23, 4, 00, 00);
            DateTime date2 = new DateTime(2004, 2, 25, 5, 10, 30);
            Console.WriteLine(date2 > date1);
        }

        private static void NumberMath()
        {
            double value = Math.Pow(2, 2);
            Console.WriteLine(value);
        }
    }
}
