using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsProvider.Models
{
    public class Market : IIdentifiable<Guid>, IEquatable<Market>
    {
        public Market()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { private set; get; }

        public Guid EventId {  set; get; }

        public string Name {  set; get; }

        public bool Equals(Market other)
        {
            if (this.Id != other.Id
                || this.Name != other.Name
                || this.EventId != other.EventId)
            {
                return false;
            }

            return true;
        }
    }
}
