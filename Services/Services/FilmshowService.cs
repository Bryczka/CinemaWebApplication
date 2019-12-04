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
            filmshow.FilmshowId = Guid.NewGuid();
            filmshow.FilmshowTime = filmshowDTO.FilmshowDate;

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
            List<FilmshowDTO> filmshowsDTO = new List<FilmshowDTO>();
            foreach (Filmshow filmshow in filmshows)
            {
                var film = await _unitOfWork.FilmRepository.GetAsync(filmshow.FilmId);
                var hall = await _unitOfWork.HallRepository.GetAsync(filmshow.HallId);
                filmshowsDTO.Add(Mappers.MapFilmshowToDTO(filmshow, film, hall));
            }

            return filmshowsDTO;
        }

        public async Task<FilmshowDTO> GetAsync(Guid id)
        {
            var filmshow = await _unitOfWork.FilmshowRepository.GetAsync(id);
            var film = await _unitOfWork.FilmRepository.GetAsync(filmshow.FilmId);
            var hall = await _unitOfWork.HallRepository.GetAsync(filmshow.HallId);
            return Mappers.MapFilmshowToDTO(await _unitOfWork.FilmshowRepository.GetAsync(id), film, hall);
        }

        public async Task Update(FilmshowDTO filmshowDTO)
        {
            var filmshow = await _unitOfWork.FilmshowRepository.GetAsync(filmshowDTO.FilmshowId);
            filmshow.FilmshowTime = filmshowDTO.FilmshowDate;
            filmshow.HallId = filmshowDTO.HallId;
            filmshow.FilmId = filmshowDTO.FilmId;
            filmshow.Tickets = filmshowDTO.Tickets;
            await _unitOfWork.FilmshowRepository.Update(filmshow);
        }
    }
}
