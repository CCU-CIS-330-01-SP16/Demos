using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringValue = ConvertValue(2300);
            Console.WriteLine("{0}: {1}", stringValue.GetType().Name, stringValue);

            int intValue = ConvertValue("17");
            Console.WriteLine("{0}: {1}", intValue.GetType().Name, intValue);

            //DateTime dateValue = ConvertValue<string, DateTime>("2016-02-29 10:30:45");
            //Console.WriteLine("{0}: {1}", dateValue.GetType().Name, dateValue);
        }

        private static string ConvertValue(int value)
        {
            return value.ToString();
        }

        private static int ConvertValue(string value)
        {
            return Convert.ToInt32(value);
        }

        private static TTo ConvertValue<TFrom, TTo>(TFrom value)
        {
            return (TTo)Convert.ChangeType(value, typeof(TTo));
        }
    }
}
