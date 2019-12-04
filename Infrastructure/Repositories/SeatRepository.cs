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

        public async Task BookSeatAsync(Guid id)
        {
            var seat = new Seat();
            seat.SeatId = id;
            seat.IsOccupied = true;
            _context.Seats.Update(seat);
            await _context.SaveChangesAsync();
        }

        //public async Task DeleteSeatByHallAsync(Guid HallId)
        //{
        //    var seats = await _context.Seats.Where(x => x.HallId == HallId).ToListAsync();
        //    _context.Seats.RemoveRange(seats);
        //    await _context.SaveChangesAsync();
        //}

        public async Task UnbookSeatAsync(Guid id)
        {
            var seat = new Seat();
            seat.SeatId = id;
            seat.IsOccupied = false;
            _context.Seats.Update(seat);
            await _context.SaveChangesAsync();
        }
    }
}
