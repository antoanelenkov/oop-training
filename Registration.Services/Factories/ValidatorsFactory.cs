using Registration.Services.Validators;
using RegistrationProcess.Service;
using RegistrationProcess.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Services.Factories
{
    public class ValidatorsFactory
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
            return Enumerable.Empty<IRegistrationValidator>();
        }

        private IEnumerable<IRegistrationValidator> GetRegularValidators()
        {
            return Enumerable.Empty<IRegistrationValidator>();
        }
    }
}
