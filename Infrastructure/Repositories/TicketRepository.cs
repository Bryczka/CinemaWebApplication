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
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        private readonly DatabaseContext _context;
        public TicketRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddTicketsAsync(IEnumerable<Ticket> ticketsToAdd)
        {
            await _context.AddRangeAsync(ticketsToAdd);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetUserTicketsAsync(Guid id)
        {
            return await _context.Tickets.Where(x => x.ClientId.Equals(id)).ToListAsync();
        }
    }
}
