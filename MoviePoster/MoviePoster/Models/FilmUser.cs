using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Models
{
    public class FilmUser
    {
        public Guid FilmUserId { get; set; }
        public Guid? FilmId { get; set; }
        public Film Film { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
    }
}
