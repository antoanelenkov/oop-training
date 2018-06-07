using RegistrationProcess.Service;
using System.Text.RegularExpressions;

namespace Registration.Services.Validators
{
    class PolishIDentityValidator
    {
        private const string ValidFormatPattern = "^[a-zA-Z]{5}$";

        public ValidationResult Validate(IRegistrationData data)
        {
            var isValid = Regex.Match(data.IdentityNumber, ValidFormatPattern).Success;
            return new ValidationResult()
            {
                IsValid = isValid,
                ErrorMessage = isValid ? string.Empty : "Identity number is not in valid format"
            };
        }
    }
}
