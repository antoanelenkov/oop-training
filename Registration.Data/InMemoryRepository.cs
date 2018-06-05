using RegistrationProcess.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationProcess.Data
{
    public class InMemoryRepository<T> : IRepository<T>  where T : IIdentifiable
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
    }
}
