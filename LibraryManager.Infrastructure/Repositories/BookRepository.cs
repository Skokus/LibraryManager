using LibraryManager.Core.Domain;
using LibraryManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private AppDbContext _appDbContext;
        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public Task AddSync(Book b)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Book b)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Book b)
        {
            throw new NotImplementedException();
        }
    }
}
