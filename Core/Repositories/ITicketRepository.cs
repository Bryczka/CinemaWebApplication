using CinemaWebApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Repositories
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetUserTicketsAsync(Guid id);
        Task AddTicketsAsync(IEnumerable<Ticket> ticketsToAdd);
        Task<IEnumerable<Ticket>> GetAllUserTickets(Guid id);
        Task<IEnumerable<Ticket>> GetAllFilmshowTickets(Guid id);
        
    }
}
