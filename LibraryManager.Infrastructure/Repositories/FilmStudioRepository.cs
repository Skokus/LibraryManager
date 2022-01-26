using LibraryManager.Core.Domain;
using LibraryManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Repositories
{
    public class FilmStudioRepository : IFilmStudioRepository
    {
        private AppDbContext _appDbContext;
        public FilmStudioRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(FilmStudio f)
        {
            try
            {
                _appDbContext.FilmStudio.Add(f);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<FilmStudio>> BrowseAllAsync()
        {
            try
            {
                return await Task.FromResult(_appDbContext.FilmStudio);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task DeleteAsync(FilmStudio f)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.FilmStudio.FirstOrDefault(x => x.Id == f.Id));
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<FilmStudio> GetAsync(int id)
        {
            try
            {
                return _appDbContext.FilmStudio.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
                return null;
            }
        }

        public async Task UpdateAsync(FilmStudio f)
        {
            try
            {
                var z = _appDbContext.FilmStudio.FirstOrDefault(x => x.Id == f.Id);

                z.Name = f.Name;
                z.Country = f.Country;
                z.EstablishDay = f.EstablishDay;
                z.Type = f.Type;

                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
