using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinemaWebApplication.Core;
using CinemaWebApplication.Core.Database;
using CinemaWebApplication.Core.Domain;
using CinemaWebApplication.Core.Repositories;
using CinemaWebApplication.Infrastructure;
using CinemaWebApplication.Infrastructure.Repositories;
using CinemaWebApplication.Services.DTO.Utils;
using CinemaWebApplication.Services.IServices;
using CinemaWebApplication.Services.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

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

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFilmRepository, FilmRepository>();
            services.AddScoped<IFilmshowRepository, FilmshowRepository>();
            services.AddScoped<IHallRepository, HallRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ISeatRepository, SeatRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFilmService, FilmService>();
            services.AddScoped<IFilmshowService, FilmshowService>();
            services.AddScoped<IHallService, HallService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ISeatService, SeatService>();

            services.AddSingleton(MapperConfig.Initialize());

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false

                };
            });

            services.AddControllers();
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
