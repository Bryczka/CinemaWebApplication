using CinemaWebApplication.Services.DTO;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.IServices
{
    public interface IAuthService
    {
        Task<UserRegisterDTO> RegisterAsync(UserRegisterDTO userRegisterDTO);
        Task<TokenDTO> LoginAsync(UserLoginDTO userLoginDTO);
        Task<bool> UserExist(string login);
    }
}
