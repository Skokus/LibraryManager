using LibraryManager.Core.Domain;
using LibraryManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task AddSync(Book b)
        {
            try
            {
                Author author = _appDbContext.Author.FirstOrDefault(x => x.Id == b.Author.Id);
                if (author != null)
                {
                    b.Author = author;
                }
                PublishHouse publishHouse = _appDbContext.PublishHouse.FirstOrDefault(x => x.Id == b.PublishHouse.Id);
                if (publishHouse != null)
                {
                    b.PublishHouse = publishHouse;
                }
                _appDbContext.Book.Add(b);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Book>> BrowseAllAsync()
        {
            try
            {
                return await Task.FromResult(_appDbContext.Book.Include(y => y.Author).Include(y => y.PublishHouse));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task DeleteAsync(Book b)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Book.Include(y => y.Author).Include(y => y.PublishHouse).FirstOrDefault(x => x.Id == b.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Book> GetAsync(int id)
        {
            try
            {
                return _appDbContext.Book.Include(y => y.Author).Include(y => y.PublishHouse).FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task UpdateAsync(Book b)
        {
            try
            {
                Author author = _appDbContext.Author.FirstOrDefault(x => x.Id == b.Author.Id);
                if (author != null)
                {
                    b.Author = author;
                }
                PublishHouse publishHouse = _appDbContext.PublishHouse.FirstOrDefault(x => x.Id == b.PublishHouse.Id);
                if (publishHouse != null)
                {
                    b.PublishHouse = publishHouse;
                }
                var z = _appDbContext.Book.Include(y => y.Author).Include(y => y.PublishHouse).FirstOrDefault(x => x.Id == b.Id);
                z.Name = b.Name;
                z.Author = b.Author;
                z.PublishHouse = b.PublishHouse;
                z.NumberOfPages = b.NumberOfPages;
                z.NumberInSeries = b.NumberInSeries;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
