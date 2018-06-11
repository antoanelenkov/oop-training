using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalDetails.Services.Enums;
using PersonalDetails.Services.HelperServices.Contracts;
using PersonalDetails.Services.Services.Contracts;

namespace PersonalDetails.Services.Services
{
    internal class RegularPersonalDetailsService : PersonalDetailsService, ISelfExcludable
    {
        private readonly IDepositService depositService;
        private readonly IWithdrawService withdrawService;
        private readonly ISelfExclusionService selfExclusionService;

        internal RegularPersonalDetailsService(
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
                return RegulationType.Regular;
            }
        }

        public override void Deposit(string userId, decimal amount)
        {
            this.depositService.Deposit(userId, amount);
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
