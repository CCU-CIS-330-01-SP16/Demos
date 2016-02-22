using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture14Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            DebuggerDemo();

            //LoggingDemo();

            //StackTraceDemo();

            //DumpFileDemo();

            //PerformanceCountersDemo();

            //CodeContractsDemo();
        }

        static void DebuggerDemo()
        {
            int localVariable = 23;

            Console.WriteLine("Start debugging here");

            Debugger.Log(1, "Demo", "Demo debugger log message.");

            if (Debugger.IsAttached)
            {
                Debugger.Break();
            }

            //Debug.Assert(localVariable < 20, "Local variable should be less than 20.");

            Console.WriteLine("Continue program...");
        }

        static void LoggingDemo()
        {
            Debug.WriteLine("{0}: Debug logging message", DateTime.Now);
            Trace.WriteLine(string.Format("{0}: Trace logging message", DateTime.Now));
        }

        static void StackTraceDemo()
        {
            int numerator = 42;
            int denominator = 0;

            try
            {
                double value = numerator / denominator;
            }
            catch(Exception ex)
            {
                Trace.WriteLine(string.Format("{0}: Error occurred calculating value. {1}", DateTime.Now, ex));
            }

            // Stack trace is also available without getting an exception.
            //StackTrace stackTrace = new StackTrace(true);
            //Console.WriteLine("StackTrace: {0}", stackTrace);
        }

        static void DumpFileDemo()
        {
            Process deadlocker = Process.Start("DeadLocker.exe");
            deadlocker.WaitForExit();
        }

        static void PerformanceCountersDemo()
        {
            Console.WriteLine("Press any key to stop...");

            CountdownEvent stopEvent = new CountdownEvent(1);

            Thread pcThread = new Thread(() =>
            {
                using (PerformanceCounter counter = new PerformanceCounter("Processor", "% Processor Time", "_Total"))
                {
                    while(!stopEvent.IsSet)
                    {
                        Console.WriteLine("% Processor Time: {0}", counter.NextValue());
                        Thread.Sleep(1000);
                    }
                }
            });

            pcThread.Start();

            Console.ReadKey();

            stopEvent.Signal();
            pcThread.Join();
        }

        static void CodeContractsDemo()
        {
            List<string> list = null;

            //list = new List<string>();

            AddIfMissing(list, "Matt");

            list.ForEach(s => Console.WriteLine(s));
        }

        static bool AddIfMissing<T>(IList<T> list, T item)
        {
            Contract.Requires(list != null);
            Contract.Requires(!list.IsReadOnly);
            Contract.Ensures(list.Contains(item));

            if (list.Contains(item))
            {
                return false;
            }
            else
            {
                list.Add(item);
                return true;
            }
        }
    }
}
