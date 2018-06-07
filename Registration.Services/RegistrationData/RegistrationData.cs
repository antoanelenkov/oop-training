using Registration.Data.Common;
using Registration.Services.RegistrationData.Contracts;

namespace Registration.Services.RegistrationData
{
    public class RegistrationData : IRegistrationData
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string IdentityNumber { get; set; }

        public RegulationType RegulationType { get; set; }
    }
}
