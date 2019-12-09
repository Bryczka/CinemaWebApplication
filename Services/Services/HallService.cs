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
        public async Task AddWithSeatsAsync(HallWithSeatsDTO hallWithSeatsDTO)
        {
            var hall = new Hall();
            hall.HallId = hallWithSeatsDTO.HallId;
            hall.Name = hallWithSeatsDTO.Name;
            hall.RowsNumber = hallWithSeatsDTO.RowsNumber;
            hall.SeatsInRowNumber = hallWithSeatsDTO.SeatsInRowNumber;
            await _unitOfWork.HallRepository.AddAsync(hall);
        }

        public async Task DeleteHallWithSeatsAsync(Guid hallId)
        {
            var hall = await _unitOfWork.HallRepository.GetAsync(hallId);
            await _unitOfWork.HallRepository.DeleteAsync(hall);
        }

        public async Task<IEnumerable<HallWithSeatsDTO>> GetAllHallsWithSeatsAsync()
        {
            var halls = await _unitOfWork.HallRepository.GetAllHallsWithSeatsAsync();
            return halls.Select(Mappers.MapHallToDTO).ToList();
        }

        public async Task<HallWithSeatsDTO> GetHallWithSeatsAsync(Guid id)
        {
            var hall = await _unitOfWork.HallRepository.GetHallWithSeatsAsync(id);
            var seats = hall.Seats.OrderBy(x => x.SeatNumber).ToList();
            hall.Seats = seats;
            return Mappers.MapHallToDTO(hall);
 
        }

        //public async Task AddAsync(HallDTO hallDTO)
        //{
        //    var hall = new Hall();
        //    hall.HallId = Guid.NewGuid();
        //    hall.Seats = hallDTO.Seats;
        //    hall.Filmshows = hallDTO.Filmshows;

        //    await _unitOfWork.HallRepository.AddAsync(hall);
        //}



        //public async Task DeleteAsync(HallDTO hallDTO)
        //{
        //    var hall = await _unitOfWork.HallRepository.GetAsync(hallDTO.HallId);
        //    await _unitOfWork.HallRepository.DeleteAsync(hall);
        //}



        //public async Task<IEnumerable<HallDTO>> GetAllAsync()
        //{
        //    var halls = await _unitOfWork.HallRepository.GetAllAsync();
        //    return halls.Select(Mappers.MapHallToDTO).ToList();
        //}

        //public async Task<HallDTO> GetAsync(Guid id)
        //{
        //    return Mappers.MapHallToDTO(await _unitOfWork.HallRepository.GetAsync(id));
        //}



        //public async Task Update(HallDTO hallDTO)
        //{
        //    var hall = await _unitOfWork.HallRepository.GetAsync(hallDTO.HallId);
        //    hall.Seats = hallDTO.Seats;
        //    hall.Filmshows = hallDTO.Filmshows;
        //    await _unitOfWork.HallRepository.Update(hall);
        //}
    }
}
