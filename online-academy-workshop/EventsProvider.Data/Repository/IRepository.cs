using EventsProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsProvider.Data.Repository
{
    public interface IRepository<T, K> where T : IIdentifiable<K>
    {
        IEnumerable<T> Get();
    }
}
