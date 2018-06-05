using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationProcess.Data.Common
{
    public interface IIdentifiable
    {
        int Id { get; set; }
    }
}
