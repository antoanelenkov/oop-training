using RegistrationProcess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;

namespace RegistrationProcess.Service
{
    public abstract class RegistrationService
    {
        private IEnumerable<IRegistrationValidator> validators;
        private IRepository<IRegistrationData> repository;



        protected RegistrationService(
            IEnumerable<IRegistrationValidator> validators,
            IRepository<IRegistrationData> repository)
        {
            this.validators = validators;
            this.repository = repository;
        }

        protected virtual void PreRegister(IRegistrationData data) { }

        protected virtual void PostRegister(bool isSuccessful, IRegistrationData data) { }

        public RegistrationStatus Register(IRegistrationData data)
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

        private IEnumerable<ValidationResult> Validate(IRegistrationData data)
        {
            return this.validators.Select(x => x.Validate(data));
        }

        private bool RegistrationDataIsValid(IEnumerable<ValidationResult> validationResults)
        {
            return validationResults.All(x => x.IsValid);
        }
    }
}
