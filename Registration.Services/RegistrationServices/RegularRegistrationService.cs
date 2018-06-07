using System.Collections.Generic;
using Registration.Services.Contracts;
using Registration.Services.RegistrationData.Contracts;
using Registration.Data;
using Registration.Data.Common;

namespace Registration.Services.RegistrationServices
{
    public class RegularRegistrationService : RegistrationService
    {
        internal RegularRegistrationService(IEnumerable<IRegistrationValidator> validators, 
            IRepository<IRegistrationData> repository) 
            : base(validators, repository)
        {
        }

        public override RegulationType RegulationType => RegulationType.Regular;
    }
}
