using RegistrationProcess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistrationProcess.Data;

namespace RegistrationProcess.Service.RegistrationServices
{
    public class RegularRegistrationService : RegistrationService
    {
        public RegularRegistrationService(IEnumerable<IRegistrationValidator> validators, 
            IRepository<IRegistrationData> repository) 
            : base(validators, repository)
        {
        }
    }
}
