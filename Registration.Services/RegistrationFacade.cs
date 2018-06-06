using Newtonsoft.Json;
using RegistrationProcess.Data;
using RegistrationProcess.Service.HelperServices;
using RegistrationProcess.Service.RegistrationServices;
using RegistrationProcess.Service.Validators;
using System;
using System.Collections.Generic;

namespace RegistrationProcess.Service
{
    public class RegistrationFacade
    {
        public RegistrationStatus Register(int regulation, string data)
        {
            if (regulation == (int)RegulationType.Regular)
            {
                var regularRepository = new InMemoryRepository<RegistrationData>();
                var regularValidators = new List<IRegistrationValidator<RegistrationData>>()
                    { new UsernameValidator() };
                var service = new RegularRegistrationService(regularValidators, regularRepository);
                return service.Register(JsonConvert.DeserializeObject<RegistrationData>(data));
            }
            else if (regulation == (int)RegulationType.Danish)
            {
                var repository = new InMemoryRepository<DanishRegistrationData>();
                var validators = new List<IRegistrationValidator<DanishRegistrationData>>()
                    { new UsernameValidator(), new CPRValidator() };
                var emailService = new EmailService();
                var service = new DanishRegistrationService(validators, repository,
                    new EmailService(),
                    new DanishReportService());
                return service.Register(JsonConvert.DeserializeObject<DanishRegistrationData>(data));
            }

            throw new NotImplementedException("regulation type is not implemented");
        }
    }
}
