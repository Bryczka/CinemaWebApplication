using CinemaWebApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.DTO
{
    public class HallWithSeatsDTO
    {
        [Required]
        public Guid HallId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int RowsNumber { get; set; }

        [Required]
        public int SeatsInRowNumber { get; set; }

        public ICollection<SeatDTO> Seats { get; set; }
        public ICollection<FilmshowDTO> Filmshows { get; set; }
    }
}
