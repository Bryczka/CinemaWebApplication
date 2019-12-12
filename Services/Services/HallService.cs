using AutoMapper;
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
        private readonly IMapper _mapper;
        public HallService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
            return _mapper.Map<IEnumerable<HallWithSeatsDTO>>(halls);
        }

        public async Task<HallWithSeatsDTO> GetHallWithSeatsAsync(Guid id)
        {
                var hall = await _unitOfWork.HallRepository.GetHallWithSeatsAsync(id);
                var seats = hall.Seats.OrderBy(x => x.SeatNumber).ToList();
                hall.Seats = seats;
                return _mapper.Map<HallWithSeatsDTO>(hall);
        }

        public async Task<HallWithSeatsForFilmshowDTO> GetHallWithSeatsForFilmshowAsync(Guid id, Guid filmshowId)
        {
            var hall = await _unitOfWork.HallRepository.GetHallWithSeatsAsync(id);
            var filmshow = await _unitOfWork.FilmshowRepository.GetFilmshowWithTicketsAsync(filmshowId);
            var seats = hall.Seats.OrderBy(x => x.SeatNumber).ToList();
            hall.Seats = seats;

            var hallDTO = _mapper.Map<HallWithSeatsForFilmshowDTO>(hall);
            foreach(SeatFilmshowDTO seatDTO in hallDTO.Seats)
            {
                foreach(Ticket t in filmshow.Tickets)
                {
                    if( t.RowNumber == seatDTO.Row && t.SeatNumber == seatDTO.SeatNumber)
                    {
                        seatDTO.IsOccupied = true;
                    }
                }
            }
            return hallDTO;
        }
    }
}
