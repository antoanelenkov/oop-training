using Registration.Services.Validators;
using System.Collections.Generic;
using System.Linq;

namespace Registration.Services
{
    public class RegistrationStatus
    {
        public RegistrationStatus(IEnumerable<ValidationResult> validations, RegistrationStatusType status)
        {
            this.Status = status;
            this.ErrorMessages = validations.Where(x=>!x.IsValid).Select(x=>x.ErrorMessage);
        }

        public RegistrationStatusType Status { get; private set; }

        public IEnumerable<string> ErrorMessages { get; private set; }
    }
}