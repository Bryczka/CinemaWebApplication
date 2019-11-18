using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Domain
{
    public class Client : User
    {

        public Client()
        {

        }

        public Client(Guid id, string name, string surname, string login, string password, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Login = login;
            Password = password;
            Email = email;
            Role = "Client";
        }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
