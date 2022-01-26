using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Infrastructure.DTO
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
    }
}
