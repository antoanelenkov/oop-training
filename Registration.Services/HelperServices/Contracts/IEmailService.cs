using Registration.Services.RegistrationData.Contracts;

namespace Registration.Services.HelperServices.Contracts
{
    internal interface IEmailService
    {
        void SendMail(IRegistrationData data);
    }
}