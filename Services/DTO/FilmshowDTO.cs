using CinemaWebApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.DTO
{
    public class FilmshowDTO
    {
        public Guid FilmshowId { get; set; }
        public DateTime FilmshowTime { get; set; }
        public Guid FilmId { get; set; }
        public string FilmTitle { get; set; }
        public Guid HallId { get; set; }
        public string HallName { get; set; }
    }
}
