using System.Collections.Generic;
using Registration.Data.Common;
using Registration.Services.HelperServices.Contracts;
using Registration.Services.RegistrationData.Contracts;
using Registration.Services.Contracts;
using Registration.Data;

namespace Registration.Services.RegistrationServices
{
    public class DanishRegistrationService : RegistrationService
    {
        private readonly IEmailService emailService;
        private readonly IReportService reportService;

        internal DanishRegistrationService(
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
