using Registration.Services.Contracts;
using Registration.Services.RegistrationData.Contracts;
using System.Text.RegularExpressions;

namespace Registration.Services.Validators
{
    internal class EmailValidator : IRegistrationValidator
    {
        private const string ValidFormatPattern = "^\\S+@\\S+\\.\\S+$";

        public ValidationResult Validate(IRegistrationData data)
        {
            var isValid = Regex.Match(data.Email, ValidFormatPattern).Success;
            return new ValidationResult()
            {
                IsValid = isValid,
                ErrorMessage = isValid ? string.Empty : "Email is not in valid format"
            };
        }
    }
}
