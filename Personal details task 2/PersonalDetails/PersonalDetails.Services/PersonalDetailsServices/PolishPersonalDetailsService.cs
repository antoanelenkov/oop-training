using PersonalDetails.Services.Enums;
using PersonalDetails.Services.HelperServices.Contracts;
using PersonalDetails.Services.Services;
using PersonalDetails.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDetails.Services.PersonalDetailsServices
{
    internal class PolishPersonalDetailsService : PersonalDetailsService, IBettingLimitable
    {
        private readonly IDepositService depositService;

        internal PolishPersonalDetailsService(
            IDepositService depositService,
            IWithdrawService withdrawService) : base(withdrawService)
        {
            this.depositService = depositService;
        }

        public override RegulationType RegulationType
        {
            get
            {
                return RegulationType.Polish;
            }
        }

        public override void Deposit(string userId, decimal amount)
        {
            this.depositService.Deposit(userId, amount);
        }

        public void LimitPerDay(string userId, decimal amount)
        {
            Console.WriteLine($"User with  {userId} has betting limit: {amount} per day");
        }
    }
}
