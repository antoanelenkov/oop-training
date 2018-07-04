using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsProvider.Models
{
    public interface IIdentifiable<K>
    {
        K Id { get; }
    }
}
