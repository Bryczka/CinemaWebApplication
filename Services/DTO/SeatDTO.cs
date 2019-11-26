using CinemaWebApplication.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.DTO
{
    public class SeatDTO
    {
        public Guid SeatId { get; set; }
        public int SeatNumber { get; set; }
        public RowNumber Row { get; set; }
        public bool IsOccupied { get; set; }
        public Guid HallId { get; set; }
    }
}
