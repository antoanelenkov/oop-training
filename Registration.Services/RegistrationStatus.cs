using Registration.Services.Validators;
using System.Collections.Generic;

namespace Registration.Services
{
    public class RegistrationStatus
    {
        public RegistrationStatus(IEnumerable<ValidationResult> validations, RegistrationStatusType status)
        {
            this.Status = status;
            this.Validations = validations;
        }

        public RegistrationStatusType Status { get; private set; }

        public IEnumerable<ValidationResult> Validations { get; private set; }
    }
}