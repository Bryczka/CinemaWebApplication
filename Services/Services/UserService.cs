using AutoMapper;
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
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserRegisterDTO> GetRegiserUser(Guid id)
        {
            var user = await _unitOfWork.UserRepository.GetAsync(id);
            return _mapper.Map<UserRegisterDTO>(user);
        }
    }
}
