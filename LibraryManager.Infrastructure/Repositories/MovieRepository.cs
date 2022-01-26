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
    public class MovieRepository : IMovieRepository
    {
        private AppDbContext _appDbContext;
        public MovieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddSync(Movie m)
        {
            try
            {
                Author author = _appDbContext.Author.FirstOrDefault(x => x.Id == m.Author.Id);
                if (author != null)
                {
                    m.Author = author;
                }
                FilmStudio filmStudio = _appDbContext.FilmStudio.FirstOrDefault(x => x.Id == m.FilmStudio.Id);
                if (filmStudio != null)
                {
                    m.FilmStudio = filmStudio;
                }
                _appDbContext.Movie.Add(m);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Movie>> BrowseAllAsync()
        {
            try
            {
                return await Task.FromResult(_appDbContext.Movie.Include(y => y.Author).Include(y => y.FilmStudio));
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task DeleteAsync(Movie m)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Movie.Include(y => y.Author).Include(y => y.FilmStudio).FirstOrDefault(x => x.Id == m.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<Movie> GetAsync(int id)
        {
            try
            {
                return _appDbContext.Movie.Include(y => y.Author).Include(y => y.FilmStudio).FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task UpdateAsync(Movie m)
        {
            try
            {
                Author author = _appDbContext.Author.FirstOrDefault(x => x.Id == m.Author.Id);
                if (author != null)
                {
                    m.Author = author;
                }
                FilmStudio publishHouse = _appDbContext.FilmStudio.FirstOrDefault(x => x.Id == m.FilmStudio.Id);
                if (publishHouse != null)
                {
                    m.FilmStudio = publishHouse;
                }
                var z = _appDbContext.Movie.Include(y => y.Author).Include(y => y.FilmStudio).FirstOrDefault(x => x.Id == m.Id);
                z.Name = m.Name;
                z.Author = m.Author;
                z.FilmStudio = m.FilmStudio;
                z.Length = m.Length;
                z.Budget = m.Budget;
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
