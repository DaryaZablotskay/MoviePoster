using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime ShowDate { get; set; }
        public ICollection<Place> Places { get; set; }
        public ICollection<FilmUser> FilmUsers { get; set; }    
    }
}
