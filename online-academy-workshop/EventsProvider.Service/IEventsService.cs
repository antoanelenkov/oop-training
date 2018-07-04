using EventsProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsProvider.Service
{
    public interface IEventsService
    {
        Task<IEnumerable<Event>> GetEvents();

        Task<Event> GetEventById(Guid id);

        Task<Market> GetMarketById(Guid id);

        Task<IEnumerable<Market>> GetMarkets();

        Task<IEnumerable<Market>> GetMarketsByEventId(Guid id);

        Task<Selection> GetSelectionById(Guid id);

        Task<IEnumerable<Selection>> GetSelections();

        Task<IEnumerable<Selection>> GetSelectionsByMarketId(Guid id);

        Task<IEnumerable<Selection>> GetSelectionsByEventId(Guid id);
    }
}
