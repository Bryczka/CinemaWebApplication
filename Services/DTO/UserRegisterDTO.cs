using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.DTO
{
    public class UserRegisterDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [StringLength(64,MinimumLength = 4, ErrorMessage="Login should be between 4 and 64")]
        public string Login { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "Password should be between 4 and 64")]
        public string Password { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress] 
        public string Email { get; set; }
    }
}
