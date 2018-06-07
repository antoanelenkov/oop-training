using Registration.Services.RegistrationData.Contracts;
using Registration.Services.Validators;

namespace Registration.Services.Contracts
{
    public interface IRegistrationValidator
    {
        ValidationResult Validate(IRegistrationData data);
    }
}