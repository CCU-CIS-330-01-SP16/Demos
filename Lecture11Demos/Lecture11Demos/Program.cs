using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lecture11Demos
{
    class Program
    {
        private static readonly double BytesPerMB = Math.Pow(1000, 2);

        private static readonly double BytesPerGB = Math.Pow(1000, 3);

        private static Random RandomNumberGenerator = new Random();

        // Family plan includes 5GB of shared data.
        private static double FamilyPlanMaxData = 5 * BytesPerGB;
        
        private static double DataBalance = FamilyPlanMaxData;

        // Family plan limits any one download to 100MB
        private static double MaxDownloadSize = 50 * BytesPerMB;

        private static double TotalDownloaded = 0;

        private static object DataLock = new object();

        static void Main(string[] args)
        {
            ConcurrentWrite();

            //ConcurrentThreadCount(100);

            //FamilyDataPlan();
        }

        static void ConcurrentWrite()
        {
            Stopwatch sw = new Stopwatch();

            Console.WriteLine();

            sw.Start();
            WriteValue("0");
            WriteValue("1");
            WriteValue("2");
            WriteValue("3");
            sw.Stop();

            //sw.Start();
            //Thread t0 = new Thread(() => WriteValue("0")); // { IsBackground = true };
            //Thread t1 = new Thread(() => WriteValue("1")); // { IsBackground = true };
            //Thread t2 = new Thread(() => WriteValue("2")); // { IsBackground = true };
            //Thread t3 = new Thread(() => WriteValue("3")); // { IsBackground = true };
            //t0.Start();
            //t1.Start();
            //t2.Start();
            //t3.Start();
            //t0.Join();
            //t1.Join();
            //t2.Join();
            //t3.Join();
            //sw.Stop();

            //sw.Start();
            //CountdownEvent countdown = new CountdownEvent(4);
            //ThreadPool.QueueUserWorkItem(s => { WriteValue("0"); countdown.Signal(); });
            //ThreadPool.QueueUserWorkItem(s => { WriteValue("1"); countdown.Signal(); });
            //ThreadPool.QueueUserWorkItem(s => { WriteValue("2"); countdown.Signal(); });
            //ThreadPool.QueueUserWorkItem(s => { WriteValue("3"); countdown.Signal(); });
            //countdown.Wait();
            //sw.Stop();

            //sw.Start();
            //Task.WaitAll(
            //    Task.Run(() => WriteValue("0")),
            //    Task.Run(() => WriteValue("1")),
            //    Task.Run(() => WriteValue("2")),
            //    Task.Run(() => WriteValue("3"))
            //    );
            //sw.Stop();

            //var task = Task.Run(() => 5 + 6);
            //Console.WriteLine(task.Result);

            Console.WriteLine("Elapsed Time: {0:n0}ms", sw.ElapsedMilliseconds);
        }

        static void WriteValue(string value, int iterations = 100)
        {
            for(int i = 0; i < iterations; i++)
            {
                // Simulate some work.
                Thread.Sleep(10);

                Console.WriteLine(value);
            }
        }

        static void ConcurrentThreadCount(long count)
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

            //        //Interlocked.Increment(ref actualCount);
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

        static void FamilyDataPlan()
        {
            string[] devices = new string[] 
            {
                "Matt's Phone",
                "Matt's Tablet",
                "Christine's Phone",
                "Christine's Tablet",
                "Ryan's Phone",
                "Ashton's Phone"
            };

            Console.WriteLine("Family Data Plan: {0:n0}GB", DataBalance / BytesPerGB);
            Console.WriteLine("******************************");

            // Simulate some downloads by each device in the family.
            while (DataBalance > 0)
            {
                foreach (string device in devices)
                {
                    if (DataBalance > 0)
                    {
                        double downloadSize = Download(device, MaxDownloadSize);

                        DataBalance -= downloadSize;
                        TotalDownloaded += downloadSize;

                        //Console.WriteLine("DEBUG: Data Balance: {0:n2} MB", DataBalance / BytesPerMB);
                        //Console.WriteLine("DEBUG: Total Downloaded: {0:n2} MB", TotalDownloaded / BytesPerMB);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine("BILLING: Data Balance: {0:n2} MB", DataBalance / BytesPerMB);
            Console.WriteLine("BILLING: Total Downloaded: {0:n2} MB", TotalDownloaded / BytesPerMB);

            if (DataBalance < 0)
            {
                Console.WriteLine("BILLING: Overage charges for {0:n2} MB", Math.Abs(DataBalance) / BytesPerMB);
            }

            double expectedOverage = FamilyPlanMaxData - TotalDownloaded;
            if(Math.Round(DataBalance / BytesPerMB, 2) != Math.Round(expectedOverage / BytesPerMB, 2))
            {
                Console.WriteLine();
                Console.WriteLine("BILLING: Error!! Overage charge should be {0:n2} MB", Math.Abs(expectedOverage) / BytesPerMB);
            }

            Console.WriteLine();
        }

        static double Download(string deviceName, double maxDownloadSize)
        {
            Stopwatch sw = new Stopwatch();

            double downloadSize = RandomNumberGenerator.NextDouble() * maxDownloadSize;

            sw.Start();
            Thread.Sleep((int)(downloadSize / BytesPerMB));
            sw.Stop();

            Console.WriteLine("DEBUG: {0} downloaded {1:n2} MB in {2:n0}ms -- {3:n2} MB/ms!!", deviceName,
                downloadSize / BytesPerMB,
                sw.ElapsedMilliseconds,
                (downloadSize / BytesPerMB) / sw.ElapsedMilliseconds);

            return downloadSize;
        }

        static async Task<double> DownloadAsync(string deviceName, double maxDownloadSize)
        {
            return await Task.Run(() => {
                Stopwatch sw = new Stopwatch();

                double downloadSize = RandomNumberGenerator.NextDouble() * maxDownloadSize;

                sw.Start();
                Task.Delay((int)(downloadSize / BytesPerMB));
                sw.Stop();

                Console.WriteLine("DEBUG: {0} downloaded {1:n2} MB in {2:n0}ms -- {3:n2} MB/ms!!", deviceName,
                    downloadSize / BytesPerMB,
                    sw.ElapsedMilliseconds,
                    (downloadSize / BytesPerMB) / sw.ElapsedMilliseconds);

                return downloadSize;
            });
        }
    }
}
