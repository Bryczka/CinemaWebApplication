using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.DTO
{
    public class TicketForUserDTO
    {
        public Guid TicketId { get; set; }
        public int SeatNumber { get; set; }
        public int RowNumber { get; set; }
        public bool IsPaid { get; set; }
        public Guid UserId { get; set; }
        public Guid FilmshowId { get; set; }
        public string HallName { get; set; }
        public string FilmTitle { get; set; }
        public DateTime FilmshowTime { get; set; }
    }
}
