namespace PersonalDetails.Services.HelperServices.Contracts
{
    internal interface ISelfExclusionService
    {
        void SelfExclude(string userId, int daysPeriod);

        bool IsSelfExcluded(string userId);
    }
}
