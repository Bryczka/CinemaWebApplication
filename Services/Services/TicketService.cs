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
    public class TicketService : ITicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(TicketDTO ticketDTO)
        {
            var ticket = new Ticket();
            ticket.TicketId = new Guid();
            ticket.SeatNumber = ticketDTO.SeatNumber;
            ticket.RowNumber = ticketDTO.RowNumber;
            ticket.IsPaid = ticketDTO.IsPaid;
            ticket.FilmshowId = ticketDTO.FilmshowId;
            ticket.UserId = ticketDTO.UserId;

            await _unitOfWork.TicketRepository.AddAsync(ticket);
        }

        public async Task AddTicketsAsync(IEnumerable<TicketDTO> ticketsToAdd)
        {
            List<Ticket> tickets = new List<Ticket>();
            foreach (TicketDTO ticketDTO in ticketsToAdd)
            {
                var ticket = new Ticket();
                ticket.TicketId = new Guid();
                ticket.SeatNumber = ticketDTO.SeatNumber;
                ticket.RowNumber = ticketDTO.RowNumber;
                ticket.IsPaid = ticketDTO.IsPaid;
                ticket.FilmshowId = ticketDTO.FilmshowId;
                ticket.UserId = ticketDTO.UserId;
                tickets.Add(ticket);
            }
            await _unitOfWork.TicketRepository.AddTicketsAsync(tickets);
        }

        public async Task DeleteAsync(TicketDTO ticketDTO)
        {
            var ticket = await _unitOfWork.TicketRepository.GetAsync(ticketDTO.TicketId);
            await _unitOfWork.TicketRepository.DeleteAsync(ticket);
        }

        public async Task<IEnumerable<TicketDTO>> GetAllAsync()
        {
            var tickets = await _unitOfWork.TicketRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);
                
        }

        public async Task<IEnumerable<TicketForUserDTO>> GetAllUserTickets(Guid id)
        {
            var tickets = await _unitOfWork.TicketRepository.GetAllUserTickets(id);
            return _mapper.Map<IEnumerable<TicketForUserDTO>>(tickets);
        }

        public async Task<IEnumerable<TicketForUserDTO>> GetAllFilmshowTickets(Guid id)
        {
            var tickets = await _unitOfWork.TicketRepository.GetAllFilmshowTickets(id);
            return _mapper.Map<IEnumerable<TicketForUserDTO>>(tickets);
        }

        public async Task<TicketDTO> GetAsync(Guid id)
        {
            return _mapper.Map<TicketDTO>(await _unitOfWork.TicketRepository.GetAsync(id));
        }

        public async Task Update(TicketDTO ticketDTO)
        {
            var ticket = await _unitOfWork.TicketRepository.GetAsync(ticketDTO.TicketId);
            ticket.IsPaid = ticketDTO.IsPaid;
            ticket.SeatNumber = ticketDTO.SeatNumber;
            ticket.RowNumber = ticketDTO.RowNumber;
            ticket.FilmshowId = ticketDTO.FilmshowId;
            ticket.UserId = ticketDTO.UserId;
            await _unitOfWork.TicketRepository.Update(ticket);
        }
    }
}
