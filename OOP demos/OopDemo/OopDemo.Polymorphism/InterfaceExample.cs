using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopDemo.Polymorphism
{
    public interface IMovable
    {
        void Move();
    }

    public class Dog2 : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Dog2 is walking");
        }
    }

    public class Fish2 : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Fish2 is swimming");
        }
    }

    public class Bird2 : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Bird2 is flying");
        }
    }
}
