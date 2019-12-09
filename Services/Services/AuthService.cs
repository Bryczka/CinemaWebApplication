using CinemaWebApplication.Core;
using CinemaWebApplication.Core.Domain;
using CinemaWebApplication.Services.DTO;
using CinemaWebApplication.Services.IServices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        public AuthService(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _config = config;
        }
        public async Task<TokenDTO> LoginAsync(UserLoginDTO userLoginDTO)
        {
            var user = await _unitOfWork.UserRepository.GetUserByLogin(userLoginDTO.Login);

            if (user == null) { return null; }

            if (!VerifyPasswordHash(userLoginDTO.Password, user.PasswordHash, user.PasswordSalt)) { return null; }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("appSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(
                new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddHours(12),
                    SigningCredentials = creds
                });

            return new TokenDTO()
            {
                Token = tokenHandler.WriteToken(token)
            };

        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) { return false; }
                }
            }
            return true;
        }

        public async Task<UserRegisterDTO> RegisterAsync(UserRegisterDTO userRegisterDTO)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            CreatePasswordHash(userRegisterDTO.Password, out passwordHash, out passwordSalt);

            var user = new User
            {
                Id = new Guid(),
                Login = userRegisterDTO.Login,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Email = userRegisterDTO.Email,
                Name = userRegisterDTO.Name,
                Surname = userRegisterDTO.Surname,
                PhoneNumber = userRegisterDTO.PhoneNumber,
                Role = "user"
            };

            await _unitOfWork.UserRepository.AddAsync(user);

            return userRegisterDTO;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExist(string login)
        {
            if (await _unitOfWork.UserRepository.GetUserByLogin(login) != null) { return true; }
            return false;
        }
    }
}
