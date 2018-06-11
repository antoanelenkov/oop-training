using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopDemo.Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Abstract classes implementation example");
            List<Animal> animals = new List<Animal>() { new Dog(), new Bird(), new Fish() };

            foreach (var animal in animals)
            {
                animal.Move();
            }

            Console.WriteLine("Interface implementation example");
            List<IMovable> animals2 = new List<IMovable>() { new Dog2(), new Bird2(), new Fish2() };

            foreach (var animal in animals2)
            {
                animal.Move();
            }
        }
    }
}
