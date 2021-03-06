using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Core.Domain
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Country { get; set; }
    }
}
