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

        public async Task<IEnumerable<Filmshow>> GetAllWithHallAndFilm()
        {
            return await _context.Filmshows.Include(x => x.Hall).Include(x => x.Film).ToListAsync();

        }

        public async Task<IEnumerable<Filmshow>> GetAllFilmshowsOfFilmAsync(Guid id)
        {
            return await _context.Filmshows.Where(x => x.Film.FilmId == id).ToListAsync();

        }

        public async Task<IEnumerable<Filmshow>> GetAllFilmshowsOfFilmDateAsync(Guid id, DateTime dateTime)
        {
            return await _context.Filmshows.Where(x => x.Film.FilmId == id).Where(x => x.FilmshowTime.Date == dateTime.Date).ToListAsync();
        }

        public async Task<Filmshow> GetFilmshowWithTicketsAsync(Guid id)
        {
            return await _context.Filmshows.Where(x => x.FilmshowId == id).Include(x => x.Tickets).FirstOrDefaultAsync();
        }
    }
}
