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
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        private Author MapAuthorDTOToNormal(AuthorDTO author)
        {
            return new Author()
            {
                Id = author.Id,
                Birthday = author.Birthday,
                Country = author.Country,
                Surname = author.Surname,
                Name = author.Name
            };
        }

        private FilmStudio MapFilmStudioDTOToNormal(FilmStudioDTO filmStudio)
        {
            return new FilmStudio()
            {
                Id = filmStudio.Id,
                Country = filmStudio.Country,
                EstablishDay = filmStudio.EstablishDay,
                Name = filmStudio.Name,
                Type = filmStudio.Type
            };
        }

        private AuthorDTO MapAuthorDTO(Author author)
        {
            return new AuthorDTO()
            {
                Id = author.Id,
                Birthday = author.Birthday,
                Country = author.Country,
                Surname = author.Surname,
                Name = author.Name
            };
        }

        private FilmStudioDTO MapFilmStudioDTO(FilmStudio filmStudio)
        {
            return new FilmStudioDTO()
            {
                Id = filmStudio.Id,
                Country = filmStudio.Country,
                EstablishDay = filmStudio.EstablishDay,
                Name = filmStudio.Name,
                Type = filmStudio.Type
            };
        }

        public async Task AddAsync(MovieDTO movie)
        {
            Movie b = new Movie()
            {
                Id = movie.Id,
                Name = movie.Name,
                Author = MapAuthorDTOToNormal(movie.Author),
                FilmStudio = MapFilmStudioDTOToNormal(movie.FilmStudio),
                Budget = movie.Budget,
                Length = movie.Length
            };
            await _movieRepository.AddAsync(b);
        }

        public async Task<IEnumerable<MovieDTO>> BrowseAll()
        {
            var z = await _movieRepository.BrowseAllAsync();
            return z.Select(movie => new MovieDTO()
            {
                Id = movie.Id,
                Name = movie.Name,
                Author = MapAuthorDTO(movie.Author),
                FilmStudio = MapFilmStudioDTO(movie.FilmStudio),
                Budget = movie.Budget,
                Length = movie.Length
            });
        }

        public async Task DeleteAsync(int id)
        {
            var z = await _movieRepository.GetAsync(id);
            await _movieRepository.DeleteAsync(z);
        }

        public async Task<MovieDTO> GetAsync(int id)
        {
            var movie = await _movieRepository.GetAsync(id);
            MovieDTO n = new MovieDTO()
            {
                Id = movie.Id,
                Name = movie.Name,
                Author = MapAuthorDTO(movie.Author),
                FilmStudio = MapFilmStudioDTO(movie.FilmStudio),
                Budget = movie.Budget,
                Length = movie.Length
            };
            return n;
        }

        public async Task UpdateAsync(MovieDTO movie)
        {
            Movie a = new Movie()
            {
                Id = movie.Id,
                Name = movie.Name,
                Author = MapAuthorDTOToNormal(movie.Author),
                FilmStudio = MapFilmStudioDTOToNormal(movie.FilmStudio),
                Budget = movie.Budget,
                Length = movie.Length
            };
            await _movieRepository.UpdateAsync(a);
        }
    }
}
