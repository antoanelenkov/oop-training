using RegistrationProcess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationProcess
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Choose registration flow:");
            Console.WriteLine("For regular registration press 1");
            Console.WriteLine("For danish registration press 2");
            Console.WriteLine("For polish registration press 3");
            var currentRegistration = Console.ReadLine();

            new RegistrationFacade().Register(int.Parse(currentRegistration), "");
        }
    }
}
