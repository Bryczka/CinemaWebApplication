using CinemaWebApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.DTO
{
    public class FilmshowDTO
    {
        public Guid FilmshowId { get; set; }

        [Required]
        public DateTime FilmshowTime { get; set; }

        [Required]
        public Guid FilmId { get; set; }
        public string FilmTitle { get; set; }

        [Required]
        public Guid HallId { get; set; }
        public string HallName { get; set; }
    }
}
