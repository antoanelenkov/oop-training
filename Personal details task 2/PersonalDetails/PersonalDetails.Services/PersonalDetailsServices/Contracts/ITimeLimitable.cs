using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDetails.Services.Services.Contracts
{
    interface ITimeLimitable
    {
        void LimitPerMonth(string userId, int daysPerMonth);
    }
}
