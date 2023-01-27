using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Models
{
    public class ShowdateFilm
    {
        public Guid ShowdateFilmId { get; set; }
        public Guid? ShowDateId { get; set; }
        public ShowDate ShowDate { get; set; }
        public Guid? FilmId { get; set; }
        public Film Film { get; set; }
    }
}
