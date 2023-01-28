using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Dtos
{
    public class FilmCatalogeDto
    {
        public Guid FilmCatalogeId { get; set; }
        public string NameCataoge { get; set; }
        public string GenreCataloge { get; set; }
        public string AgeLimitCataloge { get; set; }
        public string PictureUrlCataloge { get; set; }
    }
}
