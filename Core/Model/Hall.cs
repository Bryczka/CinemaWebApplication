using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Model
{
    public class Hall
    {
        public int HallId { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public ICollection<Filmshow> Filmshows { get; set; }

    }
}
