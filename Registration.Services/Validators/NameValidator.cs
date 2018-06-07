using Registration.Services.Contracts;
using Registration.Services.RegistrationData.Contracts;

namespace Registration.Services.Validators
{
    internal class NameValidator : IRegistrationValidator
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
