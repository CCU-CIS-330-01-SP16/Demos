using System;
using System.Collections.Generic;
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
            Console.WriteLine();

            WriteValue("0");
            WriteValue("1");

            //Thread tx = new Thread(() => WriteValue("0")); // { IsBackground = true };
            //Thread ty = new Thread(() => WriteValue("1")); // { IsBackground = true };
            //tx.Start();
            //ty.Start();
            //tx.Join();
            //ty.Join();

            Console.WriteLine();
        }

        static void WriteValue(string value, int iterations = 100)
        {
            for(int i = 0; i < iterations; i++)
            {
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

            while (DataBalance > 0)
            {
                foreach (string device in devices)
                {
                    if (DataBalance > 0)
                    {
                        double downloadSize = Download(device, MaxDownloadSize);

                        DataBalance -= downloadSize;
                        TotalDownloaded += downloadSize;

                        //Console.WriteLine("DEBUG: Current Data Balance: {0:n2}MB", DataBalance / BytesPerMB);
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
            double downloadSize = RandomNumberGenerator.NextDouble() * maxDownloadSize;

            Thread.Sleep((int)(downloadSize / BytesPerMB));

            Console.WriteLine("DEBUG: {0} downloaded {1:n2} MB", deviceName, downloadSize / BytesPerMB);

            return downloadSize;
        }
    }
}
