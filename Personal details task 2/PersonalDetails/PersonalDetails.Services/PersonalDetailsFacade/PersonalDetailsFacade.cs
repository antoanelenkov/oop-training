using PersonalDetails.Services.Enums;
using PersonalDetails.Services.HelperServices;
using PersonalDetails.Services.HelperServices.DepositServices;
using PersonalDetails.Services.HelperServices.WithdrawServices;
using PersonalDetails.Services.Models.Contracts;
using PersonalDetails.Services.PersonalDetailsServices;
using PersonalDetails.Services.Services;
using PersonalDetails.Services.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDetails.Services.PersonalDetailsFacade
{
    public class PersonalDetailsFacade
    {
        private readonly ICollection<PersonalDetailsService> services;

        public PersonalDetailsFacade()
        {
            services = new List<PersonalDetailsService>();
        }


        public void UpdateUserDetails(RegulationType regulation, IUserData data)
        {
            this.GetService(regulation).UpdatePassword(data.Id, data.Password);
        }

        public void Deposit(RegulationType regulation, string userId, decimal amount)
        {
            this.GetService(regulation).Deposit(userId, amount);
        }

        public void Withdraw(RegulationType regulation, string userId, decimal amount)
        {
            this.GetService(regulation).Withdraw(userId, amount);
        }

        public void LimitBetAmount(RegulationType regulation, string userId, decimal amount)
        {
            var service = this.GetService(regulation) as IBettingLimitable;
            if (service != null)
            {
                service.LimitPerDay(userId, amount);
            }
            else
            {
                Console.WriteLine($"Action restricted for this regulation: {regulation.ToString()}");
            }
        }

        public void LimitTime(RegulationType regulation, string userId, int amount)
        {
            var service = this.GetService(regulation) as ITimeLimitable;
            if (service != null)
            {
                service.LimitPerMonth(userId, amount);
            }
            else
            {
                Console.WriteLine($"Action restricted for this regulation ${regulation.ToString()}");
            }
        }

        public void SelfExclude(RegulationType regulation, string userId, int amount)
        {
            var service = this.GetService(regulation) as ISelfExcludable;
            if (service != null)
            {
                service.SelfExclude(userId, amount);
            }
            else
            {
                Console.WriteLine($"Action restricted for this regulation ${regulation.ToString()}");
            }
        }



        private PersonalDetailsService GetService(RegulationType regulation)
        {
            var service = services.FirstOrDefault(x => x.RegulationType == regulation);
            if (service == null)
            {
                service = GetNewService(regulation);
                services.Add(service);
            }

            return service;
        }

        private PersonalDetailsService GetNewService(RegulationType regulation)
        {
            var withdrawService = new WithdrawService();
            var selfExclusionService = new ExternalSelfExclusionService();

            switch (regulation)
            {
                case RegulationType.Regular:
                    return new RegularPersonalDetailsService(
                        new MastercardDepositService(),
                        withdrawService,
                        selfExclusionService);
                case RegulationType.Danish:
                    return new DanishPersonalDetailsService(
                        new PaypalDepositService(),
                        withdrawService,
                        selfExclusionService);
                case RegulationType.Polish:
                    return new PolishPersonalDetailsService(
                        new MastercardDepositService(),
                        new WithdrawService());
                default:
                    throw new NotImplementedException("regulation type is not implemented");
            }
        }
    }
}
