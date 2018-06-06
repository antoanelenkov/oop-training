using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationProcess.Service.Validators
{
    public class UsernameValidator : IRegistrationValidator<IRegistrationData>
    {
        public ValidationResult Validate(IRegistrationData data)
        {
            // Check if username is unique
            return new ValidationResult()
            {
                IsValid = data.Username == "notunique" ? false : true,
                Message = "Username is not uqnique"
            };
        }
    }
}
