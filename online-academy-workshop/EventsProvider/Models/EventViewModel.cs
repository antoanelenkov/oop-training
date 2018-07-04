using EventsProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsService.Models
{
    public class EventViewModel
    {
        public EventViewModel(Event ev,IEnumerable<MarketViewModel> markets)
        {
            this.Id = ev.Id;
            this.Name = ev.Name;
            this.StartDate = ev.StartDate;
            this.SportName = ev.SportName;
            this.LeagueName = ev.LeagueName;
            this.Markets = markets;
            this.Status = ev.Status;
        }

        public Guid Id { private set; get; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string SportName { get; set; }

        public string LeagueName { get; set; }

        public GameStatus Status { get; set; }

        public IEnumerable<MarketViewModel> Markets { get; set; }
    }
}