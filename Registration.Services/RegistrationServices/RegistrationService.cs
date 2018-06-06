using RegistrationProcess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;

namespace RegistrationProcess.Service
{
    public abstract class RegistrationService<T> where T : IRegistrationData
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

        public RegistrationStatus Register(T data)
        {
            IEnumerable<ValidationResult> validations = Enumerable.Empty<ValidationResult>();

            try
            {
                validations = this.Validate(data);

                if (!this.RegistrationDataIsValid(validations))
                {
                    return new RegistrationStatus(validations, RegistrationStatusType.Invalid);
                }

                PreRegister(data);
                var isSuccessful = this.repository.Save(data);
                PostRegister(isSuccessful, data);
            }
            catch (Exception ex)
            {
                //Logging exception
                return new RegistrationStatus(validations, RegistrationStatusType.ServerError);
            }

            return new RegistrationStatus(validations, RegistrationStatusType.Successful);
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
