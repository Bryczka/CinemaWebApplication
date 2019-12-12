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
    public class FilmshowService : IFilmshowService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FilmshowService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(FilmshowDTO filmshowDTO)
        {
            var filmshow = new Filmshow();
            filmshow.FilmshowId = Guid.NewGuid();
            filmshow.FilmshowTime = filmshowDTO.FilmshowTime;
            filmshow.HallId = filmshowDTO.HallId;
            filmshow.FilmId = filmshowDTO.FilmId;

            await _unitOfWork.FilmshowRepository.AddAsync(filmshow);
        }
        public async Task DeleteAsync(FilmshowDTO filmshowDTO)
        {
            var filmshow = await _unitOfWork.FilmshowRepository.GetAsync(filmshowDTO.FilmshowId);
            await _unitOfWork.FilmshowRepository.DeleteAsync(filmshow);
        }

        public async Task<IEnumerable<FilmshowDTO>> GetAllAsync()
        {
            var filmshows = await _unitOfWork.FilmshowRepository.GetAllWithHallAndFilm();
            return _mapper.Map<IEnumerable<FilmshowDTO>>(filmshows);
        }

        public async Task<IEnumerable<FilmshowDTO>> GetAllFilmshowsOfFilmAsync(Guid id)
        {
            var filmshows = await _unitOfWork.FilmshowRepository.GetAllFilmshowsOfFilmAsync(id);
            return _mapper.Map<IEnumerable<FilmshowDTO>>(filmshows);
        }

        public async Task<IEnumerable<FilmshowDTO>> GetAllFilmshowsOfFilmAsync(Guid id, DateTime dateTime)
        {
            var filmshows = await _unitOfWork.FilmshowRepository.GetAllFilmshowsOfFilmDateAsync(id, dateTime);
            return _mapper.Map<IEnumerable<FilmshowDTO>>(filmshows); ;
        }

        public async Task<FilmshowDTO> GetAsync(Guid id)
        {
            var filmshow = await _unitOfWork.FilmshowRepository.GetAsync(id);
            return _mapper.Map<FilmshowDTO>(filmshow);
        }

        public async Task Update(FilmshowDTO filmshowDTO)
        {
            var filmshow = await _unitOfWork.FilmshowRepository.GetAsync(filmshowDTO.FilmshowId);
            filmshow.FilmshowTime = filmshowDTO.FilmshowTime;
            filmshow.HallId = filmshowDTO.HallId;
            filmshow.FilmId = filmshowDTO.FilmId;
            await _unitOfWork.FilmshowRepository.Update(filmshow);
        }
    }
}
