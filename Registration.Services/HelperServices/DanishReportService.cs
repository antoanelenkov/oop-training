using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RegistrationProcess.Service
{
    public  class DanishReportService
    {
        public void SendReport(DanishRegistrationData data)
        {
            var sentData = data.CPR;

            Task.Run(() =>
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        string endPoint = "http://en.dansihService.org/";

                        var content = new FormUrlEncodedContent(new[]{
                        new KeyValuePair<string, string>("cpr", data.CPR) });
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