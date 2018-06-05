using RegistrationProcess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistrationProcess.Data;

namespace RegistrationProcess.Service.RegistrationServices
{
    public class RegularRegistrationService : RegistrationService<RegistrationData>
    {
        public RegularRegistrationService(ICollection<IRegistrationValidator<RegistrationData>> validators, 
            IRepository<RegistrationData> repository) 
            : base(validators, repository)
        {
        }
    }
}
