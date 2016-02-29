using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture12Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            RaceCondition();

            //Deadlock();

            //LazyInitialization();

            //TimerDemo();

            //PLinqDemo();

            //ParallelDemo();
        }

        static void RaceCondition(long count = 100)
        {
            long actualCount = 0;

            for (long i = 0; i < count; i++)
            {
                // Simulate some work before incrementing the count.
                Thread.Sleep(1);

                actualCount++;
            }

            //List<Thread> threads = new List<Thread>();

            //for (long i = 0; i < count; i++)
            //{
            //    Thread thread = new Thread(() =>
            //    {
            //        // Simulate some work before incrementing the count.
            //        Thread.Sleep(1);

            //        actualCount++;
            //    });

            //    thread.Start();

            //    threads.Add(thread);
            //}

            //foreach (var thread in threads)
            //{
            //    thread.Join();
            //}

            Console.WriteLine("Expected Count: {0:n0}", count);
            Console.WriteLine("Actual Count: {0:n0}", actualCount);
        }

        static void Deadlock()
        {
            object lock1 = new object();
            object lock2 = new object();

            new Thread(() =>
            {
                lock(lock1)
                {
                    Console.WriteLine("{0}: Lock 1 acquired", Thread.CurrentThread.ManagedThreadId);

                    Thread.Sleep(1000);

                    // Deadlock will happen here.
                    lock (lock2)
                    {
                        Console.WriteLine("{0}: Lock 2 acquired", Thread.CurrentThread.ManagedThreadId);
                    }; 
                }
            }).Start();

            lock(lock2)
            {
                Console.WriteLine("{0}: Lock 2 acquired", Thread.CurrentThread.ManagedThreadId);

                Thread.Sleep(1000);

                // Deadlock will happen here.
                lock (lock1)
                {
                    Console.WriteLine("{0}: Lock 1 acquired", Thread.CurrentThread.ManagedThreadId);
                }; 
            }
        }

        static void LazyInitialization()
        {
            Lazy<Oven> oven = new Lazy<Oven>(() => new Oven());

            Console.WriteLine(oven.Value.IsPreHeated);
        }

        static void TimerDemo()
        {
            using (Timer t = new Timer(s => Console.WriteLine("Tick"), null, 0, 1000))
            {
                Thread.Sleep(10000);
            }
        }

        static void PLinqDemo()
        {
            var source = Enumerable.Range(100, 2000000000);
            //var source = ParallelEnumerable.Range(100, 2000000000);

            Stopwatch sw = new Stopwatch();

            sw.Start();

            // Result sequence might be out of order.
            //var parallelQuery = from num in source //.AsParallel()
            //                    where num % 10 == 0
            //                    select num;

            // Fluent/Method syntax is also supported
            var parallelQuery = source.AsParallel().Where(n => n % 10 == 0).Select(n => n);
            //var parallelQuery = source.AsParallel().WithDegreeOfParallelism(2).Where(n => n % 10 == 0).Select(n => n);

            var result = parallelQuery.ToArray();

            sw.Stop();

            //foreach (var n in parallelQuery)
            //{
            //    Console.WriteLine(n);
            //}

            Console.WriteLine("Elapsed time: {0:n0}ms", sw.ElapsedMilliseconds);
        }

        static void ParallelDemo()
        {
            var data = new ConcurrentBag<string>();

            Parallel.Invoke(
                () => data.Add(new WebClient().DownloadString("http://www.yahoo.com")),
                () => data.Add(new WebClient().DownloadString("http://www.google.com"))
                );

            Console.WriteLine(data.Count);
        }
    }
}
