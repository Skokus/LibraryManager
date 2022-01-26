using LibraryManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Repositories
{
    public interface IBookRepository
    {
        Task AddSync(Book b);
        Task UpdateAsync(Book b);
        Task DeleteAsync(Book b);
        Task<Book> GetAsync(int id);
        Task<IEnumerable<Book>> BrowseAllAsync();
    }
}
