using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistrationProcess.Data;
using RegistrationProcess.Service;

namespace RegistrationProcess.Service
{
    public class PolishRegistrationService : RegistrationService
    {
        public PolishRegistrationService(
            IEnumerable<IRegistrationValidator> validators, 
            IRepository<IRegistrationData> repository) 
            : base(validators, repository)
        {
        }
    }
}
