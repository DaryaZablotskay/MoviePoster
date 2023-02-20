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
        public int AgeLimit { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public double Rating { get; set; }
        public int Price { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
