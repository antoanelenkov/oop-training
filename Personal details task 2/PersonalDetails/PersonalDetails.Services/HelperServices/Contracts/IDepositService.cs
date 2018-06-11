using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalDetails.Services.HelperServices.Contracts
{
    internal interface IDepositService
    {
        void Deposit(string userId, decimal amount);
    }
}
