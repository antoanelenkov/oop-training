using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegistrationProcess.Service.Validators
{
    public class EmailValidator : IRegistrationValidator
    {
        private const string ValidFormatPattern = "^\\S+@\\S+\\.\\S+$";

        public ValidationResult Validate(IRegistrationData data)
        {
            var isValid = Validate(data.Email);
            return new ValidationResult()
            {
                IsValid = isValid,
                ErrorMessage = isValid ? string.Empty : "Email is not in valid format"
            };
        }

        private bool Validate(string identity)
        {
            return Regex.Match(identity, ValidFormatPattern).Success;
        }
    }
}
