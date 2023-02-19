using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviePoster.Dtos
{
    public class AdminAddAndDeletePlaceDto
    {
        public int Hall { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
    }
}
