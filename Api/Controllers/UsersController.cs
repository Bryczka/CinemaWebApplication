using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CinemaWebApplication.Services.DTO;
using CinemaWebApplication.Services.IServices;
using CinemaWebApplication.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CinemaWebApplication.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private IAuthService _authService;
        private IUserService _userService;
        private readonly IConfiguration _config;
        public UsersController(IAuthService authService, IUserService userService, IConfiguration config)
        {
            _authService = authService;
            _userService = userService;
            _config = config;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody]UserRegisterDTO userRegisterDTO)
        {
            if (await _authService.UserExist(userRegisterDTO.Login))
            {
                return BadRequest("Username already exists");
            }

            await _authService.RegisterAsync(userRegisterDTO);

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody]UserLoginDTO userLoginDTO)
        {
            var token = await _authService.LoginAsync(userLoginDTO);
            if (token == null) { return Unauthorized();}
            return Ok(token);
        }
    }
}