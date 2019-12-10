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
    public class SeatService : ISeatService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SeatService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        //public async Task AddAsync(SeatDTO seatDTO)
        //{
        //    var seat = new Seat
        //    {
        //        SeatId = new Guid(),
        //        SeatNumber = seatDTO.SeatNumber,
        //        Row = seatDTO.Row,
        //        IsOccupied = seatDTO.IsOccupied,
        //        HallId = seatDTO.HallId
        //    };

        //    await _unitOfWork.SeatRepository.AddAsync(seat);
        //}

        public async Task AddManyWithHallAsync(HallWithSeatsDTO hallWithSeatsDTO)
        {
            List<SeatDTO> createdSeats = new List<SeatDTO>();
            for(int i = 1; i<=hallWithSeatsDTO.SeatsInRowNumber; i++)
            {
                for(int j =1; j<=hallWithSeatsDTO.RowsNumber; j++)
                {
                    var seat = new Seat
                    {
                        SeatId = Guid.NewGuid(),
                        SeatNumber = i,
                        Row = j,
                        IsOccupied = false,
                        HallId = hallWithSeatsDTO.HallId
                    };
                    await _unitOfWork.SeatRepository.AddAsync(seat);
                    createdSeats.Add(Mappers.MapSeatToDTO(seat));
                }
            }
        }

        public async Task BookSeatAsync(List<SeatDTO> seatsDTO)
        {
            List<Seat> seats = seatsDTO.Select(Mappers.MapDTOToSeat).ToList();
            await _unitOfWork.SeatRepository.BookSeatAsync(seats);
        }

        //public async Task DeleteAsync(SeatDTO seatDTO)
        //{
        //    var seat = await _unitOfWork.SeatRepository.GetAsync(seatDTO.SeatId);
        //    await _unitOfWork.SeatRepository.DeleteAsync(seat);
        //}

        //public async Task<IEnumerable<SeatDTO>> GetAllAsync()
        //{
        //    var seats = await _unitOfWork.SeatRepository.GetAllAsync();
        //    return seats.Select(Mappers.MapSeatToDTO).ToList();
        //}

        //public async Task<SeatDTO> GetAsync(Guid id)
        //{
        //    return Mappers.MapSeatToDTO(await _unitOfWork.SeatRepository.GetAsync(id));
        //}

        public async Task UnbookSeatAsync(List<SeatDTO> seatsDTO)
        {
            List<Seat> seats = seatsDTO.Select(Mappers.MapDTOToSeat).ToList();
            await _unitOfWork.SeatRepository.UnbookSeatAsync(seats);
        }

        //public async Task Update(SeatDTO seatDTO)
        //{
        //    var seat = await _unitOfWork.SeatRepository.GetAsync(seatDTO.SeatId);
        //    seat.SeatNumber = seatDTO.SeatNumber;
        //    seat.Row = seatDTO.Row;
        //    seat.IsOccupied = seatDTO.IsOccupied;
        //    seat.HallId = seatDTO.HallId;
        //    await _unitOfWork.SeatRepository.Update(seat);
        //}
    }
}
