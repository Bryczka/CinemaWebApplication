using CinemaWebApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Repositories
{
    public interface IHallRepository : IRepository<Hall>
    {
        Task<Hall> GetHallWithSeatsAsync(Guid id);
        Task<IEnumerable<Hall>> GetAllHallsWithSeatsAsync();
    }
}
