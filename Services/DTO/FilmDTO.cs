using CinemaWebApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.DTO
{
    public class FilmDTO
    {
        public Guid FilmId { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Length { get; set; }
        public int Rating { get; set; }
        public string ImageBase64 { get; set; }
        public ICollection<Filmshow> Filmshows { get; set; }
    }
}
