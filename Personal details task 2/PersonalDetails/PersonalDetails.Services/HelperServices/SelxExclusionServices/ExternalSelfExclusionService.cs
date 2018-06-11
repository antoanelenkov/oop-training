using PersonalDetails.Services.HelperServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDetails.Services.HelperServices
{
    internal class ExternalSelfExclusionService : ISelfExclusionService
    {
        public bool IsSelfExcluded(string userId)
        {
            return false;
        }

        public void SelfExclude(string userId, int daysPeriod)
        {
            // Self exclusion logic
            Console.WriteLine($"{userId} is self excluded for {daysPeriod}!");
        }
    }
}
