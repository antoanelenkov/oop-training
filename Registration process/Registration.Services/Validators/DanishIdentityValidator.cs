using Registration.Services.Contracts;
using Registration.Services.RegistrationData.Contracts;
using System.Text.RegularExpressions;

namespace Registration.Services.Validators
{
    internal class DanishIdentityValidator : IRegistrationValidator
    {
        private const string ValidFormatPattern = "^[0-9]{9}$";

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
