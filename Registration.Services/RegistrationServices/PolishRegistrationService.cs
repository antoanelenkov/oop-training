using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistrationProcess.Data;
using RegistrationProcess.Service;

namespace RegistrationProcess.Service
{
    public class PolishRegistrationService : RegistrationService<PolishRegistrationData>
    {
        protected PolishRegistrationService(
            ICollection<IRegistrationValidator<PolishRegistrationData>> validators, 
            IRepository<PolishRegistrationData> repository) 
            : base(validators, repository)
        {
        }
    }
}
