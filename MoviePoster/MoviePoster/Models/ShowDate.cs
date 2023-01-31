using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Models
{
    public class ShowDate
    {
        public Guid ShowDateId { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
