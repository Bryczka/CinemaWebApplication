using CinemaWebApplication.Core;
using CinemaWebApplication.Core.Domain;
using CinemaWebApplication.Services.DTO;
using CinemaWebApplication.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.Services
{
    public class HallService : IHallService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HallService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(HallDTO hallDTO)
        {
            var hall = new Hall();
            hall.HallId = new Guid();
            hall.Seats = hallDTO.Seats;
            hall.Filmshows = hallDTO.Filmshows;
            hall.SeatsCount = hallDTO.SeatsCount;

            await _unitOfWork.HallRepository.AddAsync(hall);
        }

        public async Task DeleteAsync(HallDTO hallDTO)
        {
            var hall = await _unitOfWork.HallRepository.GetAsync(hallDTO.HallId);
            await _unitOfWork.HallRepository.DeleteAsync(hall);
        }

        public async Task<IEnumerable<HallDTO>> GetAllAsync()
        {
            var halls = await _unitOfWork.HallRepository.GetAllAsync();
            return halls.Select(Mappers.MapHallToDTO).ToList();
        }

        public async Task<HallDTO> GetAsync(Guid id)
        {
            return Mappers.MapHallToDTO(await _unitOfWork.HallRepository.GetAsync(id));
        }

        public async Task Update(HallDTO hallDTO)
        {
            var hall = await _unitOfWork.HallRepository.GetAsync(hallDTO.HallId);
            hall.Seats = hallDTO.Seats;
            hall.SeatsCount = hallDTO.SeatsCount;
            hall.Filmshows = hallDTO.Filmshows;
            await _unitOfWork.HallRepository.Update(hall);
        }
    }
}
