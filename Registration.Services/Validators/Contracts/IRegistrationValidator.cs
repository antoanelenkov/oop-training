namespace RegistrationProcess.Service
{
    public interface IRegistrationValidator
    {
        ValidationResult Validate(IRegistrationData data);
    }
}