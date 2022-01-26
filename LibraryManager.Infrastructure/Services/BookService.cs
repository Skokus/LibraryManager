using LibraryManager.Core.Domain;
using LibraryManager.Core.Repositories;
using LibraryManager.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        private Author MapAuthorDTOToNormal(AuthorDTO author)
        {
            return new Author() {
                Id = author.Id,
                Birthday = author.Birthday,
                Country = author.Country,
                Surname = author.Surname,
                Name = author.Name
            };
        }

        private PublishHouse MapPublishHouseDTOToNormal(PublishHouseDTO publishHouse)
        {
            return new PublishHouse()
            {
                Id = publishHouse.Id,
                Country = publishHouse.Country,
                EstablishDay = publishHouse.EstablishDay,
                Name = publishHouse.Name
            };
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

        public async Task AddAsync(BookDTO book)
        {
            Book b = new Book()
            {
                Id = book.Id,
                Name = book.Name,
                Author = MapAuthorDTOToNormal(book.Author),
                PublishHouse = MapPublishHouseDTOToNormal(book.PublishHouse),
                NumberInSeries = book.NumberInSeries,
                NumberOfPages = book.NumberOfPages
            };
            await _bookRepository.AddAsync(b);
        }

        public async Task<IEnumerable<BookDTO>> BrowseAll()
        {
            var z = await _bookRepository.BrowseAllAsync();
            return z.Select(book => new BookDTO()
            {
                Id = book.Id,
                Name = book.Name,
                Author = MapAuthorDTO(book.Author),
                PublishHouse = MapPublishHouseDTO(book.PublishHouse),
                NumberInSeries = book.NumberInSeries,
                NumberOfPages = book.NumberOfPages
            });
        }

        public async Task DeleteAsync(int id)
        {
            var z = await _bookRepository.GetAsync(id);
            await _bookRepository.DeleteAsync(z);
        }

        public async Task<BookDTO> GetAsync(int id)
        {
            var book = await _bookRepository.GetAsync(id);
            BookDTO n = new BookDTO()
            {
                Id = book.Id,
                Name = book.Name,
                Author = MapAuthorDTO(book.Author),
                PublishHouse = MapPublishHouseDTO(book.PublishHouse),
                NumberInSeries = book.NumberInSeries,
                NumberOfPages = book.NumberOfPages
            };
            return n;
        }

        public async Task UpdateAsync(BookDTO book)
        {
            Book a = new Book()
            {
                Id = book.Id,
                Name = book.Name,
                Author = MapAuthorDTOToNormal(book.Author),
                PublishHouse = MapPublishHouseDTOToNormal(book.PublishHouse),
                NumberInSeries = book.NumberInSeries,
                NumberOfPages = book.NumberOfPages
            };
            await _bookRepository.UpdateAsync(a);
        }
    }
}
