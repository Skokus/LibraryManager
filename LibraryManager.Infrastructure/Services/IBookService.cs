using LibraryManager.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Services
{
    public interface IBookService
    {
        public Task<IEnumerable<BookDTO>> BrowseAll();
        public Task DeleteAsync(int id);
        public Task AddAsync(BookDTO book);
        public Task<BookDTO> GetAsync(int id);
        public Task UpdateAsync(BookDTO book);
    }
}
