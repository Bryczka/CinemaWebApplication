using CinemaWebApplication.Core.Repositories;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository ClientRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IFilmRepository FilmRepository { get; }
        IFilmshowRepository FilmshowRepository { get; }
        IHallRepository HallRepository { get; }
        ITicketRepository TicketRepository { get; }
        Task Complete();
    }
}
