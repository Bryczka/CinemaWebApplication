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
    public class FilmRepository : Repository<Film>, IFilmRepository
    {
        private readonly DatabaseContext _context;
        public FilmRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Film>> GetAllFilmsWithFilmShowsAsync()
        {
            return await _context.Films.ToListAsync();
        }

        public async Task<Film> GetFilmWithFilmShowsAsync(Guid id)
        {
            return await _context.Films.Where(x => x.FilmId.Equals(id)).Include(x => x.Filmshows).FirstOrDefaultAsync();
        }
    }
}
