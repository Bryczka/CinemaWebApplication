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
    public class TicketsController : Controller
    {
        private ITicketService _ticketService;
        private ISeatService _seatService;
        public TicketsController(ITicketService ticketService, ISeatService seatService)
        {
            _ticketService = ticketService;
            _seatService = seatService;
        }

        [HttpGet("tickets/{id}")]
        public async Task<IEnumerable<TicketDTO>> GetAllUserTickets(Guid id)
        {
           return await _ticketService.GetAllUserTickets(id);
        }

        [HttpPost]
        public async Task<ActionResult> AddTicketsAsync([FromBody]List<TicketDTO> ticketDTO)
        {
            await _ticketService.AddTicketsAsync(ticketDTO);

            return Ok();
        }

        [HttpPut("seats")]
        public async Task<ActionResult> BookSeat([FromBody]List<SeatDTO> seats)
        {
            await _seatService.BookSeatAsync(seats);

            return Ok();
        }
    }
}