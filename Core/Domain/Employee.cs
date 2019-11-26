using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Domain
{
    public class Employee : User
    {
        public Employee(Guid id, string name, string surname, string login, string password, string email) : base(id, name, surname, login, password, email)
        {
        }
    }
}
