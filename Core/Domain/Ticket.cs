using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Domain
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
        public bool IsPaid { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid FilmshowId { get; set; }
        public Filmshow Filmshow { get; set; }
    }
}
