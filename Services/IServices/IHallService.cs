using CinemaWebApplication.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.IServices
{
    interface IHallService
    {
        Task AddAsync(HallDTO hallDTO);
        Task<HallDTO> GetAsync(Guid id);
        Task<IEnumerable<HallDTO>> GetAllAsync();
        Task Update(HallDTO hallDTO);
        Task DeleteAsync(HallDTO hallDTO);
    }
}
