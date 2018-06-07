﻿using System.Text.RegularExpressions;

namespace RegistrationProcess.Service.Validators
{
    public class DanishIdentityValidator : IRegistrationValidator
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
