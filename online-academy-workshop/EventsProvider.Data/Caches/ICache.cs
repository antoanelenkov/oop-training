using EventsProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsProvider.Data
{
    public interface ICache<T, K> where T : IIdentifiable<K>
    {
        T this[K index] { get; }

        IEnumerable<T> All();
    }
}
