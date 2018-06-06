using RegistrationProcess.Service;

namespace Registration.Services.HelperServices
{
    public interface IReportService
    {
        void SendReport(IRegistrationData data);
    }
}
