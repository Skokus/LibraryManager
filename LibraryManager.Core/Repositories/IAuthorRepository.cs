using LibraryManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Repositories
{
    public interface IAuthorRepository
    {
        Task AddAsync(Author a);
        Task UpdateAsync(Author a);
        Task DeleteAsync(Author a);
        Task<Author> GetAsync(int id);
        Task<IEnumerable<Author>> BrowseAllAsync();
    }
}
