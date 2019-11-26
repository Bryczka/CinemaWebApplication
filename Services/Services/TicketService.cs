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
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TicketService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(TicketDTO ticketDTO)
        {
            var ticket = new Ticket();
            ticket.TicketId = new Guid();
            ticket.SeatNumber = ticketDTO.SeatNumber;
            ticket.IsPaid = ticketDTO.IsPaid;
            ticket.FilmshowId = ticketDTO.FilmshowId;
            ticket.ClientId = ticketDTO.ClientId;

            await _unitOfWork.TicketRepository.AddAsync(ticket);
        }

        public async Task DeleteAsync(TicketDTO ticketDTO)
        {
            var ticket = await _unitOfWork.TicketRepository.GetAsync(ticketDTO.TicketId);
            await _unitOfWork.TicketRepository.DeleteAsync(ticket);
        }

        public async Task<IEnumerable<TicketDTO>> GetAllAsync()
        {
            var tickets = await _unitOfWork.TicketRepository.GetAllAsync();
            return tickets.Select(Mappers.MapTicketToDTO).ToList();
        }

        public async Task<TicketDTO> GetAsync(Guid id)
        {
            return Mappers.MapTicketToDTO(await _unitOfWork.TicketRepository.GetAsync(id));
        }

        public async Task Update(TicketDTO ticketDTO)
        {
            var ticket = await _unitOfWork.TicketRepository.GetAsync(ticketDTO.TicketId);
            ticket.IsPaid = ticketDTO.IsPaid;
            ticket.SeatNumber = ticketDTO.SeatNumber;
            ticket.FilmshowId = ticketDTO.FilmshowId;
            ticket.ClientId = ticketDTO.ClientId;
            await _unitOfWork.TicketRepository.Update(ticket);
        }
    }
}
