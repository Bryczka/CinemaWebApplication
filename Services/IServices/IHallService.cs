using CinemaWebApplication.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.IServices
{
    public interface IHallService
    {
        Task AddWithSeatsAsync(HallWithSeatsDTO hallWithSeatsDTO);
        Task<HallWithSeatsDTO> GetHallWithSeatsAsync(Guid id);
        Task DeleteHallWithSeatsAsync(Guid hallId);
        Task<IEnumerable<HallWithSeatsDTO>> GetAllHallsWithSeatsAsync();

    }
}
