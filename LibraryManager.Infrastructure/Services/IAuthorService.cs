using LibraryManager.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Services
{
    public interface IAuthorService
    {
        public Task<IEnumerable<AuthorDTO>> BrowseAll();
        public Task DelAsync(int id);
        public Task AddAsync(AuthorDTO author);
        public Task<AuthorDTO> GetAsync(int id);
        public Task UpdateAsync(AuthorDTO author);
    }
}
