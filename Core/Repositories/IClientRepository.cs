using CinemaWebApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<Client> GetByEmail(string email);
        Task<Client> GetByLogin(string login);
    }
}
