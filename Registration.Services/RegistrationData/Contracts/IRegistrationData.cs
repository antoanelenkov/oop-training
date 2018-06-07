using RegistrationProcess.Data.Common;

namespace RegistrationProcess.Service
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