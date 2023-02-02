using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Dtos
{
    public class OneFilmDto
    {
        public Guid OneFilmId { get; set; }
        public string OneFilmName { get; set; }
        public string OneFilmGenre { get; set; }
        public int OneFilmAgeLimit { get; set; }
        public int OneFilmDuration { get; set; }
        public string OneFilmDescription { get; set; }
        public string OneFilmPictureUrl { get; set; }
        public double OneFilmRating { get; set; }
        public int OneFilmPrice { get; set; }
    }
}
