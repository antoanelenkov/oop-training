using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationProcess.Service.Validators
{
    public class CPRValidator : IRegistrationValidator<DanishRegistrationData>
    {
        public ValidationResult Validate(DanishRegistrationData data)
        {
            return new ValidationResult()
            {
                IsValid = data.CPR == "notunique" ? false : true,
                Message = "CPR is not uqnique"
            };
        }
    }
}
