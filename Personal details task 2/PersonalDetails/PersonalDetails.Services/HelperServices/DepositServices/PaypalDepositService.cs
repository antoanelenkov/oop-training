using PersonalDetails.Services.HelperServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDetails.Services.HelperServices.DepositServices
{
    class PaypalDepositService : IDepositService
    {
        public void Deposit(string userId, decimal amount)
        {
            Console.WriteLine($"User with id {userId} deposited {amount} using paypal");
        }
    }
}
