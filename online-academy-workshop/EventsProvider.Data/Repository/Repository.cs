using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventsProvider.Models;
using EventsProvider.Data.Utils;

namespace EventsProvider.Data.Repository
{
    public class Repository : IRepository<Event, Guid>, IRepository<Market, Guid>, IRepository<Selection, Guid>
    {
        private readonly IEnumerable<Event> events;
        private readonly IEnumerable<Market> markets;
        private readonly IEnumerable<Selection> selections;

        public Repository()
        {
            this.events = this.InitEvents();
            this.markets = this.InitMarkets(this.events.Select(x => x.Id));
            this.selections = this.InitSelections(this.markets);
        }

        IEnumerable<Event> IRepository<Event, Guid>.Get()
        {
            this.UpdateRandomEvents();
            return events;
        }

        IEnumerable<Market> IRepository<Market, Guid>.Get()
        {
            return markets;
        }

        IEnumerable<Selection> IRepository<Selection, Guid>.Get()
        {
            this.UpdateRandomSelections();
            return selections;
        }

        private IEnumerable<Market> InitMarkets(IEnumerable<Guid> eventIds)
        {
            var markets = new List<Market>();
            foreach (var eventId in eventIds)
            {
                for (int i = 0; i < 3; i++)
                {
                    markets.Add(this.GenerateMarket(eventId));
                }
            }

            return markets;
        }

        private IEnumerable<Selection> InitSelections(IEnumerable<Market> market)
        {
            var selections = new List<Selection>();
            foreach (var currentMarket in markets)
            {
                for (int i = 0; i < 5; i++)
                {
                    selections.Add(this.GenerateSelection(currentMarket));
                }
            }

            return selections;
        }

        private IEnumerable<Event> InitEvents()
        {
            var events = new List<Event>();
            for (int i = 0; i < 10; i++)
            {
                events.Add(this.GenerateEvent());
            }
            return events;
        }
      
        private void UpdateRandomEvents()
        {
            for (int i = 0; i < events.Count() / 3; i++)
            {
                var randomElement = RandomGenerator.GetRandomElement(events.ToList());
                randomElement.StartDate = RandomGenerator.GetDate();
            }
        }

        private void UpdateRandomSelections()
        {
            for (int i = 0; i < selections.Count() / 2; i++)
            {
                var randomElement = RandomGenerator.GetRandomElement(selections.ToList());
                randomElement.IsSuspended = RandomGenerator.GetBooleanStatus();
                randomElement.Odds = RandomGenerator.GetDouble();
            }
        }

        private Event GenerateEvent()
        {
            return new Event()
            {
                LeagueName = RandomGenerator.GetLeagueName(),
                SportName = RandomGenerator.GetSportName(),
                Name = RandomGenerator.GetEventName(),
                StartDate = RandomGenerator.GetDate(),
            };
        }

        private Market GenerateMarket(Guid eventId)
        {
            return new Market()
            {
                EventId = eventId,
                Name = RandomGenerator.GetMarketName()
            };
        }

        private Selection GenerateSelection(Market market)
        {
            return new Selection()
            {
                EventId = market.EventId,
                MarketId = market.Id,
                IsSuspended = RandomGenerator.GetBooleanStatus(),
                Odds = RandomGenerator.GetDouble(),
                Name = RandomGenerator.GetSelectionName()
            };
        }
    }
}
