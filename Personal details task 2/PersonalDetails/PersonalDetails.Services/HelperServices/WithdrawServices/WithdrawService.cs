using PersonalDetails.Services.HelperServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDetails.Services.HelperServices.WithdrawServices
{
    public class WithdrawService : IWithdrawService
    {
        public void Withdraw(string userId, decimal amount)
        {
            Console.WriteLine($"User with id {userId} have withdrawn {amount} from its account!");
        }
    }
}
