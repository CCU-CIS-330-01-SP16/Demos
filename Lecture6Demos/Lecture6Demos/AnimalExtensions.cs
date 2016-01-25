using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture6Demos
{
    public static class AnimalExtensions
    {
        public static TimeSpan? LifeSpan(this Animal animal)
        {
            if (animal != null && animal.BirthDate.HasValue)
            {
                return DateTime.Now - animal.BirthDate.Value;
            }

            return null;
        }
    }
}
