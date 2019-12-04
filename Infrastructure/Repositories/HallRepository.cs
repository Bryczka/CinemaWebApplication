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
    public class HallRepository : Repository<Hall>, IHallRepository
    {
        private readonly DatabaseContext _context;
        public HallRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hall>> GetAllHallsWithSeatsAsync()
        {
            return await _context.Halls.Include(x => x.Seats).ToListAsync();
        }

        public async Task<Hall> GetHallWithSeatsAsync(Guid id)
        {
            return await _context.Halls.Where(x => x.HallId.Equals(id)).Include(x => x.Seats).FirstOrDefaultAsync();
        }
    }
}
