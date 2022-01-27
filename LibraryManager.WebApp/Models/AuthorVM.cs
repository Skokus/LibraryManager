using System;

namespace LibraryManager.WebApp.Models
{
    public class AuthorVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
    }
}
