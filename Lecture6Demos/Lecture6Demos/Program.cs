using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture6Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal george = new Animal();

            george.BirthDate = new DateTime(2016, 1, 7, 11, 23, 00);
            //george.BirthDate = null;

            Console.WriteLine("George was born on {0}.", george.BirthDate);
            TimeSpan? lifeSpan = george.LifeSpan();
            if (lifeSpan.HasValue)
            {
                Console.WriteLine("George is now {0} days old.", Math.Round(george.LifeSpan().Value.TotalDays, 2));
            }

            george.Running += A_Running;
            george.Running += A_Running;
            //george.Running -= A_Running;
            //george.Running += (s, e) => Console.WriteLine("Running");

            //george.Stopped += A_Stopped;
            //george.Stopped += A_Stopped;
            //george.Stopped -= A_Stopped;
            george.Stopped += (s, e) => Console.WriteLine("Stopped Event Happened");

            try
            {
                george.Run();
                Console.WriteLine(george.Status);
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            george.Stop();
            Console.WriteLine(george.Status);

            // Action<T> delegate and anonymous methods.
            //DoAction(george, a => a.Run());
            //DoAction(george, a => a.Stop());

            // Anonymous Types
            //var frank = new { Name = "Frank", BirthDate = DateTime.Now };
            //Console.WriteLine(frank);

            // Dynamic Types
            //dynamic bob = new Animal();
            //Console.WriteLine(bob.Status);
            //bob.Run();
            //Console.WriteLine(bob.Status);
            //bob.Jump();

            //dynamic myInt = 23;
            //int myInt2 = myInt;
            //long myLong = myInt;

            // RuntimeBinderException: Cannot implicitly convert type 'int' to 'string'
            //string myString = myInt;

            //dynamic myString2 = "42";

            // RuntimeBinderException: Cannot implicitly convert type 'string' to 'int'
            //int myInt3 = myString2;

#if MATT
                        Console.WriteLine("Matt mode");
#elif DEBUG
            Console.WriteLine("Debug mode");
#else
                        Console.WriteLine("Release mode");
#endif

            DoAction(AcceptString);
        }

        public delegate void TransferComplete(string result);

        private static void AcceptString(string value)
        {
            Console.WriteLine(value);
        }

        private static void DoAction(TransferComplete action)
        {
           // action("all looks good");
        }

        private static void DoSomething<T>(T item)
        {
            Something(item);
        }

        private static void Something<T>(T item)
        {
            Console.WriteLine(item);
        }

        private static void A_Stopped(object sender, EventArgs e)
        {
            Console.WriteLine("Stopped");
        }

        private static void A_Running(object sender, EventArgs e)
        {
            Console.WriteLine("Running Event Occurred");
        }
    }
}
