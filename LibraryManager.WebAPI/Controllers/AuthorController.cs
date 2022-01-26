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
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet]
        public async Task<ActionResult> BrowseAll()
        {
            var z = await _authorService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAuthor(int id)
        {
            var z = await _authorService.GetAsync(id);
            return Json(z);
        }

        [HttpPost]
        public async Task<ActionResult> AddAuthor([FromBody] Author author)
        {
            AuthorDTO authorDTO = new AuthorDTO()
            {
                Id = author.Id,
                Birthday = author.Birthday,
                Country = author.Country,
                Surname = author.Surname,
                Name = author.Name
            };
            await _authorService.AddAsync(authorDTO);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAuthor([FromBody] Author author, int id)
        {
            AuthorDTO authorDTO = new AuthorDTO()
            {
                Id = id,
                Birthday = author.Birthday,
                Country = author.Country,
                Surname = author.Surname,
                Name = author.Name
            };
            await _authorService.UpdateAsync(authorDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _authorService.DeleteAsync(id);
            return NoContent();
        }
    }
}