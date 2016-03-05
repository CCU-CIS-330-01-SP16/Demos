using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Lecture15Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryStreamDemo();
            //FileStreamDemo();
            //StreamReaderWriterDemo();
            //StreamCompressionDemo();

            //UriDemo();
            //WebClientDemo();
        }

        private static void MemoryStreamDemo()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                Console.WriteLine($"CanRead: {stream.CanRead}");
                Console.WriteLine($"CanWrite: {stream.CanWrite}");
                Console.WriteLine($"CanSeek: {stream.CanSeek}");

                for (int i = 0; i < 10; i++)
                {
                    stream.WriteByte((byte)i);
                }

                // Must move back to the start of the stream to read from it. This is allowed
                // because the stream CanSeek.
                stream.Position = 0;

                int byteValue;
                while ((byteValue = stream.ReadByte()) != -1)
                {
                    Console.WriteLine(byteValue);
                }
            }
        }

        private static void FileStreamDemo()
        {
            using (FileStream stream = new FileStream("file.txt", FileMode.Create))
            {
                Console.WriteLine($"CanRead: {stream.CanRead}");
                Console.WriteLine($"CanWrite: {stream.CanWrite}");
                Console.WriteLine($"CanSeek: {stream.CanSeek}");

                for (int i = 0; i < 10; i++)
                {
                    stream.WriteByte((byte)i);
                }

                // Must move back to the start of the stream to read from it. This is allowed
                // because the stream CanSeek.
                stream.Position = 0;

                int byteValue;
                while ((byteValue = stream.ReadByte()) != -1)
                {
                    Console.WriteLine(byteValue);
                }
            }
        }

        private static void StreamReaderWriterDemo()
        {
            using (FileStream stream = new FileStream("file.txt", FileMode.Create))
            using (StreamWriter writer = new StreamWriter(stream))
            // Or, simpler but less file options: using (StreamWriter writer = new StreamWriter("file.txt", false))
            {
                writer.Write(true);
                writer.Write('b');
                writer.Write(45.23M);
                writer.WriteLine("The cow jumped over the moon");
            }

            using (StreamReader reader = new StreamReader("file.txt"))
            {
                Console.WriteLine(reader.ReadLine());
            }
        }

        private static void StreamCompressionDemo()
        {
            using (FileStream stream = new FileStream("file.bin", FileMode.Create))
            using (GZipStream zipStream = new GZipStream(stream, CompressionMode.Compress))
            using (StreamWriter writer = new StreamWriter(zipStream))
            {
                writer.Write(true);
                writer.Write('b');
                writer.Write(45.23M);

                for (int i = 0; i < 1000; i++)
                {
                    writer.WriteLine("The cow jumped over the moon");
                }
            }

            using (FileStream stream = new FileStream("file.bin", FileMode.Open))
            using (GZipStream zipStream = new GZipStream(stream, CompressionMode.Decompress))
            using (StreamReader reader = new StreamReader(zipStream))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }

        private static void UriDemo()
        {
            Uri link = new Uri("https://msdn.microsoft.com/en-us/library/system.uri(v=vs.110).aspx");
            
            Console.WriteLine($"Scheme: {link.Scheme}");
            Console.WriteLine($"Port: {link.Port}");
            Console.WriteLine($"Host: {link.Host}");
            Console.WriteLine($"Path: {link.PathAndQuery}");
        }

        private static void WebClientDemo()
        {
            string searchUrl = "https://www.google.com/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=c%23%20string%20interpolation";

            using (WebClient client = new WebClient())
            {
                Console.WriteLine(client.DownloadString(searchUrl));
            }

            //using (WebClient client = new WebClient())
            //using (FileStream fileStream = File.Open("search.html", FileMode.Create))
            //{
            //    Stream searchStream = client.OpenRead(searchUrl);
            //    searchStream.CopyTo(fileStream);
            //}
        }
    }
}
