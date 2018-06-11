namespace PersonalDetails.Services.HelperServices.Contracts
{
    internal interface IDepositService
    {
        void Deposit(string userId, decimal amount);
    }
}
