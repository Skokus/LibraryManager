using LibraryManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Repositories
{
    public interface IFilmStudioRepository
    {
        Task AddSync(FilmStudio f);
        Task UpdateAsync(FilmStudio f);
        Task DeleteAsync(FilmStudio f);
        Task<FilmStudio> GetAsync(int id);
        Task<IEnumerable<FilmStudio>> BrowseAllAsync();
    }
}
