using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsProvider.Models;
using EventsProvider.Data;
using EventsProvider.Data.Caches;

namespace EventsProvider.Service
{
    public class EventsService : IEventsService
    {
        private static Lazy<EventsService> instance;

        private ICache<Event, Guid> events;
        private ICache<Market, Guid> markets;
        private ICache<Selection, Guid> selections;


        private EventsService(ICache<Event, Guid> events, ICache<Market, Guid> markets, ICache<Selection, Guid> selections)
        {
            this.events = events;
            this.markets = markets;
            this.selections = selections;
        }

        public async Task<Event> GetEventById(Guid id)
        {
            return await Task.Run(() => this.events[id]).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Event>> GetEvents()
        {
            return await Task.Run(() => new List<Event>(this.events.All()))
                .ConfigureAwait(false);
        }

        public async Task<Market> GetMarketById(Guid id)
        {
            return await Task.Run(() => this.markets[id]).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Market>> GetMarkets()
        {
            return await Task.Run(() => new List<Market>(this.markets.All()))
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Market>> GetMarketsByEventId(Guid id)
        {
            return await Task.Run(() => this.markets.All().Where(x => x.EventId == id))
                .ConfigureAwait(false);
        }

        public async Task<Selection> GetSelectionById(Guid id)
        {
            return await Task.Run(() => this.selections[id])
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Selection>> GetSelections()
        {
            return await Task.Run(() => new List<Selection>(this.selections.All()))
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Selection>> GetSelectionsByEventId(Guid id)
        {
            return await Task.Run(() => new List<Selection>(this.selections.All().Where(x => x.EventId == id)))
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Selection>> GetSelectionsByMarketId(Guid id)
        {
            return await Task.Run(() => new List<Selection>(this.selections.All().Where(x => x.MarketId == id)))
                .ConfigureAwait(false);
        }

        public static void Create(EventsCache events, MarketsCache markets, SelectionsCache selections)
        {
            if (instance != null)
            {
                throw new Exception("Object already created");
            }

            instance = new Lazy<EventsService>(() => new EventsService(events,markets,selections));
        }

        public static IEventsService Instance
        {
            get
            {
                return instance.Value;
            }
        }
    }
}
