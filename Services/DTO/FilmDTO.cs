using CinemaWebApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.DTO
{
    public class FilmDTO
    {
        public Guid FilmId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public int Length { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ImageBase64 { get; set; }
        public ICollection<FilmshowDTO> Filmshows { get; set; }
    }
}
