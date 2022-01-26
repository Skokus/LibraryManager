using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Infrastructure.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public FilmStudio FilmStudio { get; set; }
        public int Budget { get; set; }
        public double Length { get; set; }
    }
}
