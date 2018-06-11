using PersonalDetails.Services.Enums;
using PersonalDetails.Services.HelperServices.Contracts;
using PersonalDetails.Services.Models.Contracts;
using PersonalDetails.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDetails.Services.Services
{
    internal abstract class PersonalDetailsService : IWithdrawable, IDepositable
    {
        protected readonly IWithdrawService withdrawService;

        protected PersonalDetailsService(IWithdrawService withdrawService)
        {
            this.withdrawService = withdrawService;
        }

        public void UpdatePassword(string userId, string newPass)
        {
            // Save data to db
            Console.WriteLine($"User with id {userId} has updated his password!");
        }

        public virtual void Withdraw(string userId, decimal amount)
        {
            this.withdrawService.Withdraw(userId, amount);
        }

        public abstract RegulationType RegulationType { get; }

        public abstract void Deposit(string userId, decimal amount);
    }
}
