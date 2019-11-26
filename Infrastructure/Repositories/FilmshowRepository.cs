using CinemaWebApplication.Core.Database;
using CinemaWebApplication.Core.Domain;
using CinemaWebApplication.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Infrastructure.Repositories
{
    public class FilmshowRepository : Repository<Filmshow>, IFilmshowRepository
    {
        public FilmshowRepository(DatabaseContext context) : base(context) { }
    }
}
