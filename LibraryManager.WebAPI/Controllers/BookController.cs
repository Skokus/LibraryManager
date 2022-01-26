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
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        private AuthorDTO MapAuthorDTO(Author author)
        {
            return new AuthorDTO()
            {
                Id = author.Id,
                Birthday = author.Birthday,
                Country = author.Country,
                Surname = author.Surname,
                Name = author.Name
            };
        }

        private PublishHouseDTO MapPublishHouseDTO(PublishHouse publishHouse)
        {
            return new PublishHouseDTO()
            {
                Id = publishHouse.Id,
                Country = publishHouse.Country,
                EstablishDay = publishHouse.EstablishDay,
                Name = publishHouse.Name
            };
        }

        [HttpPost]
        public async Task<ActionResult> AddBook([FromBody] Book book)
        {
            BookDTO bookDTO = new BookDTO()
            {
                Id = book.Id,
                Name = book.Name,
                Author = MapAuthorDTO(book.Author),
                PublishHouse = MapPublishHouseDTO(book.PublishHouse),
                NumberInSeries = book.NumberInSeries,
                NumberOfPages = book.NumberOfPages
            };
            await _bookService.AddAsync(bookDTO);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult> BrowseAll()
        {
            var z = await _bookService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetAuthor(int id)
        {
            var z = await _bookService.GetAsync(id);
            return Json(z);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditAuthor([FromBody] Book book, int id)
        {
            BookDTO bookDTO = new BookDTO()
            {
                Id = id,
                Name = book.Name,
                Author = MapAuthorDTO(book.Author),
                PublishHouse = MapPublishHouseDTO(book.PublishHouse),
                NumberInSeries = book.NumberInSeries,
                NumberOfPages = book.NumberOfPages
            };
            await _bookService.UpdateAsync(bookDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }

    }
}