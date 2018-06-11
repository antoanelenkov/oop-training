using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopDemo.Polymorphism
{
    public abstract class Animal
    {
        public abstract void Move();
    }

    public  class Dog : Animal
    {
        public override void Move()
        {
            Console.WriteLine("Dog is walking");
        }
    }

    public class Fish : Animal
    {
        public override void Move()
        {
            Console.WriteLine("Fish is swimming");
        }
    }

    public class Bird : Animal
    {
        public override void Move()
        {
            Console.WriteLine("Bird is flying");
        }
    }
}
