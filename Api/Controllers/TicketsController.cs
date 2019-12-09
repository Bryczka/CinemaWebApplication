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
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : Controller
    {
        private ITicketService _ticketService;
        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public async Task<ActionResult> AddTicketsAsync([FromBody]List<TicketDTO> ticketDTO)
        {
            await _ticketService.AddTicketsAsync(ticketDTO);

            return Ok();
        }
    }
}