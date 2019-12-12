using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.DTO
{
    public class UserLoginDTO
    {
        public Guid UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
