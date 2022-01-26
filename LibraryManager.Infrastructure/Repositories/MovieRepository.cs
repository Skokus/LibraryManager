using LibraryManager.Core.Domain;
using LibraryManager.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        public Task AddSync(Movie m)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> BrowseAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Movie m)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Movie m)
        {
            throw new NotImplementedException();
        }
    }
}
