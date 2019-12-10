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
    public class SeatRepository : Repository<Seat>, ISeatRepository
    {
        private readonly DatabaseContext _context;
        public SeatRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task BookSeatAsync(List<Seat> seats)
        {
            seats.ForEach(x => x.IsOccupied = true);
            _context.Seats.UpdateRange(seats);
            await _context.SaveChangesAsync();
        }

        public async Task UnbookSeatAsync(List<Seat> seats)
        {
            seats.ForEach(x => x.IsOccupied = false);
            _context.Seats.UpdateRange(seats);
            await _context.SaveChangesAsync();
        }
    }
}
