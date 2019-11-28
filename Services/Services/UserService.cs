using CinemaWebApplication.Core;
using CinemaWebApplication.Services.DTO;
using CinemaWebApplication.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserRegisterDTO> GetRegiserUser(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(id);
            return Mappers.MapUserToRegisterDTO(user);
        }
    }
}
