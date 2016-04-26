using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Week15ExamPrep
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataContractSerializationDemo();

            //Question1();
            // Question2(-23);
            // Question3();
            // Question4();
             Question5();
            // Question6();
            // Question7();
            // Question8();
        }

        private static void DataContractSerializationDemo()
        {
            List<Human> humans = new List<Human>();

            var Brian = new Human
            {
                Name = "Brian Bell",
                HairColor = "Mahogany",
                Occupation = "Chick-fil-a Certified Trainer",
                MaritalStatus = MaritalStatus.ItsComplicated,
                Weight = 453
            };

            var Hannah = new Human
            {
                Name = "Hannah Bell",
                HairColor = "Dirty Dishwasher Blonde - All Natural",
                Occupation = "Student",
                MaritalStatus = MaritalStatus.Single,
                Weight = 237,
                Sibling = Brian
            };

            Brian.Sibling = Hannah;

            humans.Add(Brian);
            humans.Add(Hannah);

            try
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(List<Human>));
                using (XmlWriter writer = XmlWriter.Create("humans.txt"))
                {
                    serializer.WriteObject(writer, humans);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Human));
            //using (FileStream stream = File.Create("human.txt"))
            //{
            //    serializer.WriteObject(stream, Brian);
            //}
        }

        private static void Question1()
        {
            ArrayList list = new ArrayList();
            int item1 = 10;
            int item2 = 0;

            list.Add(item1);

            // Compile time error:
            //item2 = list[0];

            // What is the right way to assign the first item in the list to item2?

            // item2 = ((List<int>)list)[0];
            // item2 = list[0].Equals(typeof(int));
            item2 = Convert.ToInt32(list[0]);
            // item2 = ((int[])list)[0];

            Console.WriteLine(item2);
        }

        private static void Question2(decimal amount)
        {
            // Ensure debugger breaks in all builds if amount <= 0.

            Trace.Assert(amount > 0, "Amount should be greater than zero");
            // Debug.Assert(amount > 0, "Amount should be greater than zero");
            // Debug.Write(amount > 0);
            // Trace.Write(amount > 0);
        }

        private static void Question3()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer { FirstName = "Matt", LastName = "Anderson", Gender = "Male", TotalPurchases = 25237.15m },
                new Customer { FirstName = "Christine", LastName = "Anderson", Gender = "Female", TotalPurchases = 17023.92m },
                new Customer { FirstName = "Ashton", LastName = "Anderson", Gender = "Female", TotalPurchases = 123.47m },
                new Customer { FirstName = "Ryan", LastName = "Anderson", Gender = "Male", TotalPurchases = 92.15m }
            };

            IEnumerable<Customer> sortedCustomers = null;

            // How do I sort by Gender then by TotalPurchases from hightest to lowest?
            // This is an example of delegate usage.

            sortedCustomers = customers.OrderBy(c => c.Gender).ThenByDescending(c => c.TotalPurchases);
            // sortedCustomers = customers.OrderByDescending(c => c.TotalPurchases).ThenBy(c => c.Gender);
            // sortedCustomers = customers.SortBy(c => c.Gender).ThenByDescending(c => c.TotalPurchases);
            // sortedCustomers = customers.SortByDescending(c => c.TotalPurchases).ThenBy(c => c.Gender);
            // sortedCustomers = customers.Sort(CustomCustomerComparer);

            foreach (Customer customer in sortedCustomers)
            {
                Console.WriteLine($"{customer.FirstName} {customer.LastName}, {customer.Gender}, {customer.TotalPurchases}");
            }
        }

        private static void Question4()
        {
            // How do I obtain information about the current assembly?

            Assembly currentAssembly = null;

            // currentAssembly = Assembly.GetAssembly();
            // currentAssembly = Assembly.Current.GetType();
            // currentAssembly = Assembly.Load();
            //currentAssembly = Assembly.GetExecutingAssembly();

            Console.WriteLine(currentAssembly?.FullName);
        }

        private static void Question5()
        {
            // You need to protect highly sensitive data. Which type of encryption is the strongest option?

            // System.Security.Cryptography.DES
            // System.Security.Cryptography.Aes
            // System.Security.Cryptography.TripleDES
            // System.Security.Cryptography.RC2
        }

        private static void Question6()
        {
            // You need to serialize and deserialize objects to and from JSON. The classes for the objects are from a third party
            // library and do not have any serialization attributes. Which built-in JSON will require the least amount of coding?

            // DataContractSerializer
            // DataContractJsonSerializer
            // JavaScriptSerializer
            // Json.NET
        }

        private static void Question7()
        {
            decimal[] amounts = new decimal[] { 54m, 19m, 17m, 24m, 22m };

            // Complete the query to get:
            //   Amounts divisible by 2
            //   Sorted lowest to highest
            //IEnumerable<decimal> desiredAmounts =
            //    XXXX amount in amounts
            //    YYYY amount % 2 == 0
            //    ZZZZ amount AAAA
            //    BBBB amount;

            //foreach(decimal amount in desiredAmounts)
            //{
            //    Console.WriteLine(amount);
            //}
        }

        private static void Question8()
        {
            string fileName = "myfile.txt";

            // Which code best matches these requirements:
            //   Read data from a file
            //   Do not allow changes to the file
            //   Allow other processes to access the file while you are reading it
            //   Do not throw an exception if the file does not exist

            // var fs = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite);
            // var fs = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            // var fs = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Write);
            // var fs = File.ReadAllBytes(fileName);

            // fs.Close();
        }
    }
}
