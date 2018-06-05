using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationProcess.Service
{
    public class RegistrationData : IRegistrationData
    {
        public string Email { get; set; }

        public string Firstname { get; set; }

        public int Id { get; set; }

        public string Lastname { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }
    }
}
