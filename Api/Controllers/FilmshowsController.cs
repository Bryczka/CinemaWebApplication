using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaWebApplication.Services.DTO;
using CinemaWebApplication.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaWebApplication.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FilmshowsController : Controller
    {
        private IFilmshowService _filmshowService;
        public FilmshowsController(IFilmshowService filmshowService)
        {
            _filmshowService = filmshowService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmshowDTO>>> GetAllFilmsWithFilmShowsAsync()
        {
            var filmshows = await _filmshowService.GetAllAsync();
            return Json(filmshows);
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody]FilmshowDTO filmshowDTO)
        {
            await _filmshowService.AddAsync(filmshowDTO);

            return Ok();
        }

        [HttpGet("filmshow/{id}")]
        public async Task<ActionResult<FilmDTO>> GetFilmShowsAsync(Guid id)
        {
            var film = await _filmshowService.GetAsync(id);
            return Json(film);
        }


        [HttpDelete("filmshow/{id}")]
        public async Task<ActionResult> DeleteAsync(Guid id)
        {
            var filmshow = await _filmshowService.GetAsync(id);
            await _filmshowService.DeleteAsync(filmshow);

            return Ok();
        }

        [HttpPut("filmshow")]
        public async Task<ActionResult> Update([FromBody]FilmshowDTO filmshowDTO)
        {
            await _filmshowService.Update(filmshowDTO);

            return Ok();
        }
    }
}