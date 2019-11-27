using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaWebApplication.Core.Domain;
using CinemaWebApplication.Services.DTO;
using CinemaWebApplication.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWebApplication.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmsController : Controller
    {
        private IFilmService _filmService;
        public FilmsController(IFilmService filmService)
        {
            _filmService = filmService;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmDTO>>> GetAllFilmsWithFilmShowsAsync()
        {
            var films = await _filmService.GetAllFilmsWithFilmShowsAsync();
            return Json(films);
        }

        [HttpGet("film/{id}")]
        public async Task<ActionResult<FilmDTO>> GetFilmWithFilmShowsAsync(Guid id)
        {
            var film = await _filmService.GetFilmWithFilmShowsAsync(id);
            return Json(film);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody]FilmDTO filmDTO)
        {
            await _filmService.AddAsync(filmDTO);

            return Ok();
        }

        [HttpDelete("film/{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            await _filmService.DeleteAsync(id);

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody]FilmDTO filmDTO)
        {
            await _filmService.Update(filmDTO);

            return Ok();
        }
    }
}