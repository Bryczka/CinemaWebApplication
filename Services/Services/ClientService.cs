using CinemaWebApplication.Core;
using CinemaWebApplication.Core.Domain;
using CinemaWebApplication.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await _unitOfWork.ClientRepository.GetAllAsync();
        }

        public async Task RegisterAsync(string name, string surname, string login, string password, string phoneNumber, string email)
        {
            var client = await _unitOfWork.ClientRepository.GetByEmail(email);
            client = await _unitOfWork.ClientRepository.GetByLogin(login);

            client = new Client(new Guid(), name, surname, login, password, email);
        }          
    }
}