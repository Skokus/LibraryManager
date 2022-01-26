using LibraryManager.Core.Domain;
using LibraryManager.Core.Repositories;
using LibraryManager.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Infrastructure.Services
{
    public class FilmStudioService : IFilmStudioService
    {
        private readonly IFilmStudioRepository _filmStudioRepository;
        public FilmStudioService(IFilmStudioRepository filmStudioRepository)
        {
            _filmStudioRepository = filmStudioRepository;
        }

        public async Task AddAsync(FilmStudioDTO filmStudio)
        {
            FilmStudio f = new FilmStudio()
            {
                Id = filmStudio.Id,
                Country = filmStudio.Country,
                EstablishDay = filmStudio.EstablishDay,
                Type = filmStudio.Type,
                Name = filmStudio.Name
            };
            await _filmStudioRepository.AddAsync(f);
        }

        public async Task<IEnumerable<FilmStudioDTO>> BrowseAll()
        {
            var z = await _filmStudioRepository.BrowseAllAsync();
            return z.Select(filmStudio => new FilmStudioDTO()
            {
                Id = filmStudio.Id,
                Country = filmStudio.Country,
                EstablishDay = filmStudio.EstablishDay,
                Type = filmStudio.Type,
                Name = filmStudio.Name
            });
        }

        public async Task DeleteAsync(int id)
        {
            var z = await _filmStudioRepository.GetAsync(id);
            await _filmStudioRepository.DeleteAsync(z);
        }

        public async Task<FilmStudioDTO> GetAsync(int id)
        {
            var filmStudio = await _filmStudioRepository.GetAsync(id);
            FilmStudioDTO n = new FilmStudioDTO()
            {
                Id = filmStudio.Id,
                Country = filmStudio.Country,
                EstablishDay = filmStudio.EstablishDay,
                Type = filmStudio.Type,
                Name = filmStudio.Name
            };
            return n;
        }

        public async Task UpdateAsync(FilmStudioDTO filmStudio)
        {
            FilmStudio a = new FilmStudio()
            {
                Id = filmStudio.Id,
                Country = filmStudio.Country,
                EstablishDay = filmStudio.EstablishDay,
                Type = filmStudio.Type,
                Name = filmStudio.Name
            };
            await _filmStudioRepository.UpdateAsync(a);
        }
    }
}
