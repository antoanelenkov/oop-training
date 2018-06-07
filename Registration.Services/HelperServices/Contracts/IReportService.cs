using Registration.Services.RegistrationData.Contracts;
using RegistrationProcess.Service;

namespace Registration.Services.HelperServices.Contracts
{
    internal interface IReportService
    {
        void SendReport(IRegistrationData data);
    }
}
