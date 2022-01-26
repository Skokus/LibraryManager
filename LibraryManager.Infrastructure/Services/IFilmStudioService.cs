using LibraryManager.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Services
{
    public interface IFilmStudioService
    {
        public Task<IEnumerable<FilmStudioDTO>> BrowseAll();
        public Task DeleteAsync(int id);
        public Task AddAsync(FilmStudioDTO filmStudio);
        public Task<FilmStudioDTO> GetAsync(int id);
        public Task UpdateAsync(FilmStudioDTO filmStudio);
    }
}
