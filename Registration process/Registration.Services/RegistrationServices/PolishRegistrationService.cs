using Registration.Data;
using Registration.Data.Common;
using Registration.Services.Contracts;
using Registration.Services.HelperServices.Contracts;
using Registration.Services.RegistrationData.Contracts;
using System.Collections.Generic;

namespace Registration.Services.RegistrationServices
{
    public class PolishRegistrationService : RegistrationService
    {
        private readonly IReportService reportService;

        internal PolishRegistrationService(
            IEnumerable<IRegistrationValidator> validators, 
            IRepository<IRegistrationData> repository,
            IReportService reportService) 
            : base(validators, repository)
        {
            this.reportService = reportService;
        }

        internal override RegulationType RegulationType => RegulationType.Polish;

        protected override void PreRegister(IRegistrationData data)
        {
            this.reportService.SendReport(data);
        }
    }
}
