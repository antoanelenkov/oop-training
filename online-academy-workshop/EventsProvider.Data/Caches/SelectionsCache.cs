using EventsProvider.Data.Repository;
using EventsProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsProvider.Data.Caches
{
    public class SelectionsCache : BaseCache<Selection, Guid>
    {
        public SelectionsCache(IRepository<Selection, Guid> repository)
            : base(repository)
        {
        }
    }
}
