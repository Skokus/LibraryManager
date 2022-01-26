using LibraryManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Repositories
{
    public interface IMovieRepository
    {
        Task AddAsync(Movie m);
        Task UpdateAsync(Movie m);
        Task DeleteAsync(Movie m);
        Task<Movie> GetAsync(int id);
        Task<IEnumerable<Movie>> BrowseAllAsync();
    }
}
