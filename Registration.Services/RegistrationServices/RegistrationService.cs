using RegistrationProcess.Data;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;

namespace RegistrationProcess.Service
{
    public abstract class RegistrationService<T>  where T : IRegistrationData
    {
        private ICollection<IRegistrationValidator<T>> validators;
        private IRepository<T> repository;

        protected RegistrationService(
            ICollection<IRegistrationValidator<T>> validators,
            IRepository<T> repository)
        {
            this.validators = validators;
            this.repository = repository;
        }

        protected virtual void PreRegister(T data) { }

        protected virtual void PostRegister(bool isSuccessful, T data) { }

        public  RegistrationStatus Register(T data)
        {
            var result = this.Validate(data);

            if (!this.RegistrationDataIsValid(result))
            {
                return new RegistrationStatus();
            }

            PreRegister(data);
            var isSuccessful = this.repository.Save(data);
            PostRegister(isSuccessful, data);

             return new RegistrationStatus();
        }

        private IEnumerable<ValidationResult> Validate(T data)
        {
            return this.validators.Select(x => x.Validate(data));
        }

        private bool RegistrationDataIsValid(IEnumerable<ValidationResult> validationResults)
        {
            return validationResults.All(x => x.IsValid);
        }
    }
}
