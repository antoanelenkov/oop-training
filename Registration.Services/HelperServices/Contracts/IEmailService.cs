namespace RegistrationProcess.Service
{
    public interface IEmailService
    {
        void SendMail(IRegistrationData data);
    }
}