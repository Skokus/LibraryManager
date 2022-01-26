using LibraryManager.Core.Domain;
using LibraryManager.Core.Repositories;
using System;
using System.Collections.Generic;
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
        public Task AddSync(FilmStudio f)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FilmStudio>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(FilmStudio f)
        {
            throw new NotImplementedException();
        }

        public Task<FilmStudio> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(FilmStudio f)
        {
            throw new NotImplementedException();
        }
    }
}
