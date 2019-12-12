using AutoMapper;
using CinemaWebApplication.Core.Domain;
using CinemaWebApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.DTO.Utils
{
    public static class MapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Film, FilmDTO>()
                    .ForMember(x => x.ImageBase64, m => m.MapFrom(p => Base64Converter.ConvertFileToBase64(p.ImagePath)));
                cfg.CreateMap<FilmDTO, Film>()
                    .ForMember(x => x.ImagePath, m => m.MapFrom(p => Base64Converter.ConvertBase64ToFile(p.ImageBase64)));


                cfg.CreateMap<Filmshow, FilmshowDTO>()
                    .ForMember(x => x.FilmTitle, m => m.MapFrom(p => p.Film.Title))
                    .ForMember(x => x.HallName, m => m.MapFrom(p => p.Hall.Name));

                cfg.CreateMap<Ticket, TicketForUserDTO>()
                    .ForMember(x => x.FilmTitle, m => m.MapFrom(p => p.Filmshow.Film.Title))
                    .ForMember(x => x.HallName, m => m.MapFrom(p => p.Filmshow.Hall.Name))
                    .ForMember(x => x.FilmshowTime, m => m.MapFrom(p => p.Filmshow.FilmshowTime));
                    

                cfg.CreateMap<Hall, HallWithSeatsDTO>();
                cfg.CreateMap<HallWithSeatsDTO, Hall>();

                cfg.CreateMap<Hall, HallWithSeatsForFilmshowDTO>();

                cfg.CreateMap<Seat, SeatDTO>();
                cfg.CreateMap<SeatDTO, Seat>();

                cfg.CreateMap<Seat, SeatFilmshowDTO>();

                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<User, UserRegisterDTO>();


                cfg.CreateMap<TicketDTO, Ticket>();
                cfg.CreateMap<Ticket, TicketDTO>();
            })
            .CreateMapper();
    }
}
