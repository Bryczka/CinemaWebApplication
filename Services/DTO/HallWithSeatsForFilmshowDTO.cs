using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.DTO
{
    public class HallWithSeatsForFilmshowDTO
    {
        public Guid HallId { get; set; }
        public string Name { get; set; }
        public int RowsNumber { get; set; }
        public int SeatsInRowNumber { get; set; }
        public ICollection<SeatFilmshowDTO> Seats { get; set; }
        public ICollection<FilmshowDTO> Filmshows { get; set; }
    }
}
