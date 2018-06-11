using Registration.Data.Common;
using Registration.Services;
using Registration.Services.Factories;
using Registration.Services.RegistrationData;
using Registration.Services.RegistrationData.Contracts;
using Registration.Services.RegistrationServices;
using System;
using System.Linq;

namespace Registration.Client
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Choose registration flow:" + Environment.NewLine
            + "For regular press '1', for danish  press '2', for polish press '3'");
            var regulationType = (RegulationType)(int.Parse(Console.ReadLine()) - 1);

            RegistrationService service = new RegistrationServiceFactory().GetService(regulationType);
            ProcessRegistrationStatus(service.Register(GetRegistrationData(regulationType)));
        }


        private static IRegistrationData GetRegistrationData(RegulationType regulationType)
        {
            Console.WriteLine("Enter username");
            var username = Console.ReadLine();

            Console.WriteLine("Enter password");
            var password = Console.ReadLine();

            Console.WriteLine("Enter email");
            var email = Console.ReadLine();

            var regularData = new RegistrationData()
            {
                Username = username,
                Password = password,
                Email = email
            };

            switch (regulationType)
            {
                case RegulationType.Regular:
                    return regularData;
                case RegulationType.Danish:
                    return GetDanishData(regularData);
                case RegulationType.Polish:
                    return GetPolishData(regularData);
                default:
                    throw new NotImplementedException("Not implemented regulation type");
            }

        }

        private static IRegistrationData GetDanishData(IRegistrationData regularData)
        {
            Console.WriteLine("Enter Identity Number");
            var identity = Console.ReadLine();

            return new RegistrationData()
            {
                Username = regularData.Username,
                Email = regularData.Email,
                Password = regularData.Password,
                IdentityNumber = identity
            };
        }

        private static IRegistrationData GetPolishData(IRegistrationData regularData)
        {
            return GetDanishData(regularData);
        }

        private static void ProcessRegistrationStatus(RegistrationResult result)
        {
            switch (result.Status)
            {
                case RegistrationStatusType.Invalid:
                    Console.WriteLine("Your registration is not successful!");
                    foreach (var message in result.ErrorMessages)
                    {
                        Console.WriteLine(message);
                    }
                    break;
                case RegistrationStatusType.Successful:
                    Console.WriteLine("Your registration is successful!");
                    break;
                case RegistrationStatusType.ServerError:
                    Console.WriteLine("There is server error! Please try again later...");
                    break;
                default:
                    throw new NotImplementedException("RegistrationStatusType is not implemented");
            }
        }
    }
}
