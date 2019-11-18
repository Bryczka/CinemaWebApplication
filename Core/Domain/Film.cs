using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Domain
{
    public class Film
    {
        public Guid FilmId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Length { get; set; }
        public int Rating { get; set; }
        public ICollection<Filmshow> Filmshows { get; set; }
    }
}
