using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaWebApplication.Core;
using CinemaWebApplication.Core.Database;
using CinemaWebApplication.Core.Domain;
using CinemaWebApplication.Core.Repositories;
using CinemaWebApplication.Infrastructure;
using CinemaWebApplication.Infrastructure.Repositories;
using CinemaWebApplication.Services.IServices;
using CinemaWebApplication.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CinemaWebApplication
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var dbConnection = @"Server=(localdb)\mssqllocaldb;Database=Cinema;Trusted_Connection=True";
            services.AddDbContext<DatabaseContext>(opt =>
               opt.UseSqlServer(dbConnection));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IFilmshowRepository, FilmshowRepository>();
            services.AddScoped<IHallRepository, HallRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();

            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IFilmshowService, FilmshowService>();
            services.AddScoped<IHallService, HallService>();
            services.AddScoped<ITicketService, TicketService>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
