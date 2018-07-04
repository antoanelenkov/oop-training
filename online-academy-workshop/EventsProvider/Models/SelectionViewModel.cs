using EventsProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsService.Models
{
    public class SelectionViewModel
    {
        public SelectionViewModel(Selection selection)
        {
            this.Id = selection.Id;
            this.Name = selection.Name;
            this.Odds = selection.Odds;
            this.IsSuspended = selection.IsSuspended;
        }

        public Guid Id { private set; get; }

        public string Name { get; set; }

        public double Odds { get; set; }

        public bool IsSuspended { get; set; }
    }
}