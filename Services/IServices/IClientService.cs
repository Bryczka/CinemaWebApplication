using CinemaWebApplication.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.IServices
{
    public interface IClientService
    {
        Task RegisterAsync(string name, string surname, string login,
            string password, string phoneNumber, string email);
        Task<IEnumerable<Client>> GetAllAsync();
    }
}