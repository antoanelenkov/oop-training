using Newtonsoft.Json;
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
            var currentRegistration = int.Parse(Console.ReadLine());

            IRegistrationData regularData = GetRegularData();
            RegistrationStatus registrationResult;

            switch ((RegulationType)currentRegistration)
            {
                case RegulationType.Danish:
                    var dansihData = GetDanishData(regularData);
                    registrationResult = new RegistrationFacade()
                        .Register(currentRegistration, JsonConvert.SerializeObject(dansihData));
                    break;
                case RegulationType.Polish:
                    var polishData = GetPolishData(regularData);
                    registrationResult = new RegistrationFacade()
                        .Register(currentRegistration, JsonConvert.SerializeObject(polishData));
                    break;
                default:
                    registrationResult = new RegistrationFacade()
                        .Register(currentRegistration, JsonConvert.SerializeObject(regularData));
                    break;
            }

            ProcessRegistrationStatus(registrationResult);
        }


        private static IRegistrationData GetRegularData()
        {
            Console.WriteLine("Enter username");
            var username = Console.ReadLine();

            Console.WriteLine("Enter password");
            var password = Console.ReadLine();

            Console.WriteLine("Enter email");
            var email = Console.ReadLine();

            return new RegistrationData()
            {
                Username = username,
                Password = password,
                Email = email
            };
        }

        private static DanishRegistrationData GetDanishData(IRegistrationData regularData)
        {
            Console.WriteLine("Enter CPR");
            var cpr = Console.ReadLine();

            return new DanishRegistrationData()
            {
                Username = regularData.Username,
                Email = regularData.Email,
                Password = regularData.Password,
                CPR = cpr
            };
        }

        private static PolishRegistrationData GetPolishData(IRegistrationData regularData)
        {
            Console.WriteLine("Enter PESEL");
            var pesel = Console.ReadLine();

            return new PolishRegistrationData()
            {
                Username = regularData.Username,
                Email = regularData.Email,
                Password = regularData.Password,
                PESEL = pesel
            };
        }

        private static void ProcessRegistrationStatus(RegistrationStatus status)
        {
            if(status.Status == RegistrationStatusType.Invalid)
            {
                Console.WriteLine("Your registration is not successful!");
                foreach (var validation in status.Validations.Where(x=>!x.IsValid))
                {
                    Console.WriteLine(validation.Message);
                }
            }
            else if(status.Status == RegistrationStatusType.Successful)
            {
                Console.WriteLine("Your registration is successful!");
            }
            else if (status.Status == RegistrationStatusType.ServerError)
            {
                Console.WriteLine("There is server error! Please try again later...");
            }
            else
            {
                throw new NotImplementedException("RegistrationStatusType is not implemented");
            }
        }
    }
}
