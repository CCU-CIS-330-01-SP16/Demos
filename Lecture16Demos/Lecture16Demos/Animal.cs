using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16Demos
{
    public abstract class Animal
    {
        public Animal()
        {
        }

        public string Name { get; set; }

        public int NumberOfLegs { get; set; }

        public virtual void Move() { }
    }
}
