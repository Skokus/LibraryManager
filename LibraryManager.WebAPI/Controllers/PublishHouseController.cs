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
    public class PublishHouseController : Controller
    {
        private readonly IPublishHouseService _publishHouseService;

        public PublishHouseController(IPublishHouseService publishHouseService)
        {
            _publishHouseService = publishHouseService;
        }
        [HttpGet]
        public async Task<ActionResult> BrowseAll()
        {
            var z = await _publishHouseService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPublishHouse(int id)
        {
            var z = await _publishHouseService.GetAsync(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<ActionResult> AddPublishHouse([FromBody] PublishHouse filmStudio)
        {
            PublishHouseDTO filmStudioDTO = new PublishHouseDTO()
            {
                Id = filmStudio.Id,
                Country = filmStudio.Country,
                EstablishDay = filmStudio.EstablishDay,
                Name = filmStudio.Name
            };
            await _publishHouseService.AddAsync(filmStudioDTO);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPublishHouse([FromBody] PublishHouse filmStudio, int id)
        {
            PublishHouseDTO filmStudioDTO = new PublishHouseDTO()
            {
                Id = id,
                Country = filmStudio.Country,
                EstablishDay = filmStudio.EstablishDay,
                Name = filmStudio.Name
            };
            await _publishHouseService.UpdateAsync(filmStudioDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePublishHouse(int id)
        {
            await _publishHouseService.DeleteAsync(id);
            return NoContent();
        }
    }
}