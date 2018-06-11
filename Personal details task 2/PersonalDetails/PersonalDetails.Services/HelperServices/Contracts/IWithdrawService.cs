using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDetails.Services.HelperServices.Contracts
{
    internal interface IWithdrawService
    {
        void Withdraw(string userId, decimal amount);
    }
}
