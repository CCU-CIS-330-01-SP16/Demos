using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture18Demos
{
    abstract class BaseLogger
    {
        public virtual void Log(string message)
        {
            Console.WriteLine("Base: " + message);
        }
        public void LogCompleted()
        {
            Console.WriteLine("Completed");
        }
    }
}
