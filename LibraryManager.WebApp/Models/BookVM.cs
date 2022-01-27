namespace LibraryManager.WebApp.Models
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AuthorVM Author { get; set; }
        public PublishHouseVM PublishHouse { get; set; }
        public int NumberInSeries { get; set; }
        public int NumberOfPages { get; set; }
    }
}
