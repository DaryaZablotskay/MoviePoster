using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Dtos
{
    public class ReserveRequestUserDto
    {
        public string FirstNameUser { get; set; }
        public string LastNameUser { get; set; }
        public string Email { get; set; }
        public int Hall { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
    }
}
