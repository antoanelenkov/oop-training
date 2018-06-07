using Registration.Data;
using Registration.Data.Common;
using Registration.Services.Contracts;
using Registration.Services.RegistrationData.Contracts;
using Registration.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Registration.Services.RegistrationServices
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

        internal abstract RegulationType RegulationType { get; }

        public RegistrationResult Register(IRegistrationData data)
        {
            try
            {
                this.ProcessData(data);
                var validations = this.Validate(data);

                if (!this.RegistrationDataIsValid(validations))
                {
                    return new RegistrationResult(validations, RegistrationStatusType.Invalid);
                }

                PreRegister(data);
                var isSuccessful = this.repository.Save(data);
                PostRegister(isSuccessful, data);
            }
            catch (Exception ex)
            {
                //Logging exception
                return new RegistrationResult(Enumerable.Empty<ValidationResult>(), RegistrationStatusType.ServerError);
            }

            return new RegistrationResult(Enumerable.Empty<ValidationResult>(), RegistrationStatusType.Successful);
        }

        protected virtual void PreRegister(IRegistrationData data){  }

        protected virtual void PostRegister(bool isSuccessful, IRegistrationData data) { }

        private void ProcessData(IRegistrationData data)
        {
            data.RegulationType = this.RegulationType;
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
