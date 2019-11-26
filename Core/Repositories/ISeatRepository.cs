using CinemaWebApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Repositories
{
    public interface ISeatRepository : IRepository<Seat>
    {
        Task BookSeatAsync(Guid id);
        Task UnbookSeatAsync(Guid id);
    }
}
