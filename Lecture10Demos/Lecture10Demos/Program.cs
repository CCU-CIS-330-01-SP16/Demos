using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture10Demos
{
    class Program
    {
        private const int MaxClients = 1000;
        private const int MaxContactsToAdd = 10;

        static void Main(string[] args)
        {
            StartContactManagerWebApplication(new ContactRepository());
        }

        private static void StartContactManagerWebApplication(ContactRepository repository)
        {
            ConsoleKeyInfo? keyInfo = null;

            do
            {
                // Simulate clients connecting to the web application and managing contacts.
                for (int i = 0; i < MaxClients; i++)
                {
                    ManageContacts(repository);
                }

                // Display the memory used after forcing garbage collection.
                Console.WriteLine("Memory Used: {0:n0} bytes", GC.GetTotalMemory(true));

                Console.Write("Process more clients? [y|n] (y): ");
                keyInfo = Console.ReadKey();
                Console.WriteLine();
            }
            while (keyInfo.HasValue && keyInfo.Value.Key == ConsoleKey.Y || keyInfo.Value.Key == ConsoleKey.Enter);
        }

        private static void ManageContacts(ContactRepository repository)
        {
            // Create a new contact manager.
            ContactManager manager = new ContactManager(repository);

            // Add some new contacts to the repository.
            for (int i = 0; i < MaxContactsToAdd; i++)
            {
                manager.Add(new Contact { Name = "Contact " + i });
            }
        }
    }
}
