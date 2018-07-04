using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsProvider.Models
{
    public class Selection : IIdentifiable<Guid>, IEquatable<Selection>
    {
        public Selection()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { private set; get; }

        public Guid MarketId { get; set; }

        public Guid EventId { get; set; }

        public string Name { get; set; }

        public double Odds { get; set; }

        public bool IsSuspended { get; set; }

        public bool Equals(Selection other)
        {
            if (this.Id != other.Id
               || this.Name != other.Name
               || this.EventId != other.EventId
               || this.IsSuspended != other.IsSuspended
               || this.MarketId != other.MarketId
               || this.Odds != other.Odds)
            {
                return false;
            }

            return true;
        }
    }
}
