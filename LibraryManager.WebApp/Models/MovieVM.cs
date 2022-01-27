namespace LibraryManager.WebApp.Models
{
    public class MovieVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AuthorVM Author { get; set; }
        public FilmStudioVM FilmStudio { get; set; }
        public int Budget { get; set; }
        public double Length { get; set; }
    }
}
