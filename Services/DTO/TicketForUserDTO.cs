using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.DTO
{
    public class TicketForUserDTO
    {
        [Required]
        public Guid TicketId { get; set; }

        [Required]
        public int SeatNumber { get; set; }

        [Required]
        public int RowNumber { get; set; }

        [Required]
        public bool IsPaid { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid FilmshowId { get; set; }

        [Required]
        public string HallName { get; set; }

        [Required]
        public string FilmTitle { get; set; }

        [Required]
        public DateTime FilmshowTime { get; set; }

    }
}
