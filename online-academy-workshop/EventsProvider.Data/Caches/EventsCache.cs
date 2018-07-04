using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsProvider.Models;
using EventsProvider.Data.Repository;

namespace EventsProvider.Data
{
    public class EventsCache : BaseCache<Event, Guid>
    {
        private const int UpdateIntervalInMilliSeconds = 1000;

        public EventsCache(IRepository<Event, Guid> repository)
            : base(repository)
        {
        }

        protected override int UpdateInterval
        {
            get
            {
                return UpdateIntervalInMilliSeconds;
            }
        }
    }
}
