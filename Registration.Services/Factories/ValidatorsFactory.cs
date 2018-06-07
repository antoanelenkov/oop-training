using Registration.Data.Common;
using Registration.Services.Contracts;
using Registration.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Registration.Services.Factories
{

    // Simple Factory pattern
    internal class ValidatorsFactory
    {
        public IEnumerable<IRegistrationValidator> GetValidators(RegulationType regulationType)
        {
            switch (regulationType)
            {
                case RegulationType.Regular:
                    return GetBaseValidators().Concat(GetRegularValidators());
                case RegulationType.Danish:
                    return GetBaseValidators().Concat(GetDanishValidators());
                case RegulationType.Polish:
                    return GetBaseValidators().Concat(GetPolishValidators());
                default:
                    throw new NotImplementedException("Regulation type is not implemented");
            }
        }

        private IEnumerable<IRegistrationValidator> GetBaseValidators()
        {
            yield return new EmailValidator();
            yield return new PasswordValidator();
        }

        private IEnumerable<IRegistrationValidator> GetDanishValidators()
        {
            yield return new DanishIdentityValidator();
        }

        private IEnumerable<IRegistrationValidator> GetPolishValidators()
        {
            yield return new PolishIdentityValidator();
        }

        private IEnumerable<IRegistrationValidator> GetRegularValidators()
        {
            yield return new NameValidator();
        }
    }
}
