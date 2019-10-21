using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Model
{
    public class Filmshow
    {
        public int FilmshowId { get; set; }
        public DateTime FilmshowTime { get; set; }
        public int FilmId { get; set; }
        public int HallId { get; set; }

    }
}
