using CinemaWebApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Repositories
{
    public interface IFilmshowRepository : IRepository<Filmshow>
    {
        Task<IEnumerable<Filmshow>> GetAllFilmshowsOfFilmAsync(Guid id);
        Task<IEnumerable<Filmshow>> GetAllFilmshowsOfFilmDateAsync(Guid id, DateTime dateTime);
    }
}
