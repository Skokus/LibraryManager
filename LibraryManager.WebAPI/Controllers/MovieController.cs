using LibraryManager.Core.Domain;
using LibraryManager.Infrastructure.DTO;
using LibraryManager.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibraryManager.WebAPI.Controllers
{
    [Route("[Controller]")]
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
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

        [HttpPost]
        public async Task<ActionResult> AddMovie([FromBody] Movie movie)
        {
            MovieDTO movieDTO = new MovieDTO()
            {
                Id = movie.Id,
                Name = movie.Name,
                Author = MapAuthorDTO(movie.Author),
                FilmStudio = MapFilmStudioDTO(movie.FilmStudio),
                Budget = movie.Budget,
                Length = movie.Length
            };
            await _movieService.AddAsync(movieDTO);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult> BrowseAll()
        {
            var z = await _movieService.BrowseAll();
            return Json(z);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetMovie(int id)
        {
            var z = await _movieService.GetAsync(id);
            return Json(z);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditMovie([FromBody] Movie movie, int id)
        {
            MovieDTO movieDTO = new MovieDTO()
            {
                Id = id,
                Name = movie.Name,
                Author = MapAuthorDTO(movie.Author),
                FilmStudio = MapFilmStudioDTO(movie.FilmStudio),
                Budget = movie.Budget,
                Length = movie.Length
            };
            await _movieService.UpdateAsync(movieDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _movieService.DeleteAsync(id);
            return NoContent();
        }
    }
}
