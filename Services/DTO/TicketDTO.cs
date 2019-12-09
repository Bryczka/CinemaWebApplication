using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.DTO
{
    public class TicketDTO
    {
        public Guid TicketId { get; set; }
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
        public bool IsPaid { get; set; }
        public Guid ClientId { get; set; }
        public Guid FilmshowId { get; set; }
    }
}
