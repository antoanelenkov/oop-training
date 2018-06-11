namespace PersonalDetails.Services.HelperServices.Contracts
{
    internal interface IWithdrawService
    {
        void Withdraw(string userId, decimal amount);
    }
}
