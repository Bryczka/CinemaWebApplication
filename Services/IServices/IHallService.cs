using CinemaWebApplication.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.IServices
{
    public interface IHallService
    {
        //Task AddAsync(HallDTO hallDTO);
        Task AddWithSeatsAsync(HallWithSeatsDTO hallWithSeatsDTO);
        //Task<HallDTO> GetAsync(Guid id);
        Task<HallWithSeatsDTO> GetHallWithSeatsAsync(Guid id);
        //Task<IEnumerable<HallDTO>> GetAllAsync();
        //Task Update(HallDTO hallDTO);
        //Task DeleteAsync(HallDTO hallDTO);
        Task DeleteHallWithSeatsAsync(Guid hallId);
        Task<IEnumerable<HallWithSeatsDTO>> GetAllHallsWithSeatsAsync();

    }
}
