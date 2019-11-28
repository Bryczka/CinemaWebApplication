using CinemaWebApplication.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.IServices
{
    public interface IUserService
    {
        Task<UserRegisterDTO> GetRegiserUser(Guid id);
    }
}
