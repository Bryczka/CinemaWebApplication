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
        public FilmshowService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(FilmshowDTO filmshowDTO)
        {
            var filmshow = new Filmshow();
            filmshow.FilmshowId = new Guid();
            filmshow.FilmshowTime = filmshowDTO.FilmshowTime;
            filmshow.HallId = filmshowDTO.HallId;
            filmshow.FilmId = filmshowDTO.FilmId;
            filmshow.Tickets = filmshowDTO.Tickets;

            await _unitOfWork.FilmshowRepository.AddAsync(filmshow);
        }

        public async Task DeleteAsync(FilmshowDTO filmshowDTO)
        {
            var filmshow = await _unitOfWork.FilmshowRepository.GetAsync(filmshowDTO.FilmshowId);
            await _unitOfWork.FilmshowRepository.DeleteAsync(filmshow);
        }

        public async Task<IEnumerable<FilmshowDTO>> GetAllAsync()
        {
            var filmshows = await _unitOfWork.FilmshowRepository.GetAllAsync();
            return filmshows.Select(Mappers.MapFilmshowToDTO).ToList();
        }

        public async Task<FilmshowDTO> GetAsync(Guid id)
        {
            return Mappers.MapFilmshowToDTO(await _unitOfWork.FilmshowRepository.GetAsync(id));
        }

        public async Task Update(FilmshowDTO filmshowDTO)
        {
            var filmshow = await _unitOfWork.FilmshowRepository.GetAsync(filmshowDTO.FilmshowId);
            filmshow.FilmshowTime = filmshowDTO.FilmshowTime;
            filmshow.HallId = filmshowDTO.HallId;
            filmshow.FilmId = filmshowDTO.FilmId;
            filmshow.Tickets = filmshowDTO.Tickets;
            await _unitOfWork.FilmshowRepository.Update(filmshow);
        }
    }
}
