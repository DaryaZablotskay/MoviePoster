using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Models
{
    public class Film
    {
        public Guid FilmId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string AgeLimit { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public ICollection<FilmUser> FilmUsers { get; set; }
        public ICollection<ShowdateFilm> ShowdateFilms { get; set; }
    }
}
