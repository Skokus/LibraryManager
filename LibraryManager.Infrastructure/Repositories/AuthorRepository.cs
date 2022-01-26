using LibraryManager.Core.Domain;
using LibraryManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public Task AddSync(Author a)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Author a)
        {
            throw new NotImplementedException();
        }

        public Task<Author> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Author a)
        {
            throw new NotImplementedException();
        }
    }
}
