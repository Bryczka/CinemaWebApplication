using CinemaWebApplication.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.IServices
{
    interface ISeatService
    {
        Task BookSeatAsync(Guid id);
        Task UnbookSeatAsync(Guid id);
        Task AddAsync(SeatDTO seatDTO);
        Task<SeatDTO> GetAsync(Guid id);
        Task<IEnumerable<SeatDTO>> GetAllAsync();
        Task Update(SeatDTO seatDTO);
        Task DeleteAsync(SeatDTO seatDTO);
    }
}
