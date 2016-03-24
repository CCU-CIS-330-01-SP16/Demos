using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture18Demos
{
    class Logger : BaseLogger
    {
        public override void Log(string message)
        {
            Console.WriteLine(message);
        }
        public new void LogCompleted()
        {
            Console.WriteLine("Finished");
        }
    }
}
