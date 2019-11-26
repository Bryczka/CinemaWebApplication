using CinemaWebApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Repositories
{
    public interface IFilmRepository : IRepository<Film>
    {
        Task<Film> GetFilmWithFilmShowsAsync(Guid id);
        Task<IEnumerable<Film>> GetAllFilmsWithFilmShowsAsync();
    }
}
