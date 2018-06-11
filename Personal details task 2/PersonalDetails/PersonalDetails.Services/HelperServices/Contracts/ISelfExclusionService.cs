using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDetails.Services.HelperServices.Contracts
{
    internal interface ISelfExclusionService
    {
        void SelfExclude(string userId, int daysPeriod);

        bool IsSelfExcluded(string userId);
    }
}
