using Registration.Data.Common;
using System.Collections.Generic;
using System.Linq;

namespace Registration.Data
{
    public class InMemoryRepository<T> : IRepository<T>  where T : IIdentifiable, IRegulationType
    {
        private readonly ICollection<T> entities;

        public InMemoryRepository()
        {
            this.entities = new List<T>();
        }

        public bool Save(T entity)
        {
            this.entities.Add(entity);

            // If database is used, stored procedure can returns result if the process is successful 
            return true;
        }

        public T Get(int id)
        {
            return this.entities.FirstOrDefault(x=>x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return new List<T>(this.entities);
        }

        public IEnumerable<T> GetByRegulation(RegulationType type)
        {
            return new List<T>(this.entities.Where(x=>x.RegulationType == type));
        }
    }
}
