using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructorExecutionOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            var contact = new Person("Frank");
        }
    }
}
