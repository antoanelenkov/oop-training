using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistrationProcess.Data;

namespace RegistrationProcess.Service
{
    public class DanishRegistrationService : RegistrationService<DanishRegistrationData>
    {
        private readonly IEmailService emailService;
        private readonly DanishReportService reportService;

        public DanishRegistrationService(
            ICollection<IRegistrationValidator<DanishRegistrationData>> validators,
            IRepository<DanishRegistrationData> repository,
            IEmailService emailService,
            DanishReportService reportService)
            : base(validators, repository)
        {
            this.emailService = emailService;
            this.reportService = reportService;
        }

        protected override void PostRegister(bool isSuccessful, DanishRegistrationData data)
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
