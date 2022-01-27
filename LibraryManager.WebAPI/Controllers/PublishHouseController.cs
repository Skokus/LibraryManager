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
        public async Task<ActionResult> AddPublishHouse([FromBody] PublishHouse publishHouse)
        {
            PublishHouseDTO publishHouseDTO = new PublishHouseDTO()
            {
                Id = publishHouse.Id,
                Country = publishHouse.Country,
                EstablishDay = publishHouse.EstablishDay,
                Name = publishHouse.Name
            };
            await _publishHouseService.AddAsync(publishHouseDTO);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPublishHouse([FromBody] PublishHouse publishHouse, int id)
        {
            PublishHouseDTO publishHouseDTO = new PublishHouseDTO()
            {
                Id = id,
                Country = publishHouse.Country,
                EstablishDay = publishHouse.EstablishDay,
                Name = publishHouse.Name
            };
            await _publishHouseService.UpdateAsync(publishHouseDTO);
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