using PersonalDetails.Services.Enums;
using PersonalDetails.Services.HelperServices.Contracts;
using PersonalDetails.Services.Services;
using PersonalDetails.Services.Services.Contracts;
using System;

namespace PersonalDetails.Services.PersonalDetailsServices
{
    internal class DanishPersonalDetailsService : PersonalDetailsService, ITimeLimitable, ISelfExcludable
    {
        private readonly IDepositService depositService;
        private readonly IWithdrawService withdrawService;
        private readonly ISelfExclusionService selfExclusionService;

        internal DanishPersonalDetailsService(
            IDepositService depositService,
            IWithdrawService withdrawService,
            ISelfExclusionService selfExclusionService) : base()
        {
            this.depositService = depositService;
            this.withdrawService = withdrawService;
            this.selfExclusionService = selfExclusionService;
        }

        public override RegulationType RegulationType
        {
            get
            {
                return RegulationType.Danish;
            }
        }

        public override void Deposit(string userId, decimal amount)
        {
            if (this.selfExclusionService.IsSelfExcluded(userId))
            {
                Console.WriteLine($"User {userId} is not allowed to deposit, because is self excluded");
                return;
            }

            this.depositService.Deposit(userId, amount);

        }

        public void LimitPerMonth(string userId, int amount)
        {
            Console.WriteLine($"User with  {userId} has time limit: {amount} days in a month");
        }

        public void SelfExclude(string userId, int daysPeriod)
        {
            this.selfExclusionService.SelfExclude(userId, daysPeriod);
        }

        public override void Withdraw(string userId, decimal amount)
        {
            this.withdrawService.Withdraw(userId, amount);
        }
    }
}
