using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationProcess.Data
{ 
    public interface IRepository<T>
    {
        bool Save(T entity);
    }
}
