using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CinemaWebApplication.Services.DTO;
using CinemaWebApplication.Services.IServices;
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
        private readonly IConfiguration _config;
        public UsersController(IAuthService authService, IConfiguration config)
        {
            _authService = authService;
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
            return Ok(token);
        }
    }
}