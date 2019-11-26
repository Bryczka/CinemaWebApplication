using CinemaWebApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.DTO
{
    public class HallDTO
    {
            public Guid HallId { get; set; }
            public int SeatsCount { get; set; }
            public ICollection<Filmshow> Filmshows { get; set; }
            public ICollection<Seat> Seats { get; set; }
    }
}
