using AutoMapper;
using CinemaWebApplication.Core;
using CinemaWebApplication.Core.Domain;
using CinemaWebApplication.Services.DTO;
using CinemaWebApplication.Services.IServices;
using CinemaWebApplication.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWebApplication.Services.Services
{
    public class FilmService : IFilmService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FilmService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(FilmDTO filmDTO)
        {
            var film = new Film
            {
                FilmId = Guid.NewGuid(),
                Title = filmDTO.Title,
                Category = filmDTO.Category,
                Length = filmDTO.Length,
                Rating = filmDTO.Rating,
                Description = filmDTO.Description,
                ImagePath = Base64Converter.ConvertBase64ToFile(filmDTO.ImageBase64.Substring(23))
            };
            await _unitOfWork.FilmRepository.AddAsync(film);
        }

        public async Task DeleteAsync(Guid id)
        {
            var film = await _unitOfWork.FilmRepository.GetAsync(id);
            await _unitOfWork.FilmRepository.DeleteAsync(film);
        }

        public async Task<IEnumerable<FilmDTO>> GetAllFilmsWithFilmShowsAsync()
        {
            var films = await _unitOfWork.FilmRepository.GetAllFilmsWithFilmShowsAsync();
            return _mapper.Map<IEnumerable<FilmDTO>>(films);
        }

        public async Task<FilmDTO> GetFilmWithFilmShowsAsync(Guid id)
        {
            var film = await _unitOfWork.FilmRepository.GetFilmWithFilmShowsAsync(id);
            return _mapper.Map<FilmDTO>(film);
        }

        public async Task Update(FilmDTO filmDTO)
        {
            var film = await _unitOfWork.FilmRepository.GetAsync(filmDTO.FilmId);
            film.Title = filmDTO.Title;
            film.Category = filmDTO.Category;
            film.Length = filmDTO.Length;
            film.Rating = filmDTO.Rating;
            film.Description = filmDTO.Description;
            await _unitOfWork.FilmRepository.Update(film);
        }
    }
}
