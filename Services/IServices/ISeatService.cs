using CinemaWebApplication.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.IServices
{
    public interface ISeatService
    {
        Task BookSeatAsync(List<SeatDTO> seats);
        Task UnbookSeatAsync(List<SeatDTO> seats);
        Task AddManyWithHallAsync(HallWithSeatsDTO hallWithSeatsDTO);
    }
}
