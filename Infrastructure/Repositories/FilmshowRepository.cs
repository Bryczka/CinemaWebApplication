using CinemaWebApplication.Core.Database;
using CinemaWebApplication.Core.Domain;
using CinemaWebApplication.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Infrastructure.Repositories
{
    public class FilmshowRepository : Repository<Filmshow>, IFilmshowRepository
    {
        private readonly DatabaseContext _context;
        public FilmshowRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Filmshow>> GetFilmFilmshowsAsync(int id)
        {
            return await _context.Filmshows.Where(x => x.FilmId.Equals(id)).ToListAsync();
        }

        public async Task<IEnumerable<Filmshow>> GetFilmFilmshowsWithDateAsync(int id, DateTime date)
        {
            return await _context.Filmshows.Where(x => x.FilmId.Equals(id) && x.FilmshowTime.Day == date.Day &&
            x.FilmshowTime.Month == date.Month && x.FilmshowTime.Year == date.Year).ToListAsync();
        }
    }
}
