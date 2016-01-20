using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPPillars
{
    public abstract class Animal
    {
        private int numberOfLegs;

        public int NumberOfLegs
        {
            get
            {
                return numberOfLegs;
            }
            set
            {
                if(value >= 8)
                {
                    throw new ArgumentException("Number of legs must be less than or equal to 8.");
                }
                numberOfLegs = value;
            }
        }

        public abstract void Speak();
        
    }
}
