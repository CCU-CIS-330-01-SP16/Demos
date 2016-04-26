using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week16ExamPrep
{
    class AnimalTracker
    {
        List<Animal> animals = new List<Animal>();

        public void AddAnimal(string name, AddAnimalCallback callback)
        {
            animals.Add(new Animal { Name = name });
            callback(animals.Count);
        }
    }
}
