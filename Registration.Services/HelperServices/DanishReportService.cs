using Registration.Services.HelperServices;
using Registration.Services.HelperServices.Contracts;
using Registration.Services.RegistrationData.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Registration.Services.HelperServices
{
    internal  class DanishReportService : IReportService
    {
        public void SendReport(IRegistrationData data)
        {
            var sentData = data.IdentityNumber;

            Task.Run(() =>
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        string endPoint = "http://en.dansihService.org/";

                        var content = new FormUrlEncodedContent(new[]{
                        new KeyValuePair<string, string>("cpr", data.IdentityNumber) });
                        client.PostAsync(endPoint, content);
                    }
                }
                catch(Exception ex)
                {
                    //Logger.Log(ex);
                }
            });
        }
    }
}