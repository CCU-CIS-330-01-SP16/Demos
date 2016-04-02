using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture20Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Console.WriteLine(ExceptionHandlingDemo());

            //ExamDemo();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("**** My Custom Unhandled Exception Handler *****: {0}", e.ExceptionObject.ToString());
        }

        private static int? ExceptionHandlingDemo()
        {
            string x = "23";
            string y = "asdf";

            try
            {
                return AddStringValues(x, y);
            }
            catch (ArgumentNullOrWhitespaceException ex)
            {
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
                //return -1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("*** WARNING: Fallback Handler Used ***: {0}: {1}", ex.GetType().Name, ex.Message);
            }
            finally
            {
                Console.WriteLine("Finally");
            }

            return null;
        }

        private static int AddStringValues(string x, string y)
        {
            if(string.IsNullOrWhiteSpace(x))
            {
                throw new ArgumentNullOrWhitespaceException("Argument must have a value other than null or whitespace.", nameof(x));
            }

            if (string.IsNullOrWhiteSpace(y))
            {
                throw new ArgumentNullOrWhitespaceException("Argument must have a value other than null or whitespace.", nameof(y));
            }

            int xValue = Int32.Parse(x);
            int yValue = Int32.Parse(y);
            //int yValue;

            if (!Int32.TryParse(y, out yValue))
            {
                throw new ArgumentException($"The value \"{y}\" for y could not be converted to an int.");
            }

            return xValue + yValue;
        }

        class Animal { }

        class Frog : Animal { }

        static void Speak(object obj) { Console.WriteLine("In Speak(object)"); }
        static void Speak(Animal a) { Console.WriteLine("In Speak(Animal)"); }
        static void Speak(Frog f) { Console.WriteLine("In Speak(Frog)"); }

        static void ExamDemo()
        {
            object a = new Frog();
            Speak(a);
        }
    }
}
