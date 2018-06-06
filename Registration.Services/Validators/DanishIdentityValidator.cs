using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegistrationProcess.Service.Validators
{
    public class DanishIdentityValidator : IRegistrationValidator
    {
        private const string ValidFormatPattern = "^[0-9]{9}$";

        public ValidationResult Validate(IRegistrationData data)
        {
            var isValid = Validate(data.IdentityNumber);
            return new ValidationResult()
            {
                IsValid = isValid,
                ErrorMessage = isValid ? string.Empty : "Identity number is not in valid format"
            };
        }

        private bool Validate(string identity)
        {
            return Regex.Match(identity, ValidFormatPattern).Success;
        }
    }
}
