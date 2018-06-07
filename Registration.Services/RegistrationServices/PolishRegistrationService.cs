using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistrationProcess.Data;
using RegistrationProcess.Service;
using Registration.Services.HelperServices;

namespace RegistrationProcess.Service
{
    public class PolishRegistrationService : RegistrationService
    {
        private readonly IReportService reportService;

        public PolishRegistrationService(
            IEnumerable<IRegistrationValidator> validators, 
            IRepository<IRegistrationData> repository,
            IReportService reportService) 
            : base(validators, repository)
        {
            this.reportService = reportService;
        }

        public override RegulationType RegulationType => RegulationType.Polish;

        protected override void PreRegister(IRegistrationData data)
        {
            this.reportService.SendReport(data);
        }
    }
}
