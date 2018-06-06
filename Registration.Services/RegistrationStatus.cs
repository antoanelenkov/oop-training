using System.Collections.Generic;

namespace RegistrationProcess.Service
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