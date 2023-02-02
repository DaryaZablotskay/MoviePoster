using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Models
{
    public class Ticket
    {
        public Guid TicketId { get; set; }
        public Guid? PlaceId { get; set; }
        public Place Place { get; set; }
        public Guid? ShowDateId { get; set; }
        public ShowDate ShowDate { get; set; }
        public Guid? FilmId { get; set; }
        public Film Film { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
    }
}
