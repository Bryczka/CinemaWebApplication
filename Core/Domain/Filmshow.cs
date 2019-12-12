using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Domain
{
    public class Filmshow
    {
        public Guid FilmshowId { get; set; }
        public DateTime FilmshowTime { get; set; }
        public Guid FilmId { get; set; }
        public Film Film { get; set; }
        public Guid HallId { get; set; }
        public Hall Hall { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
