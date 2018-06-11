using PersonalDetails.Services.Enums;
using PersonalDetails.Services.Models;
using PersonalDetails.Services.Models.Contracts;
using PersonalDetails.Services.PersonalDetailsFacade;
using System;

namespace PersonalDetails.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose registration flow:" + Environment.NewLine
                + "For regular press '1'" + Environment.NewLine
                + "For danish press '2'" + Environment.NewLine
                + "For polish press '3'" + Environment.NewLine);

            var regulation = (RegulationType)(int.Parse(Console.ReadLine()) - 1);
            var userData = new UserData() { Id = "123456",FirstName="Bai", LastName= "Georgi" };

            Console.WriteLine("Choose action:" + Environment.NewLine
                + "For deposit press '1'" + Environment.NewLine
                + "For withdraw  press '2'" + Environment.NewLine
                + "For self exclusion process press '3'" + Environment.NewLine
                + "For limit bet per day press '4'" + Environment.NewLine
                + "For limit bet per month  press '5'" + Environment.NewLine
                + "For new password press '6'");
            var action = (int.Parse(Console.ReadLine()));

            ProcessAction(action, regulation, userData);
        }

        private static void ProcessAction(int action, RegulationType regulation, IUserData userData)
        {
            PersonalDetailsFacade facade = new PersonalDetailsFacade();

            switch (action)
            {
                case 1:
                    Console.WriteLine("Enter bet amount you want to deposit:");
                    var depositAmount = (decimal.Parse(Console.ReadLine()));
                    facade.Deposit(regulation, userData.Id, depositAmount);
                    break;
                case 2:
                    Console.WriteLine("Enter withdraw amount you want to deposit:");
                    var withdrawAmount = (decimal.Parse(Console.ReadLine()));
                    facade.Withdraw(regulation, userData.Id, withdrawAmount);
                    break;
                case 3:
                    Console.WriteLine("Enter amount of days you want to be self excluded:");
                    var days = (int.Parse(Console.ReadLine()));
                    facade.SelfExclude(regulation, userData.Id, days);
                    break;
                case 4:
                    Console.WriteLine("Enter amount of days you want to be available to bet per month:");
                    var timeLimit = (int.Parse(Console.ReadLine()));
                    facade.LimitTime(regulation, userData.Id, timeLimit);
                    break;
                case 5:
                    Console.WriteLine("Enter betting limit per day:");
                    var betLimit = (decimal.Parse(Console.ReadLine()));
                    facade.LimitBetAmount(regulation, userData.Id, betLimit);
                    break;
                case 6:
                    Console.WriteLine("Enter new password:");
                    var newPass = (int.Parse(Console.ReadLine()));
                    facade.UpdateUserDetails(regulation, userData);
                    break;
                default:
                    Console.WriteLine("Wrong key pressed");
                    break;
            }
        }
    }
}
