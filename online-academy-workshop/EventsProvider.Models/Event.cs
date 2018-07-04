using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsProvider.Models
{
    public class Event : IIdentifiable<Guid> , IEquatable<Event>
    {
        public Event()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { private set; get; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string SportName { get; set; }

        public string LeagueName { get; set; }

        public GameStatus Status
        {
            get
            {
                var deltaInMinutes = (DateTime.Now - StartDate).TotalMinutes;

                if (deltaInMinutes  >= 0 && deltaInMinutes <= 90)
                {
                    return GameStatus.Live;
                }
                else if(deltaInMinutes > 90)
                {
                    return GameStatus.Finished;
                }
                else
                {
                    return GameStatus.PreMatch;
                }
            }
        }

        public bool Equals(Event other)
        {
            if(this.StartDate != other.StartDate 
                || this.Status != other.Status
                || this.Id != other.Id
                || this.LeagueName != other.LeagueName
                || this.Name != other.Name
                || this.SportName != other.SportName)
            {
                return false;
            }

            return true;
        }
    }
}
