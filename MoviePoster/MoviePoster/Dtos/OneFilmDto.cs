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
        public string OneFilmAgeLimit { get; set; }
        public string OneFilmDuration { get; set; }
        public string OneFilmDescription { get; set; }
        public string OneFilmPictureUrl { get; set; }
        public double OneFilmRating { get; set; }
    }
}
