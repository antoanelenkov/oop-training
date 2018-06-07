using RegistrationProcess.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Services.Validators
{
    class NameValidator : IRegistrationValidator
    {
        public ValidationResult Validate(IRegistrationData data)
        {
            var isValid = data.Name?.Length > 3;
            return new ValidationResult()
            {
                IsValid = isValid,
                ErrorMessage = isValid ? string.Empty : "Name is not in valid format"
            };
        }
    }
}
