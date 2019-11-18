using CinemaWebApplication.Core.Database;
using CinemaWebApplication.Core.Domain;
using CinemaWebApplication.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly DatabaseContext _context;
        public ClientRepository(DatabaseContext context) : base(context) 
        {
            _context = context;
        }

        public async Task<Client> GetByEmail(string email)
        {
            return await Task.FromResult(_context.Clients.SingleOrDefault(x => x.Email.Equals(email)));
        }

        public async Task<Client> GetByLogin(string login)
        {
            return await Task.FromResult(_context.Clients.SingleOrDefault(x => x.Login.Equals(login)));
        }
    }
}
