using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Model
{
    public class Client : User
    {
        public ICollection<Ticket> Tickets { get; set; }
    }
}
