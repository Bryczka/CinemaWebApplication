using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Domain
{
    public abstract class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        public User(Guid id, string name, string surname, string login, string password, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
            Email = email;
        }
    }
}
