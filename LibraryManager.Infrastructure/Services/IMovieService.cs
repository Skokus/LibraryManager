using LibraryManager.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Services
{
    public interface IMovieService
    {
        public Task<IEnumerable<MovieDTO>> BrowseAll();
        public Task DelAsync(int id);
        public Task AddAsync(MovieDTO skijumper);
        public Task<MovieDTO> GetAsync(int id);
        public Task UpdateAsync(MovieDTO skijumper);
    }
}
