using RegistrationProcess.Data.Common;

namespace RegistrationProcess.Service
{
    public interface IRegistrationData : IIdentifiable
    {
        string Username { get; set; }

        string Password { get; set; }

        string Email { get; set; }

        string Firstname { get; set; }

        string Lastname { get; set; }
    }
}