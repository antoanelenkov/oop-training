using Registration.Data.Common;
using System.Collections.Generic;

namespace Registration.Data
{
    public interface IRepository<T>
    {
        bool Save(T entity);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetByRegulation(RegulationType type);
    }
}
