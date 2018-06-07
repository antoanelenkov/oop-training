using Registration.Data.Common;

namespace Registration.Services.RegistrationData.Contracts
{
    public interface IRegistrationData : IIdentifiable, IRegulationType
    {
        string Username { get; set; }

        string Password { get; set; }

        string Email { get; set; }

        string Name { get; set; }

        string IdentityNumber { get; set; }
    }
}