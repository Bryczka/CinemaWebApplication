using CinemaWebApplication.Core.Domain;
using CinemaWebApplication.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.IServices
{
    public interface IFilmService
    {
        Task AddAsync(FilmDTO filmDTO);
        Task Update(FilmDTO filmDTO);
        Task DeleteAsync(Guid id);
        Task<FilmDTO> GetFilmWithFilmShowsAsync(Guid id);
        Task<IEnumerable<FilmDTO>> GetAllFilmsWithFilmShowsAsync();
    }
}