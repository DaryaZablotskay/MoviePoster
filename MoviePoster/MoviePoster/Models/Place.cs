using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Models
{
    public class Place
    {
        public Guid PlaceId { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public bool Status { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
    }
}
