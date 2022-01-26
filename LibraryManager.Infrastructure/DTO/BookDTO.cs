using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Infrastructure.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public PublishHouse PublishHouse { get; set; }
        public int NumberInSeries { get; set; }
        public int NumberOfPages { get; set; }
    }
}
