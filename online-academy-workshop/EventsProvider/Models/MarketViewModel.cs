using EventsProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsService.Models
{
    public class MarketViewModel
    {
        public MarketViewModel(Market market, IEnumerable<SelectionViewModel> selections)
        {
            this.Id = market.Id;
            this.Name = market.Name;
            this.Selections = selections;
        }

        public Guid Id { private set; get; }

        public string Name { set; get; }


        public IEnumerable<SelectionViewModel> Selections { get; set; }
    }
}