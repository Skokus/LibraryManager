using LibraryManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Infrastructure.DTO
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AuthorDTO Author { get; set; }
        public PublishHouseDTO PublishHouse { get; set; }
        public int NumberInSeries { get; set; }
        public int NumberOfPages { get; set; }
    }
}
