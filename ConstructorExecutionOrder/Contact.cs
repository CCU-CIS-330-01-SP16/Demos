using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorExecutionOrder
{
    class Contact
    {
        static Contact()
        {
            Console.WriteLine("Static Contact");
        }

        public Contact()
        {
            Console.WriteLine("Contact");
        }
    }
}
