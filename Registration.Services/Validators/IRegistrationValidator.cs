namespace RegistrationProcess.Service
{
    public interface IRegistrationValidator<in T> where T : IRegistrationData
    {
        ValidationResult Validate(T data);
    }
}