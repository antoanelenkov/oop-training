using Newtonsoft.Json;
using Registration.Services.Factories;
using Registration.Services.HelperServices;
using RegistrationProcess.Data;
using RegistrationProcess.Service.HelperServices;
using RegistrationProcess.Service.RegistrationServices;
using System;

namespace RegistrationProcess.Service
{
    public class RegistrationServiceFactory
    {
        public RegistrationService GetService(RegulationType regulation)
        {
            var repository = new InMemoryRepository<IRegistrationData>();
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
