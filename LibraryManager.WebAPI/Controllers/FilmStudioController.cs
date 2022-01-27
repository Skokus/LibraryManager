using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManager.Core.Domain;
using LibraryManager.Infrastructure.DTO;
using LibraryManager.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class FilmStudioController : Controller
    {
        private readonly IFilmStudioService _filmStudioService;

        public FilmStudioController(IFilmStudioService filmStudioService)
        {
            _filmStudioService = filmStudioService;
        }

        [HttpGet]
        public async Task<ActionResult> BrowseAll()
        {
            var z = await _filmStudioService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetFilmStudio(int id)
        {
            var z = await _filmStudioService.GetAsync(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<ActionResult> AddFilmStudio([FromBody] FilmStudio filmStudio)
        {
            FilmStudioDTO filmStudioDTO = new FilmStudioDTO()
            {
                Id = filmStudio.Id,
                Country = filmStudio.Country,
                EstablishDay = filmStudio.EstablishDay,
                Type = filmStudio.Type,
                Name = filmStudio.Name
            };
            await _filmStudioService.AddAsync(filmStudioDTO);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditFilmStudio([FromBody] FilmStudio filmStudio, int id)
        {
            FilmStudioDTO filmStudioDTO = new FilmStudioDTO()
            {
                Id = id,
                Country = filmStudio.Country,
                EstablishDay = filmStudio.EstablishDay,
                Type = filmStudio.Type,
                Name = filmStudio.Name
            };
            await _filmStudioService.UpdateAsync(filmStudioDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilmStudio(int id)
        {
            await _filmStudioService.DeleteAsync(id);
            return NoContent();
        }
    }
}