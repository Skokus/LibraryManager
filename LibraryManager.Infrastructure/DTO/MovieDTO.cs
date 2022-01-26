using LibraryManager.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.Infrastructure.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AuthorDTO Author { get; set; }
        public FilmStudioDTO FilmStudio { get; set; }
        public int Budget { get; set; }
        public double Length { get; set; }
    }
}
