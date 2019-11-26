using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Domain
{
    public class Hall
    {
        public Guid HallId { get; set; }
        public int SeatsCount { get; set; }
        public ICollection<Filmshow> Filmshows { get; set; }
        public ICollection<Seat> Seats { get; set; }

    }
}
