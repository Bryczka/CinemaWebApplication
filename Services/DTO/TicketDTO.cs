using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.DTO
{
    public class TicketDTO
    {
        public Guid TicketId { get; set; }

        [Required(ErrorMessage = "No seat assigned to ticket")]
        public int SeatNumber { get; set; }

        [Required(ErrorMessage = "No seat assigned to ticket")]
        public int RowNumber { get; set; }

        [Required]
        public bool IsPaid { get; set; }

        [Required(ErrorMessage = "No user assigned to ticket")]
        public Guid UserId { get; set; }

        [Required (ErrorMessage = "No filmshow assigned to ticket")]
        public Guid FilmshowId { get; set; }
    }
}
