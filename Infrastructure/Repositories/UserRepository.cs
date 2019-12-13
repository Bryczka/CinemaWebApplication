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
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly DatabaseContext _context;
        public UserRepository(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByLogin(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<bool> IsLoginNameExist(string login)
        {
            var users = await _context.Users.ToListAsync();
            return users.Exists(x => x.Login.Equals(login));
                
        }

        public async Task<bool> IsEmailNameExist(string email)
        {
            var users = await _context.Users.ToListAsync();
            return users.Exists(x => x.Email.Equals(email));
        }
    }
}
