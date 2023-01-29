using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Dtos
{
    public class ShowDatesDto
    {
        public Guid ShowDatesDtoId { get; set; }
        public DateTime Time { get; set; }
        public Guid FilmId { get; set; }
    }
}
