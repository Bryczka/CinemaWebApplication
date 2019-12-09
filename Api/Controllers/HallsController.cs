using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaWebApplication.Services.DTO;
using CinemaWebApplication.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWebApplication.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HallsController : Controller
    {
        private IHallService _hallService;
        private ISeatService _seatService;
        public HallsController(IHallService hallService, ISeatService seatService)
        {
            _hallService = hallService;
            _seatService = seatService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HallWithSeatsDTO>>> GetAllHallsWithSeatsAsync()
        {
            var halls = await _hallService.GetAllHallsWithSeatsAsync();
            return Json(halls);
        }

        [HttpDelete("hall/{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _hallService.DeleteHallWithSeatsAsync(id);
            return Ok();
        }


        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody]HallWithSeatsDTO hallWithSeatsDTO)
        {
            hallWithSeatsDTO.HallId = Guid.NewGuid();
            await _hallService.AddWithSeatsAsync(hallWithSeatsDTO);
            await _seatService.AddManyWithHallAsync(hallWithSeatsDTO);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HallWithSeatsDTO>> GetHallWithSeatsAsync(Guid id)
        {
            var hall = await _hallService.GetHallWithSeatsAsync(id);
            return Json(hall);
        }
    }
}