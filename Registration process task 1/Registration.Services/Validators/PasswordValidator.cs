﻿using Registration.Services.Contracts;
using Registration.Services.RegistrationData.Contracts;

namespace Registration.Services.Validators
{
    internal class PasswordValidator : IRegistrationValidator
    {
        public ValidationResult Validate(IRegistrationData data)
        {
            var isValid = data.Password?.Length >= 6;
            return new ValidationResult()
            {
                IsValid = isValid,
                ErrorMessage = isValid ? string.Empty : "Password should be at least 6 symbols"
            };
        }
    }
}
