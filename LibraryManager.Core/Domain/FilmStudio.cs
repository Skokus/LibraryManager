using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Core.Domain
{
    public class FilmStudio
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public DateTime EstablishDay { get; set; }
        public string Type { get; set; } //for example: independent, major, blockbuster etc
    }
}
