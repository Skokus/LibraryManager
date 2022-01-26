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
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task AddAsync(AuthorDTO author)
        {
            Author a = new Author()
            {
                Id = author.Id,
                Birthday = author.Birthday,
                Country = author.Country,
                Surname = author.Surname,
                Name = author.Name        
            };
            await _authorRepository.AddAsync(a);
        }

        public async Task<IEnumerable<AuthorDTO>> BrowseAll()
        {
            var z = await _authorRepository.BrowseAllAsync();
            return z.Select(author => new AuthorDTO()
            {
                Id = author.Id,
                Birthday = author.Birthday,
                Country = author.Country,
                Surname = author.Surname,
                Name = author.Name
            });
        }

        public async Task DeleteAsync(int id)
        {
            var z = await _authorRepository.GetAsync(id);
            await _authorRepository.DeleteAsync(z);
        }

        public async Task<AuthorDTO> GetAsync(int id)
        {
            var author = await _authorRepository.GetAsync(id);
            AuthorDTO n = new AuthorDTO()
            {
                Id = author.Id,
                Birthday = author.Birthday,
                Country = author.Country,
                Surname = author.Surname,
                Name = author.Name
            };
            return n;
        }

        public async Task UpdateAsync(AuthorDTO author)
        {
            Author a = new Author()
            {
                Id = author.Id,
                Birthday = author.Birthday,
                Country = author.Country,
                Surname = author.Surname,
                Name = author.Name
            };
            await _authorRepository.UpdateAsync(a);
        }
    }
}
