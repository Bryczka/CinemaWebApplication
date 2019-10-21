using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Model
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int SeatNumber { get; set; }
        public bool IsPaid { get; set; }
        public int ClientId { get; set; }
        public int HallId { get; set; }
    }
}
