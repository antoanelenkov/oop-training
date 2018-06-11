using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDetails.Services.Services.Contracts
{
    interface IWithdrawable
    {
        void Withdraw(string userId, decimal amount);
    }
}
