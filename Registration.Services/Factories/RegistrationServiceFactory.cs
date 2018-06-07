using Registration.Data;
using Registration.Data.Common;
using Registration.Services.HelperServices;
using Registration.Services.RegistrationData.Contracts;
using Registration.Services.RegistrationServices;
using RegistrationProcess.Service.HelperServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Registration.Services.Factories
{
    // Lazy initialization factory
    public class RegistrationServiceFactory
    {
        private readonly ICollection<RegistrationService> services;
        private readonly IRepository<IRegistrationData> repository;

        public RegistrationServiceFactory(IRepository<IRegistrationData> repository)
        {
            services = new List<RegistrationService>();
            this.repository = repository;
        }

        public RegistrationServiceFactory() : this(new InMemoryRepository<IRegistrationData>()) { }

        public RegistrationService GetService(RegulationType regulation)
        {
            var service = services.FirstOrDefault(x => x.RegulationType == regulation);
            if (service == null)
            {
                service = GetNewService(regulation);
                services.Add(service);
            }

            return service;
        }

        private RegistrationService GetNewService(RegulationType regulation)
        {
            var validators = new ValidatorsFactory().GetValidators(regulation);

            switch (regulation)
            {
                case RegulationType.Regular:
                    return new RegularRegistrationService(validators, repository);
                case RegulationType.Danish:
                    return new DanishRegistrationService(validators, repository,
                        new EmailService(),
                        new DanishReportService());
                case RegulationType.Polish:
                    return new PolishRegistrationService(validators, repository,
                        new PolishReportService());
                default:
                    throw new NotImplementedException("regulation type is not implemented");
            }
        }


    }
}
