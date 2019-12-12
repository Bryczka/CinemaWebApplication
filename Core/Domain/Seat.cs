using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Domain
{
    public class Seat
    {
        public Guid SeatId { get; set; }
        public int SeatNumber { get; set; }
        public int Row { get; set; }
        public Guid HallId { get; set; }
        public Hall Hall { get; set; }
    }

}