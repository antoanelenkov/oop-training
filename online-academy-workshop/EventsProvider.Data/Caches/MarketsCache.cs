using EventsProvider.Data.Repository;
using EventsProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsProvider.Data.Caches
{
    public class MarketsCache : BaseCache<Market, Guid>
    {
        public MarketsCache(IRepository<Market,Guid> repository)
            :base(repository)
        {
        }
    }
}
