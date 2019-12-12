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
    public class SeatService : ISeatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SeatService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

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
                        HallId = hallWithSeatsDTO.HallId
                    };
                    await _unitOfWork.SeatRepository.AddAsync(seat);
                }
            }
        }
    }
}
