using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Domain
{
    public class Client : User
    {

        public Client(Guid id, string name, string surname, string login, string password, string email, string role) : base(id, name, surname, login, password, email)
        {
            Role = role;
        }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
