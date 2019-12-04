using CinemaWebApplication.Core.Domain;
using CinemaWebApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.DTO
{
    public static class Mappers
    {
        public static FilmDTO MapFilmToDTO(Film film)
        {
            var filmDTO = new FilmDTO();
            filmDTO.FilmId = film.FilmId;
            filmDTO.Title = film.Title;
            filmDTO.Category = film.Category;
            filmDTO.Length = film.Length;
            filmDTO.Rating = film.Rating;
            filmDTO.Filmshows = film.Filmshows;
            filmDTO.Description = film.Description;
            filmDTO.ImageBase64 = Base64Converter.ConvertFileToBase64(film.ImagePath);

            return filmDTO;
        }

        public static SeatDTO MapSeatToDTO(Seat seat)
        {
            var seatDTO = new SeatDTO();
            seatDTO.SeatId = seat.SeatId;
            seatDTO.IsOccupied = seat.IsOccupied;
            seatDTO.Row = seat.Row;
            seatDTO.SeatNumber = seat.SeatNumber;
            seatDTO.HallId = seat.HallId;

            return seatDTO;
        }

        public static ICollection<Seat> MapSeatDTOListToSeatList(ICollection<SeatDTO> seatDTOs)
        {
            List<Seat> seats = new List<Seat>();
            foreach(SeatDTO seatDTO in seatDTOs)
            {
                var seat = new Seat();
                seat.SeatId = seatDTO.SeatId;
                seat.IsOccupied = seatDTO.IsOccupied;
                seat.Row = seatDTO.Row;
                seat.SeatNumber = seatDTO.SeatNumber;
                seat.HallId = seatDTO.HallId;
                seats.Add(seat);
            }

            return seats;
        }

        public static HallDTO MapHallToDTO(Hall hall)
        {
            var hallDTO = new HallDTO();
            hallDTO.HallId = hall.HallId;
            hallDTO.Name = hall.Name;
            hallDTO.Seats = hall.Seats;
            hallDTO.Filmshows = hall.Filmshows;

            return hallDTO;
        }

        public static FilmshowDTO MapFilmshowToDTO(Filmshow filmshow, Film film, Hall hall)
        {
            var filmshowDTO = new FilmshowDTO();
            filmshowDTO.FilmshowId = filmshow.FilmshowId;
            filmshowDTO.FilmshowDate = filmshow.FilmshowTime;
            filmshowDTO.FilmId = filmshow.FilmId;
            filmshowDTO.FilmTitle = film.Title;
            filmshowDTO.HallId = filmshow.HallId;
            filmshowDTO.HallName = hall.Name;
            filmshowDTO.Tickets = filmshow.Tickets;

            return filmshowDTO;
        }

        public static TicketDTO MapTicketToDTO(Ticket ticket)
        {
            var ticketDTO = new TicketDTO();
            ticketDTO.TicketId = ticket.TicketId;
            ticketDTO.IsPaid = ticket.IsPaid;
            ticketDTO.SeatNumber = ticket.SeatNumber;
            ticketDTO.FilmshowId = ticket.FilmshowId;
            ticketDTO.ClientId = ticket.ClientId;

            return ticketDTO;
        }

        public static UserRegisterDTO MapUserToRegisterDTO(User user)
        {
            var userRegisterDTO = new UserRegisterDTO();
            userRegisterDTO.Login = user.Login;
            userRegisterDTO.Name = user.Name;
            userRegisterDTO.Email = user.Email;
            userRegisterDTO.PhoneNumber = user.PhoneNumber;
            userRegisterDTO.Surname = user.Surname;

            return userRegisterDTO;
        }
    }
}
