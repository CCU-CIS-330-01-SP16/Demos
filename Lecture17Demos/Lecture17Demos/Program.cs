using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Lecture17Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

            // Limiting who can call your code.
            PrincipalPermissionDeclarativeDemo();
            //PrincipalPermissionImperativeDemo();

            // Limiting what your code can do.
            //FileIOPermissionDemo(@"D:\Documents\testfile.txt", "test");
            //FileIOPermissionDemo(@"D:\Pictures\testfile.txt", "test");

            //HashingDemo();

            //ProtectedMemoryDemo();

            //ProtectedDataDemo();

            //ExamPrep();
        }

        [PrincipalPermission(SecurityAction.Demand, Authenticated = true, Name = @"matts1\matt", Role = "Administrators")]
        private static void PrincipalPermissionDeclarativeDemo()
        {
            Console.WriteLine("User has permission to call this method.");
        }

        private static void PrincipalPermissionImperativeDemo()
        {
            PrincipalPermission principalPerm = new PrincipalPermission(@"matts1\matt", "Administrators", true);
            principalPerm.Demand();

            Console.WriteLine("User has permission to call this method.");
        }

        [FileIOPermission(SecurityAction.PermitOnly, Write = @"D:\Documents")]
        //[FileIOPermission(SecurityAction.PermitOnly, Write = @"D:\Pictures")]
        private static void FileIOPermissionDemo(string path, string contents)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(contents);
            }
        }

        private static void HashingDemo()
        {
            // Hash and "save" the password
            string myPassword = "P@ssw0rd!";
            byte[] data = Encoding.UTF8.GetBytes(myPassword);
            byte[] hash = SHA256.Create().ComputeHash(data);
            Console.WriteLine(Encoding.UTF8.GetString(hash));

            // Confirm the user entered the same password.
            byte[] data2 = Encoding.UTF8.GetBytes(myPassword);
            byte[] hash2 = SHA256.Create().ComputeHash(data);
            Console.WriteLine(Encoding.UTF8.GetString(hash2));

            Console.WriteLine(hash.SequenceEqual(hash2));
        }

        private static void ProtectedMemoryDemo()
        {
            byte[] message = Encoding.UTF8.GetBytes("Some very sensitive data here!!!");

            Console.WriteLine("Original data: " + Encoding.UTF8.GetString(message));
            Console.WriteLine("Encrypting...");

            // Encrypt the data in memory.
            ProtectedMemory.Protect(message, MemoryProtectionScope.SameLogon);

            Console.WriteLine("Encrypted data: " + Encoding.UTF8.GetString(message));
            Console.WriteLine("Decrypting...");

            // Decrypt the data in memory.
            ProtectedMemory.Unprotect(message, MemoryProtectionScope.SameLogon);

            Console.WriteLine("Decrypted data: " + Encoding.UTF8.GetString(message));
        }

        private static void ProtectedDataDemo()
        {
            // Create the original data to be encrypted
            byte[] message = Encoding.UTF8.GetBytes("Some very sensitive persistent data here!!!");

            // Create some random entropy.
            byte[] entropy = CreateRandomEntropy();

            Console.WriteLine();
            Console.WriteLine("Original data: " + Encoding.UTF8.GetString(message));
            Console.WriteLine("Encrypting and writing to disk...");

            byte[] encryptedData = ProtectedData.Protect(message, entropy, DataProtectionScope.CurrentUser);

            // Create a file.
            int bytesWritten = 0;
            using (FileStream stream = new FileStream("Data.dat", FileMode.OpenOrCreate))
            {
                stream.Write(encryptedData, 0, encryptedData.Length);
                bytesWritten = encryptedData.Length;
            }

            Console.WriteLine("Reading data from disk and decrypting...");

            // Open the file.
            using (FileStream stream = new FileStream("Data.dat", FileMode.Open))
            {
                // Read from the stream and decrypt the data.
                byte[] inBuffer = new byte[bytesWritten];

                stream.Read(inBuffer, 0, bytesWritten);
                byte[] decryptData = ProtectedData.Unprotect(inBuffer, entropy, DataProtectionScope.CurrentUser);

                Console.WriteLine("Decrypted data: " + Encoding.UTF8.GetString(decryptData));
            }
        }

        public static byte[] CreateRandomEntropy()
        {
            // Create a byte array to hold the random value.
            byte[] entropy = new byte[16];

            // Create a new instance of the RNGCryptoServiceProvider.
            // Fill the array with a random value.
            new RNGCryptoServiceProvider().GetBytes(entropy);

            // Return the array.
            return entropy;
        }

        interface IFile
        {
            void Open();
        }

        interface IDatabase
        {
            void Open();
        }

        private class UseResources : IFile, IDatabase
        {
            void IDatabase.Open()
            {
                Console.WriteLine("Database opened.");
            }

            void IFile.Open()
            {
                Console.WriteLine("File opened.");
            }
        }

        public static void ExamPrep()
        {
            var manager = new UseResources();
            ((IFile)manager).Open();
            ((IDatabase)manager).Open();
        }
    }
}
