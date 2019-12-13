using CinemaWebApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserByLogin(string login);
        Task<bool> IsLoginNameExist(string login);
        Task<bool> IsEmailNameExist(string email);
    }
}
