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

        public static HallDTO MapHallToDTO(Hall hall)
        {
            var hallDTO = new HallDTO();
            hallDTO.HallId = hall.HallId;
            hall.SeatsCount = hall.SeatsCount;
            hallDTO.Seats = hall.Seats;
            hallDTO.Filmshows = hall.Filmshows;

            return hallDTO;
        }

        public static FilmshowDTO MapFilmshowToDTO(Filmshow filmshow)
        {
            var filmshowDTO = new FilmshowDTO();
            filmshowDTO.FilmshowId = filmshow.FilmshowId;
            filmshowDTO.FilmshowTime = filmshow.FilmshowTime;
            filmshowDTO.FilmId = filmshow.FilmId;
            filmshowDTO.HallId = filmshow.HallId;
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
