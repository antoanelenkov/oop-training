using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistrationProcess.Data;
using RegistrationProcess.Service;
using Registration.Services.HelperServices;

namespace RegistrationProcess.Service
{
    public class DanishRegistrationService : RegistrationService
    {
        private readonly IEmailService emailService;
        private readonly IReportService reportService;

        public DanishRegistrationService(
            IEnumerable<IRegistrationValidator> validators,
            IRepository<IRegistrationData> repository,
            IEmailService emailService,
            IReportService reportService)
            : base(validators, repository)
        {
            this.emailService = emailService;
            this.reportService = reportService;
        }

        public override RegulationType RegulationType => RegulationType.Danish;

        protected override void PostRegister(bool isSuccessful, IRegistrationData data)
        {
            if (isSuccessful)
            {
                this.emailService.SendMail(data);
            }
            else
            {
                this.reportService.SendReport(data);
            }
        }
    }
}
