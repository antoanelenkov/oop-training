using EventsService.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EventsService.Controllers
{
    public class EventsController : Controller
    {
        public  async Task<string> GetAllEvents()
        {
            return JArray
                .FromObject(await EventsProvider.Service.EventsService.Instance.GetEvents())
                .ToString();
        }

        public async Task<string> GetEvent(Guid id)
        {
            return JObject
                .FromObject(await EventsProvider.Service.EventsService.Instance.GetEventById(id))
                .ToString();
        }

        public async Task<string> GetFullEvents()
        {
            var fullEvents = new List<EventViewModel>();
            var events = await EventsProvider.Service.EventsService.Instance.GetEvents();

            foreach (var ev in events)
            {
                var marketsByEventId = await EventsProvider.Service.EventsService.Instance.GetMarketsByEventId(ev.Id);
                var markets = marketsByEventId
                    .Select(async (market) => new MarketViewModel(market,
                        (await EventsProvider.Service.EventsService.Instance.GetSelectionsByMarketId(market.Id).ConfigureAwait(false))
                            .Select(sel => new SelectionViewModel(sel))
                )).Select(x=>x.Result);

                fullEvents.Add(new EventViewModel(ev, markets));
            }

            return JArray.FromObject(fullEvents).ToString();
        }

        public async Task<string> GetFullEvent(Guid id)
        {
            var ev = await EventsProvider.Service.EventsService.Instance.GetEventById(id);
            var marketsById = await EventsProvider.Service.EventsService.Instance.GetMarketsByEventId(ev.Id);

            var fullMarkets = marketsById.Select(async market => new MarketViewModel(market,
                        (await EventsProvider.Service.EventsService.Instance.GetSelectionsByMarketId(market.Id).ConfigureAwait(false))
                        .Select(sel => new SelectionViewModel(sel))
                )).Select(x=>x.Result);

            return JObject.FromObject(new EventViewModel(ev, fullMarkets)).ToString();
        }
    }
}