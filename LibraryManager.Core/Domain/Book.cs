using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Core.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public PublishHouse PublishHouse { get; set; }
        public int NumberInSeries { get; set; }
        public int NumberOfPages { get; set; }
    }
}
