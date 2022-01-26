using LibraryManager.Core.Domain;
using LibraryManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private AppDbContext _appDbContext;
        public AuthorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Author a)
        {
            try
            {
                _appDbContext.Author.Add(a);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Author>> BrowseAllAsync()
        {
            try
            {
                return await Task.FromResult(_appDbContext.Author);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task DeleteAsync(Author a)
        {
            try
            {
                _appDbContext.RemoveRange(_appDbContext.Book.Where(x => x.Author.Id == a.Id));
                _appDbContext.Remove(_appDbContext.Author.FirstOrDefault(x => x.Id == a.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Author> GetAsync(int id)
        {
            try
            {
                return _appDbContext.Author.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task UpdateAsync(Author a)
        {
            try
            {
                var z = _appDbContext.Author.FirstOrDefault(x => x.Id == a.Id);

                z.Name = a.Name;
                z.Surname = a.Surname;
                z.Birthday = a.Birthday;
                z.Country = a.Country;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
