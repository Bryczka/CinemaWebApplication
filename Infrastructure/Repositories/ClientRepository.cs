using CinemaWebApplication.Core.Model;
using CinemaWebApplication.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
    }
}
